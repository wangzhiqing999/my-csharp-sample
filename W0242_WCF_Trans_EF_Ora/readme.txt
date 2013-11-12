开发步骤:

做此操作以前，先在 SQL Server 上面的 Test 数据库上面，创建2个测试表。  sql 文件为本目录下的 db.sql
（如果没有 Test 数据库，那么创建一个）

================================================================================

1. 创建 MyWcfServiceLibrary 项目。 
1.1. 项目类型为 WCF 服务库
1.2. 向项目中,增加一个 ADO.NET 实体数据模型。
1.2. 编写一个 WCF 方法，这个方法插入 2 张表， 一张 主表， 一张子表。
1.3. 关于 WCF 事务 需要追加的配置信息。
1.3.1.  接口方法定义前 增加  [TransactionFlow(TransactionFlowOption.Allowed)]
1.3.2.  实现类 前增加   [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.PerCall, TransactionTimeout = "00:30:00" )] 
1.3.3.  实现类 方法前 增加  [System.ServiceModel.OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]



================================================================================

2. 创建 MyWcfServiceClient 项目。
2.1. 项目类型 控制台应用程序。
2.2. 项目添加 “服务引用”， 弹出窗口后， 按 “发现” 按钮进行处理。
2.3. 编写 Program.cs，调用 WCF 服务 （此模式下创建的 app.config ， 仅用于 VS2010 开发环境下测试使用 ）
2.4. 测试运行， 注意核对 事务处理是否起作用了。