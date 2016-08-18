using System;
using System.Threading;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;

namespace MoveShapeDemo
{


    /// <summary>
    /// Broadcaster类，它使用.Net框架中的Timer类来对发送消息进行节流。
    /// 
    /// </summary>
    public class Broadcaster
    {
        /// <summary>
        /// 由于集线器本身是暂时存在的(每次需要时才创建)，Broadcaster被创建为一个单例。
        /// 使用了延迟初始化(.Net4中新增功能)，来推迟其创建时间直到需要它为止。
        /// 这是为了确保在计时器开始之前就有集线器的实例被成功创建完毕。
        /// </summary>
        private readonly static Lazy<Broadcaster> _instance =
            new Lazy<Broadcaster>(() => new Broadcaster());


        // We're going to broadcast to all clients a maximum of 25 times per second
        private readonly TimeSpan BroadcastInterval =
            TimeSpan.FromMilliseconds(40);


        private readonly IHubContext _hubContext;


        /// <summary>
        /// 定时器处理类.
        /// </summary>
        private Timer _broadcastLoop;


        /// <summary>
        /// 矩形的坐标的数据.
        /// </summary>
        private ShapeModel _model;


        /// <summary>
        /// 数据是否发生变化的标志
        /// </summary>
        private bool _modelUpdated;



        public Broadcaster()
        {
            // Save our hub context so we can easily use it 
            // to send to its connected clients
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<MoveShapeHub>();

            // 初始化 矩形坐标数据.
            _model = new ShapeModel();

            // 数据尚未发生更新.
            _modelUpdated = false;



            // 启动定时器.
            // Start the broadcast loop
            _broadcastLoop = new Timer(
                BroadcastShape,
                null,
                BroadcastInterval,
                BroadcastInterval);
        }



        /// <summary>
        /// 定时执行的方法.
        /// </summary>
        /// <param name="state"></param>
        public void BroadcastShape(object state)
        {
            // No need to send anything if our model hasn't changed
            if (_modelUpdated)
            {
                // 如果数据发生变化了， 才调用客户端的方法.

                // This is how we can access the Clients property 
                // in a static hub method or outside of the hub entirely
                _hubContext.Clients.AllExcept(_model.LastUpdatedBy).updateShape(_model);
                _modelUpdated = false;
            }
        }


        /// <summary>
        /// Hub 调用这个方法， 来 通知：数据发生变化， 需要做相关处理了。
        /// </summary>
        /// <param name="clientModel"></param>
        public void UpdateShape(ShapeModel clientModel)
        {
            _model = clientModel;
            _modelUpdated = true;
        }



        /// <summary>
        /// 单例方法.
        /// </summary>
        public static Broadcaster Instance
        {
            get
            {
                return _instance.Value;
            }
        }
    }



    /// <summary>
    /// 这个是 Hub.
    /// </summary>
    public class MoveShapeHub : Hub
    {
        // Is set via the constructor on each creation
        private Broadcaster _broadcaster;


        public MoveShapeHub()
            : this(Broadcaster.Instance)
        {
        }


        public MoveShapeHub(Broadcaster broadcaster)
        {
            _broadcaster = broadcaster;
        }


        /// <summary>
        ///  客户端将调用这个方法.
        /// </summary>
        /// <param name="clientModel"></param>
        public void UpdateModel(ShapeModel clientModel)
        {

            clientModel.LastUpdatedBy = Context.ConnectionId;


            
            // ----------  Version  1.0 ----------

            // 初期版本的代码.
            // 也就是 除了当前操作的用户以外， 其他用户都调用 updateShape 方法。
            // Clients.AllExcept(clientModel.LastUpdatedBy).updateShape(clientModel);

            // 因为这个例子是 拖矩形的， 和 聊天室不同。
            // 聊天室是 用户发送一个消息， 然后全部人都收到。

            // 这里 拖矩形的人， 拖动操作已经完成了， 就不能让这个人的画面再发生更新操作。

            // ----------  Version  1.0 ----------




            // Update the shape model within our broadcaster
            _broadcaster.UpdateShape(clientModel);
        }
    }



    /// <summary>
    /// 这个是一个 数据， 用于存储 矩形的坐标.
    /// </summary>
    public class ShapeModel
    {

        // We declare Left and Top as lowercase with 
        // JsonProperty to sync the client and server models
        [JsonProperty("left")]
        public double Left { get; set; }



        [JsonProperty("top")]
        public double Top { get; set; }



        // We don't want the client to get the "LastUpdatedBy" property
        [JsonIgnore]
        public string LastUpdatedBy { get; set; }
    }

}
