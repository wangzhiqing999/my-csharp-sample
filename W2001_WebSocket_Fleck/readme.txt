使用 Fleck 来开发 WebSocket 



步骤1. 项目中引用，添加 NuGet 程序包 Fleck.



步骤2. 根据需要， 自己填写事件处理代码.


// 创建一个 WebSocket 服务， 并启动它.
var echoServer = new WebSocketServer("ws://127.0.0.1:8181/Echo");
echoServer.Start(socket =>
{
	socket.OnOpen = () => 
	{
		Console.WriteLine("echoServer 连接打开.");
	};

	socket.OnClose = () =>
	{
		Console.WriteLine("echoServer 连接关闭.");
	};

	socket.OnMessage = message =>
	{
		Console.WriteLine("echoServer接收到客户端的请求：{0}, 简单原样返回.", message);
		socket.Send(message);
	};

	socket.OnError = (error) =>
	{
		Console.WriteLine("哎呀，echoServer 发生错误了......" + error.ToString());
	};

	socket.OnPing = (buff) =>
	{
		Console.WriteLine("echoServer接收到 Ping ！");
	};

	socket.OnPong = (buff) =>
	{
		Console.WriteLine("echoServer接收到 Pong ！");
	};

});