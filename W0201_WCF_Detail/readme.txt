开发步骤:

================================================================================

1. 创建 MyWCFService.Contract 项目。 
1.1. 项目类型为 DLL。
1.2. 对项目增加 System.Runtime.Serialization 与 System.ServiceModel 的引用。
1.3. 删除掉项目创建时，自动产生的那个 Class1.cs

1.4. 新增一个类 DivResult
1.5. 为类增加 属性的定义
1.6. 类定义前，增加 [DataContract] ；  属性定义前，增加 [DataMember]。

1.7. 新增一个接口 ICalculator.cs
1.8. 为接口增加 方法的定义
1.9. 接口定义前，增加 [ServiceContract] ； 接口方法定义前，增加 [OperationContract] 。


此步骤执行完毕后，相当于项目的框架已经定义好。 
服务端的代码，目的是 实现接口。
客户端的代码，是调用接口的方法。


================================================================================

2. 创建 MyWCFService.Service 项目。
2.1. 项目类型为 DLL。
2.2. 对项目增加引用。 引用  MyWCFService.Contract 项目。 
2.3. 将项目创建时，自动产生的那个 Class1.cs，更名为 CalculatorService.cs
2.4. 修改 CalculatorService.cs， 让这个类， 实现 前面步骤 1.7. 创建的那个 接口。


此步骤执行完毕后，相当于项目的服务端代码已经开发完毕。 
如果 条件允许，可针对 MyWCFService.Service 项目。编写 单元测试的代码。
这样可以在后期 WCF 客户端 调用 WCF 服务端的出错的时候，缩小排除错误的范围。

================================================================================

3. 创建 MyWCFService.Hosting 项目。
3.1. 项目类型 控制台应用程序。
3.2. 对项目增加引用。 引用  MyWCFService.Contract 项目 与 MyWCFService.Service 项目。 
3.3. 对项目增加 System.ServiceModel 的引用。
3.4. 对项目增加一个 “应用程序配置文件” （也就是 App.config）
3.5. 修改 App.config ,增加 <system.serviceModel> 的一整套的配置信息.
3.6. 修改 Program.cs
3.7. 测试运行.



此步骤执行完毕后，相当于一个 局域网里面 WCF 服务器端已经搭建完毕。
这里的配置是使用 netTcpBinding， 传输的编码是 二进制 方式传输的。

具体 Binding 信息，可参考：
http://msdn.microsoft.com/zh-cn/library/ms730879.aspx


如果整个系统是 Client / Server 的方式，在局域网中运作的，那么到这一步， Server 的开发配置工作已经基本完成。



================================================================================

4. 创建 MyWCFService.Web 项目
4.1. 项目类型 ASP.NET 空 Web 应用程序
4.2. 对项目增加引用。 引用  MyWCFService.Contract 项目 与 MyWCFService.Service 项目。 
4.3. 对项目增加 System.ServiceModel 的引用。
4.4. 新增一个  WCF服务：   MyWCFService.svc
4.5. 删除掉自动创建出来的  IMyWCFService.cs  与  MyWCFService.svc.cs
4.6. 修改 MyWCFService.svc 文件。  修改 Service 部分，  删除 CodeBehind 部分。
4.7. 修改项目， 使用 IIS Express
4.8. 测试运行.


此步骤执行完毕后，相当于一个 基于Web的 WCF 服务器端已经搭建完毕。
这里的配置是使用 basicHttpBinding， 传输的编码是 文本 方式传输的。

具体 Binding 信息，可参考：
http://msdn.microsoft.com/zh-cn/library/ms730879.aspx


如果整个系统是 Browser/Server 的方式运作， 或者是 Client / Server 在广域网上运作的，那么到这一步， Server 的开发工作已经基本完成。 ( 配置还没配完 )




================================================================================
5. 创建 MyWCFService.Client 项目
5.1. 项目类型 控制台应用程序。
5.2. 对项目增加引用。 引用  MyWCFService.Contract 项目   ( 注意: MyWCFService.Service 项目就不要引用了) 
5.3. 对项目增加  System.Runtime.Serialization 与 System.ServiceModel 的引用。
5.4. 对项目增加一个 “应用程序配置文件” （也就是 App.config）
5.5. 修改 App.config ,增加 <system.serviceModel> 的一整套的配置信息.
5.6. 创建一个 CalculatorClient.cs 类。 实现 ClientBase<ICalculator>, ICalculator
5.7. 编写 Program.cs， 分别调用 MyWCFService.Hosting 上的 WCF 服务 与  MyWCFService.Web 上的 WCF 服务。
5.8. 测试运行 （运行前，需要外部提前运行 那个 MyWCFService.Hosting.exe 。  以及 IIS Express 正确加载了 Web ）



此步骤执行完毕后，相当于 WCF 客户端代码 已经 成功地调用 WCF 服务端。


