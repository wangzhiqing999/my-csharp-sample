using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace A0136_SocketAsyncEventArgsServer.Sample
{
    // Implements the connection logic for the socket server.  
    // After accepting a connection, all data read from the client 
    // is sent back to the client. The read and echo back to the client pattern 
    // is continued until the client disconnects.
    class Server
    {
        private int m_numConnections;   // the maximum number of connections the sample is designed to handle simultaneously 
        private int m_receiveBufferSize;// buffer size to use for each socket I/O operation 


        /// <summary>
        /// 缓存管理.
        /// </summary>
        BufferManager m_bufferManager;  // represents a large reusable set of buffers for all socket operations


        const int opsToPreAlloc = 2;    // read, write (don't alloc buffer space for accepts)
        Socket listenSocket;            // the socket used to listen for incoming connection requests



        // pool of reusable SocketAsyncEventArgs objects for write, read and accept socket operations
        /// <summary>
        /// SocketAsyncEventArgs 对象池.
        /// </summary>
        SocketAsyncEventArgsPool m_readWritePool;


        int m_totalBytesRead;           // counter of the total # bytes received by the server
        int m_numConnectedSockets;      // the total number of clients connected to the server 


        /// <summary>
        /// 限制可同时访问某一资源或资源池的线程数。
        /// </summary>
        Semaphore m_maxNumberAcceptedClients;




        // Create an uninitialized server instance.  
        // To start the server listening for connection requests
        // call the Init method followed by Start method 
        //
        // <param name="numConnections">the maximum number of connections the sample is designed to handle simultaneously</param>
        // <param name="receiveBufferSize">buffer size to use for each socket I/O operation</param>

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="numConnections"> 最大连接数. </param>
        /// <param name="receiveBufferSize"> 每个socket数据包的大小. </param>
        public Server(int numConnections, int receiveBufferSize)
        {
            m_totalBytesRead = 0;
            m_numConnectedSockets = 0;
            m_numConnections = numConnections;
            m_receiveBufferSize = receiveBufferSize;


            // allocate buffers such that the maximum number of sockets can have one outstanding read and 
            // write posted to the socket simultaneously  
            // 初始化 缓存.
            // 其中，缓冲池大小的计算方式 = 每个socket数据包的大小 * 最大连接数 * 2 （2是 一个读，一个写）
            m_bufferManager = new BufferManager(receiveBufferSize * numConnections * opsToPreAlloc,
                receiveBufferSize);

            // SocketAsyncEventArgs 对象池， 大小 = 最大连接数.
            m_readWritePool = new SocketAsyncEventArgsPool(numConnections);


            // 限制可同时访问某一资源或资源池的线程数。
            // 可以同时授予的信号量的初始请求数 = 最大连接数
            // 可以同时授予的信号量的最大请求数 = 最大连接数
            m_maxNumberAcceptedClients = new Semaphore(numConnections, numConnections);
        }




        // Initializes the server by preallocating reusable buffers and 
        // context objects.  These objects do not need to be preallocated 
        // or reused, but it is done this way to illustrate how the API can 
        // easily be used to create reusable objects to increase server performance.
        //
        //通过预分配可用的缓冲区和上下文来对象初始化服务器  
        //这些上下文对象大可不必在此预分配，它也暂时不会用到  
        //但是这么去创建可用的上下文对象会提高服务器的性能(避免局部多次new)  
        /// <summary>
        /// 初始化服务器
        /// </summary>
        public void Init()
        {

            // Allocates one large byte buffer which all I/O operations use a piece of.  This gaurds 
            // against memory fragmentation
            //分配一大块内存，每一个I/O操作只用其中的一小段  
            //这将有效地防止内存碎片化  
            m_bufferManager.InitBuffer();

            // preallocate pool of SocketAsyncEventArgs objects
            SocketAsyncEventArgs readWriteEventArg;


            for (int i = 0; i < m_numConnections; i++)
            {
                //Pre-allocate a set of reusable SocketAsyncEventArgs
                readWriteEventArg = new SocketAsyncEventArgs();
                readWriteEventArg.Completed += new EventHandler<SocketAsyncEventArgs>(IO_Completed);
                readWriteEventArg.UserToken = new AsyncUserToken();

                // assign a byte buffer from the buffer pool to the SocketAsyncEventArg object
                m_bufferManager.SetBuffer(readWriteEventArg);

                // add SocketAsyncEventArg to the pool
                m_readWritePool.Push(readWriteEventArg);
            }

        }

        // Starts the server such that it is listening for 
        // incoming connection requests.    
        //
        // <param name="localEndPoint">The endpoint which the server will listening 
        // for connection requests on</param>
        /// <summary>
        /// 开始启动监听  
        /// </summary>
        /// <param name="localEndPoint"></param>
        public void Start(IPEndPoint localEndPoint)
        {
            // create the socket which listens for incoming connections
            listenSocket = new Socket(localEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listenSocket.Bind(localEndPoint);
            // start the server with a listen backlog of 100 connections
            listenSocket.Listen(100);

            // post accepts on the listening socket
            StartAccept(null);

            //Console.WriteLine("{0} connected sockets with one outstanding receive posted to each....press any key", m_outstandingReadCount);
            Console.WriteLine("请按任意键结束服务....");
            Console.ReadKey();
        }


        // Begins an operation to accept a connection request from the client 
        //
        // <param name="acceptEventArg">The context object to use when issuing 
        // the accept operation on the server's listening socket</param>

        /// <summary>
        /// 开始接收连接请求  
        /// 当有数据时将会用上下文对象  
        /// </summary>
        /// <param name="acceptEventArg"></param>
        public void StartAccept(SocketAsyncEventArgs acceptEventArg)
        {
            if (acceptEventArg == null)
            {
                acceptEventArg = new SocketAsyncEventArgs();
                acceptEventArg.Completed += new EventHandler<SocketAsyncEventArgs>(AcceptEventArg_Completed);
            }
            else
            {
                // socket must be cleared since the context object is being reused
                // AcceptSocket必须每次都要清空，不然将会报错 
                acceptEventArg.AcceptSocket = null;
            }

            // 超过所连接客户端的数量后，将阻塞Accept操作  
            m_maxNumberAcceptedClients.WaitOne();

            bool willRaiseEvent = listenSocket.AcceptAsync(acceptEventArg);
            if (!willRaiseEvent)
            {

                Console.WriteLine("########## AcceptAsync 返回 false.");

                ProcessAccept(acceptEventArg);
            }
        }



        // This method is the callback method associated with Socket.AcceptAsync 
        // operations and is invoked when an accept operation is complete
        //
        // 这个方法是与Socket.AcceptAsync操作有关的回调方法  
        // 当一个accept操作完成后该方法将被调用  
        void AcceptEventArg_Completed(object sender, SocketAsyncEventArgs e)
        {
            ProcessAccept(e);
        }



        private void ProcessAccept(SocketAsyncEventArgs e)
        {
            Interlocked.Increment(ref m_numConnectedSockets);
            Console.WriteLine("Client connection accepted. There are {0} clients connected to the server",
                m_numConnectedSockets);

            // Get the socket for the accepted client connection and put it into the 
            //ReadEventArg object user token

            //获取接收到的客户端，并将其放入对应的上下文对象的UserToken里  
            SocketAsyncEventArgs readEventArgs = m_readWritePool.Pop();
            ((AsyncUserToken)readEventArgs.UserToken).Socket = e.AcceptSocket;


            // As soon as the client is connected, post a receive to the connection
            // 首先读一次，看有数据没 
            bool willRaiseEvent = e.AcceptSocket.ReceiveAsync(readEventArgs);
            if (!willRaiseEvent)
            {
                Console.WriteLine("########## ReceiveAsync 返回 false.");

                ProcessReceive(readEventArgs);
            }

            // Accept the next connection request
            // 接受下一次的请求  
            StartAccept(e);
        }



        // This method is called whenever a receive or send operation is completed on a socket 
        //
        // <param name="e">SocketAsyncEventArg associated with the completed receive operation</param>
        void IO_Completed(object sender, SocketAsyncEventArgs e)
        {
            // determine which type of operation just completed and call the associated handler
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.Receive:

                    Console.WriteLine("LastOperation:SocketAsyncOperation.Receive");

                    ProcessReceive(e);
                    break;
                case SocketAsyncOperation.Send:

                    Console.WriteLine("LastOperation:SocketAsyncOperation.Send");

                    ProcessSend(e);
                    break;
                default:
                    throw new ArgumentException("The last operation completed on the socket was not a receive or send");
            }

        }

        // This method is invoked when an asynchronous receive operation completes. 
        // If the remote host closed the connection, then the socket is closed.  
        // If data was received then the data is echoed back to the client.
        //
        private void ProcessReceive(SocketAsyncEventArgs e)
        {
            // check if the remote host closed the connection
            // 查看客户端是否已经断掉  
            AsyncUserToken token = (AsyncUserToken)e.UserToken;

            if (e.BytesTransferred > 0 && e.SocketError == SocketError.Success)
            {

                //increment the count of the total bytes receive by the server
                // 原子性的计算总接收数据量.
                Interlocked.Add(ref m_totalBytesRead, e.BytesTransferred);
                Console.WriteLine("The server has read a total of {0} bytes", m_totalBytesRead);

                for (int i = 0; i < e.BytesTransferred; i++)
                {
                    Console.Write((char)e.Buffer[e.Offset + i]);
                }
                Console.WriteLine();

                //echo the data received back to the client
                e.SetBuffer(e.Offset, e.BytesTransferred);
                bool willRaiseEvent = token.Socket.SendAsync(e);
                if (!willRaiseEvent)
                {
                    ProcessSend(e);
                }

            }
            else
            {
                CloseClientSocket(e);
            }
        }

        // This method is invoked when an asynchronous send operation completes.  
        // The method issues another receive on the socket to read any additional 
        // data sent from the client
        //
        // <param name="e"></param>
        private void ProcessSend(SocketAsyncEventArgs e)
        {
            if (e.SocketError == SocketError.Success)
            {
                // done echoing data back to the client
                AsyncUserToken token = (AsyncUserToken)e.UserToken;

                // read the next block of data send from the client
                bool willRaiseEvent = token.Socket.ReceiveAsync(e);

                if (!willRaiseEvent)
                {
                    ProcessReceive(e);
                }
            }
            else
            {
                CloseClientSocket(e);
            }
        }



        private void CloseClientSocket(SocketAsyncEventArgs e)
        {
            AsyncUserToken token = e.UserToken as AsyncUserToken;

            // close the socket associated with the client
            try
            {
                token.Socket.Shutdown(SocketShutdown.Send);
            }
            // throws if client process has already closed
            catch (Exception) { }
            token.Socket.Close();

            // decrement the counter keeping track of the total number of clients connected to the server
            Interlocked.Decrement(ref m_numConnectedSockets);
            m_maxNumberAcceptedClients.Release();
            Console.WriteLine("A client has been disconnected from the server. There are {0} clients connected to the server", m_numConnectedSockets);

            // Free the SocketAsyncEventArg so they can be reused by another client
            m_readWritePool.Push(e);
        }

    }    


}
