C# 的例子代码


# 基础部分.


### A0000_BaseFunction

System.Collections 下 ArrayList、Hashtable、Queue、SortedList、Stack 操作的例子


### A0001_Partial

partial 关键字的使用例子



### A0002_Assert 
Debug.Assert  实现 断言 处理的使用例子  




### A0003_TraceLog 
Trace 方法  实现 跟踪配置 处理的使用例子  




### A0004_yield 

yield 的使用例子.
优点在于, 当需要返回一个比较大的数据列表.  并且结果列表的每一行, 都要花费比较长的时间进行处理的情况下.
普通的处理方式, 是全部结果数据都获取完了, 才能返回.
yield 的处理方式, 是有一行数据, 先返回一行. 而不是全部获取完了， 才一起返回.
这样对于某些耗时的处理， 可以迅速地先返回部分数据， 让用户能够看到。





### A0005_Reflection 
反射 操作的例子 （普通的例子，与泛型的例子）  



### A0006_Reflection2 
反射 操作的例子 II  



### A0007_Reflection_ModelCopyer 
通过反射, 复制两个类的属性的例子  ( 用于 系统生成类 -- 自定义类 直接的数据复制 )   






### A0010_OO 
接口、抽象类、实现类 以及在方法上 abstract、virtual、override、new 的例子  




### A0011_OO_Mul_Interface 
一个类实现多接口，且接口有同名方法，要求不同实现的例子  




### A0012_OO_AutoProp 
自动实现的属性的例子  




### A0013_OO_Constructor  
构造函数 与 析构函数 的例子  





### A0015_OverloadOperator  
重载运算符 的例子
这里通过一个  长度3位，范围 000 - Z99，其中低位为十进制 范围 00 - 99，高位为 36进制 范围 0-9 A-Z 的 序列号类来做 重载运算符 的操作。





### A0016_ExtensionMethods  

扩展方法给我们提供了一种很便捷的方式，
通过这种方式我可以给那些不是我们自己创建的类(如第三方组件里面的)
或是我们不能直接修改的类添加方法。







### A0016_IMPLICIT_EXPLICIT 
implicit 与 explicit 关键字的例子. 用于实现 类与类之间转换处理.
也就是对于
B b = new B();
显式的 A a = (A) b; 与隐式 的  A a = b;







### A0017_RandomCode 
随机码生成器例子  









### A0020_Function 
函数中、参数数量可变、REF、OUT 的例子  




### A0030_Event 
事件处理的例子  




### A0031_delegate  
委派 的例子  




### A0032_MulEvent  
链接事件 的例子  




### A0033_MulDelegate  
多重委派 的例子  




### A0040_Indexer 
索引器 的例子  




### A0050_TryCatchFinally 
Try / Catch/ Finally 的例子  




### A0055_GenericMethod 
泛型方法的例子  





### A0056_Covariant  
协变(covariant)
协变：让一个带有协变参数的泛型接口（或委托）可以接收类型更加精细化，具体化的泛型接口（或委托）作为参数，可以看成OO中多态的一个延伸。

通常，协变类型参数可用作委托的返回类型，而逆变类型参数可用作参数类型。
对于接口，协变类型参数可用作接口的方法的返回类型，而逆变类型参数可用作接口的方法的参数类型。






### A0057_Contravariant  
逆变 (contravariant)
逆变：让一个带有协变参数的泛型接口（或委托）可以接收粒度更粗的泛型接口或委托作为参数，这个过程实际上是参数类型更加精细化的过程。

通常，协变类型参数可用作委托的返回类型，而逆变类型参数可用作参数类型。
对于接口，协变类型参数可用作接口的方法的返回类型，而逆变类型参数可用作接口的方法的参数类型。






### A0060_Enum 
枚举 的例子  





### A0065_Switch 
Switch 语句， goto 处理的例子  






### A0070_CustomAttributes 
类特性 的例子  




### A0071_Deprecated 
过期（Deprecated / Obsolete） 的例子  




### A0075_AOPAttributes 
通过 Attributes 实现 AOP 的例子  





### A0076_AOPDynamicObject 
通过 DynamicObject 实现 AOP 的例子  






### A0080_checked 
溢出检测 的例子  




### A0090_Resource 
读写资源文件 的例子  





### A0095_RegistryHelper 
读写注册表的例子 





### A0100_File  
读写文本文件 与 二进制文件 的例子  






### A0101_NewtonsoftJson  
使用 Newtonsoft.Json ， 进行 序列化 / 反序列化  的例子  






### A0101_ProtocolBuffers  
使用 protobuf-csharp-sport  进行 序列化 / 反序列化 的例子  （引用 Google.ProtocolBuffers ）
（ 相对于 protobuf-net， 这个版本的，比较遵循Google 的原生态写法，跨平台选择此版本比较好。 ）






### A0101_Serializable  
序列化 / 反序列化 的例子
（ProtocolBuffers 序列化的，使用了 protobuf-net 来完成，写法上比较符合c#一贯的写法。 如果不跨平台，全部都是 C# 写的，使用这个比较合适。 ）






### A0102_Path  
获取应用程序 当前路径 的例子  




### A0103_FileEncoding  
文件编码格式转换 的例子  




### A0104_ConvertHtmlToUTF8 

某个小工具代码，用于将 普通编码的 html 文件， 转换为 utf-8 的 html 文件
（本工具会覆盖掉原有的代码，使用前需做好备份）






### A0110_DateTime 
日期/时间间隔 使用 的例子  




### A0120_Schedule 
定时执行任务的例子,  以及定时执行任务时,遇到超时,先停止再执行的例子.  




### A0130_SocketServer  
Socket 服务端处理的例子。 接收到请求后，接收一条消息，发送反馈后断开。（短连接处理逻辑）  




### A0131_UdpSocketServer 
UDP Socket 发送消息的例子  




### A0132_NamedPipeServer 
使用命名管道通过网络在进程之间进行通信 服务端 




### A0133_AnonymousPipeServer 
使用匿名管道进行本地进程间通信 服务端 




### A0134_MemoryMappedFileServer 
持久内存映射文件 服务端  （创建、读取、修改内存映射文件） 




### A0136_SocketAsyncEventArgsServer 
使用 SocketAsyncEventArgs 异步通信的例子(服务端) 




### A0137_SocketServerPlus 
A0130_SocketServer 的升级版本， 接收到请求后，新开一个线程，专门用于处理当前用户的请求。（长连接处理逻辑）  










### A0140_SocketClient  
Socket 客户端处理 的例子 （短连接处理逻辑）  




### A0141_UpdSocketClient 
UDP  Socket 接收消息的例子  




### A0142_NamedPipeClient 
使用命名管道通过网络在进程之间进行通信 客户端 




### A0143_AnonymousPipeClient 
使用匿名管道进行本地进程间通信 客户端  (由服务端调用启动)  





### A0144_MemoryMappedFileClient 
持久内存映射文件 客户端  （读取、修改内存映射文件） 







### A0145_WebRequest_WebClient  
使用 WebRequest,  WebClient  来从网页上面获取数据的例子  




### A0145_HttpClient 
使用 System.Net.Http.HttpClient 从网页上面获取数据的例子  







### A0146_SocketAsyncEventArgsClient 
使用 SocketAsyncEventArgs 异步通信的例子(客户端) 





### A0147_SocketClientPlus 
Socket 客户端处理 的例子 （长连接处理逻辑） 










### A0150_Access  
访问 Access 数据库的例子  




### A0151_Excel  
以数据库方式访问 Excel 的例子 (使用 OleDB)  





### A0160_SQL_Server  
访问 SQL Server 数据库的例子  




### A0161_SQL_Server_Porc_UnitTest  
SQL Server 数据库存储过程／函数　单元测试的例子　
本存储过程，为 SQL Server 下，创建 流水号的 的处理.
支持
[固定前缀]+年月日+序号 、
[固定前缀]+年月+序号 、
[固定前缀]+年+序号
等的 生成方式。





### A0162_SQL_Server_Func_MyRule_UnitTest  
SQL Server 数据库 函数　单元测试的例子　
本次测试的函数，为 SQL Server 下， 组织结构、用户、角色、模块、模块动作的 一套体系结构。
其中、组织结构 与 模块结构 为 树型体系结构.
角色为独立结构（非树型）
用户  多对多  组织结构
用户  多对多  角色
用户  多对多  模块
用户  多对多  模块动作
角色  多对多  模块
角色  多对多  模块动作

对于一个用户
最终可访问的模块 =	用户直接可访问模块（包含模块的子模块）+ 用户角色直接可访问模块（包含模块的子模块）
最终可访问的模块动作 = 用户最终可访问的模块下的“默认可访问模块动作” + 针对用户设置的可访问模块动作 + 针对用户角色设置的可访问模块动作
最终可访问的数据 = 用户所属部门(以及下属部门)的数据.








### A0165_SQL_Server_Oracle 

用于测试  System.Transactions.TransactionScope 跨数据库的事务处理的例子。
SQL Server 中有一个存储过程  test_SqlServer_Proc。  Oracle 中有一个存储过程  test_Oracle_Proc 。
先执行 SQL Server 的存储过程，  后执行 Oracle 的存储过程。
只要这2个存储过程中，任意一个失败了， 那么全部回滚掉。






### A0170_Oracle  
访问 Oracle 数据库的例子
（使用 微软的类库来访问。  命名空间为  System.Data.OracleClient ）






### A0171_Oracle_ODAC  
访问 Oracle 数据库的例子
( 使用 Oracle 的 ODAC 来访问。 命名空间为  Oracle.DataAccess.Client )





### A0172_Oracle_MyRule  

使用 Oracle 来 实现  A0162_SQL_Server_Func_MyRule_UnitTest 的 处理 。
因为 Oracle 中， 没有 SQL Server 那种 “表值函数” 的东西。
因此，具体业务处理逻辑， 是以 C# 代码的方式实现的。
( 本项目 使用 Entity Framework 进行处理 )






### A0175_PostgreSQL  
访问 PostgreSQL 数据库的例子
（使用 Npgsql.dll 来访问。  命名空间为  Npgsql， C# 端不用安装 PostgreSQL 相关软件 ）







### A0180_MySQL_ODBC  
访问 MySQL 数据库的例子 (使用 ODBC)  




### A0185_MySQL_MySqlClient  
访问 MySQL 数据库的例子 (使用 MySqlClient)  




### A0188_SQLite_SQLiteClient  
访问 SQLite 数据库的例子   




### A0190_A0190_MongoDB  
访问 MongoDB 数据库的例子  






### A0200_XML  
XML 读取/写入 的例子  




### A0205_XmlSerializer  
通过 XmlSerializer 读取/写入 XML 的例子  




### A0210_DataSetXML  
通过 DataSet 读取 XML 文件的例子  




### A0211_DataTableCompute  
通过 DataTable 进行数据计算的例子  





### A0300_Thread  
最简单的 线程 的例子  




### A0301_ThreadAbort  
如何中止线程执行 的例子  




### A0302_ThreadPriority  
线程优先级 的例子  




### A0303_ThreadSafe  
线程安全/同步 的例子  





### A0320_ThreadPool  
线程池 的例子  





### A0330_ThreadAsyncInvoke  
主线程 与 子线程 异步处理 的例子 
该例子使用的是：异步编程模型 (APM) 模式（也称 IAsyncResult 模式），
在此模式中异步操作需要 Begin 和 End 方法（比如用于异步写入操作的 BeginWrite 和 EndWrite）。 





### A0331_ThreadAsyncInvoke_EAP  
主线程 与 子线程 异步处理 的例子  
该例子使用的是：基于事件的异步模式 (EAP)，
这种模式需要 Async 后缀，也需要一个或多个事件、事件处理程序委托类型和 EventArg 派生类型。







### A0331_ThreadAsyncInvoke_TAP 
主线程 与 子线程 异步处理 的例子  
该例子使用的是：基于任务的异步模式 (TAP) 
C# 中的 async 和 await 关键词运算符为 TAP 添加了语言支持。
(该项目需要运行在  .Net 4.5 环境下)










### A0340_ThreadReadWrite  
生产者 / 消费者 多线程处理 的例子  





### A0350_WinFormThread  
WinForm 下，多线程处理 的例子 （用于避免长时间操作，画面卡住）  




### A0351_WinFormThreadTwoPart  
WinForm 下，多线程处理 的例子
（几种 串行/并行 处理方式的对比，）
某些 Case 使用了 .NET 4.0 的新特性.  




### A0352_WinFormThreadInvokeParam  
WinForm 下， Control.Invoke 方法， 获取返回值的处理例子。
因为某些情况下， 多线程的处理过程中， 需要先从画面上， 获取部分数据，然后再针对获取到的数据，执行相应的处理。





### A0360_Timers  
定时器处理的例子代码。  





### A0370_Lazy 
延迟初始化处理的例子。  
用于在一个  父子关系的 结构里面，  当加载  父列表数据的时候， 不立即加载子列表，而是当使用的时候，才加载。 






### A0380_Task  
.NET 4.5 中  Task / async / await  使用的例子。   













### A0400_String   
字符串处理 与 正则表达式 的例子  




### A0410_Globalization   
本地化 的例子  





### A0411_ChinesePinyin   
汉语拼音 的例子
(注:  此项目需要  安装  Visual Studio International Pack 1.0 SR1 中的
[Simplified Chinese Pin-Yin Conversion Library - 支持获取简体中文字符的常用属性比如拼音，多音字，同音字，笔画数。] )






### A0412_ChinesePinyin  
汉语拼音 的例子
(注:  此项目需要  安装  Visual Studio International Pack 1.0 SR1 中的
[Simplified Chinese Pin-Yin Conversion Library - 支持获取简体中文字符的常用属性比如拼音，多音字，同音字，笔画数。] )





### A0415_NumericFormatting 

数字 格式化为 汉字的处理， 例如 456789 处理成
简体中文: 四十五万六千七百八十九
繁体中文: 肆拾伍萬陸仟柒佰捌拾玖
日文: 四拾伍萬六阡七百八拾九
(注:  此项目需要  安装  Visual Studio International Pack 2.0   )






### A0420_Log   
使用 System.IO.Log 实现日志记录 的例子  







### A0500_LINQ_Base1  
最基本的 LINQ 的例子 使用 int 数组作为数据源 的例子  




### A0501_LINQ_Base2   
基本的 LINQ 的例子 使用 自己创建的类 的集合作为数据源 的例子  





### A0500_LINQ_Base3  

以 Nunit 的方式，
测试 All、Any、
Count、
First、FirstOrDefault、
Last、LastOrDefault、
Max、Min、
OrderBy、OrderByDescending、
Reverse、
Select、SelectMany、
Single、SingleOrDefault、
Skip、SkipWhile、
Sum、
Take、TakeWhile、
Where 方法的例子。






### A0510_LINQ_XML  
LINQ to XML 关于 XML 文件读取 的例子  





### A0511_LINQ_XML_Query  
LINQ to XML 关于 XML 的 LINQ 查询 的例子  





### A0520_LINQ_DataSet  
LINQ to DataSet 的例子  




### A0530_LINQ_SQL  
LINQ to SQL 的例子 - 使用 dbml 文件  




### A0530_LINQ_SQL_Access 
LINQ to SQL  访问  Access  数据库的例子    





### A0540_LINQ_SQL  
LINQ to SQL 的例子 - 使用 map 文件  





### A0550_PLINQ_Base1  
最简单的 并行 LINQ 查询 的例子  *要求 .NET Framework 4.0  




### A0551_PLINQ_Base2  
并行 LINQ 查询的 ForAll 的例子，等价于普通LINQ的 foreach
*要求 .NET Framework 4.0  




### A0552_PLINQ_Base3  
并行 LINQ 查询 ParallelEnumerable.Max/Min/Average/Sum/Count 操作的例子  *要求 .NET Framework 4.0  




### A0553_PLINQ_Base4  
并行 LINQ 查询的操作，是否影响排列顺序的例子  *要求 .NET Framework 4.0  





### A0600_EF  
Entity Framework 的例子  




### A0620_EFv4  
Entity Framework v4.1 的例子 (需要 .NET 4.0)
本例子中，没有以前的那种 命令行下 执行 EdmGen 产生源代码的处理。
本例子在 C# 中定义了一个 mr_demo_data 类。
在 SQL Server 中，定义一个 mr_demo_data 表
类中的属性，与表中的字段，一一对应。

通过定义一个 DbContext 类。
在 DbContext 中， 为表定义 DbSet。
Business 类 将直接使用 DbContext ，来对特定的表，进行 更新、删除、查询的处理。






### A0621_EF_CodeFirst  
Entity Framework CodeFirst 的例子  (需要 .NET 4.0)
CodeFirst 意味着，不是先设计表、或者数据库模型。
而是先从设计 C# 的类开始。
定义具体的业务需求。
最后，通过 C# 中的定义， 来创建数据库与表。
此功能需要 Entity Framework 4.x 支持。





### A0622_EF_OneToMany  
Entity Framework 的 One To Many 例子 (需要 .NET 4.0)
Code First在处理多重性关系时应用了一系列规则。
规则使用导航属性确定多重性关系。
即可以是一对导航属性互相指定（双向关系），也可以是单个导航属性（单向关系）。

如果你的类中包含一个引用和一个集合导航属性，Code First视为一对多关系；
如果你的类中仅在单边包含导航属性（即要么是集合要么是引用，只有一种），Code First也将其视为一对多关系；

如果你的类包含两个集合属性，Code First默认会使用多对多关系；

如果你的类包含两个引用属性，Code First会视为一对一关系；
在一对一关系中，你需要提供附加信息以使Code First获知何为主何为辅。





### A0623_EF_ManyToMany  
Entity Framework 的 Many To Many 例子 (需要 .NET 4.0)





### A0624_EF_OneToOne  
Entity Framework 的 One To One 例子 (需要 .NET 4.0)





### A0630_EF_Inherit_TPH  
Entity Framework 的 继承处理的例子 (需要 .NET 4.0)
本例子用于演示 Entity Framework CodeFirst 中 继承 的处理方式。
这里使用的是 默认的 TPH 方式。
也就是 所有的子类，使用同一张表。
该表有一个 Discriminator 列，用于区分各个子类。
这个表的列，包含了各个子类的属性。






### A0631_EF_Inherit_TPT  
Entity Framework 的 继承处理的例子 (需要 .NET 4.0)
本例子用于演示 Entity Framework CodeFirst 中 继承 的处理方式。
这里使用的是 TPT 的方式。
也就是 基类使用一张表。
各个子类的使用各自单独的表。





### A0640_EF_Enum  
Entity Framework 枚举使用的例子 (需要 .NET 4.0)







### A0650_EF_Oracle  
Entity Framework  处理  Oracle 的例子代码
主要测试项目包含：
使用/不使用 延迟加载的对比；
序列号的处理；
存储过程的处理；
事务处理；
并发处理失败的情况





### A0650_EF_SqlServer  
Entity Framework  处理  SqlServer 的例子代码
主要测试项目包含：
使用/不使用 延迟加载的对比；
Identity 的处理；
存储过程的处理；
事务处理；
并发处理失败的情况；
Model First 的处理。






### A0650_EF_Document  
通过修改 Edmx 文件， 实现为 代码增加注释的功能
因为使用的是 通过 数据库 产生的 edmx 文件。
在数据库中，  表 与 字段，是有备注信息的。
但是将表导入到 开发环境中， 这个 备注信息没有被带过来。
这里写一个程序， 从数据库 读取 表/字段 的备注信息， 然后再去 更新  那个  edmx 文件.








### A0700_Main/ A0701_AutoUpdate/ A0702_CommonFunc  
多项目之间 代码引用 的例子  





### A0710_Merge  
泛型处理 数据合并 的例子 （要求用户继承 Merge 类）  




### A0711_Merge  

泛型处理 的例子 （要求用户数据类实现 MergeAble 接口）
这里使用了  where（泛型类型约束）  关键字.






### A0720_MultiTime  

存在有指定行数的数据，才做处理 的处理例子。
例如 一个月内，消费 2次以上（含2次）的顾客， 享受双倍积分，

为什么写这个类，而不用 SQL 语句直接查询的处理的原因有2点：
1、存在 退货的情况。 一个退货要取消掉 一个消费。
2、需要避免重复计算。
例如 本月15号的时候，已经把上半月 满足 消费 2次以上（含2次）条件的， 都赠送了 双倍的积分了。
月末再次计算的时候，单纯用 SQL 语句处理， 较为麻烦。










### A0730_TimeRange 
时间范围 重叠检查处理类.  






### A0740_AutoMatch 
自动匹配处理类.
用于 顾客 VIP 积分自动兑换礼品处理的算法。
两种算法：
一种是  大数字优先， 也就是  贪婪算法。
优先兑换掉  大积分的商品。
最大积分商品不能兑换时， 尝试兑换 积分第二大的商品。
直到没有商品可兑换了， 结束处理。

一种是  最小剩余，也就是 尽可能把所有的积分使用完毕，不留下多余的部分出来。
例如 礼品有 500；400；300 三个积分档次。
对于 一个有 1200 积分的顾客。
大数字优先算法， 将为该顾客优先兑换 2个 500分的礼品， 然后剩余 200分。
最小剩余算法， 将为该顾客兑换 500；400；300  各一个，  然后剩余 0 分。






### A0750_MainSub 

主账户-子帐户拆分处理.
用于 将一个大的金额， 拆分处理成多个 固定大小的金额。
消耗的时候，从前向后消耗， 补充的时候，从后向前补充（补充数值不能大于初始值）。






### A0760_PageToken 

页面令牌管理.
用于避免画面重复提交的处理。
每个画面初始化的时候， 系统产生一个令牌。
如果画面处理完毕，那么结束。
如果发生一个画面， 多次提交了，由于令牌是唯一的。
那么后续的提交，将失败。






### A0800_Excel  
数据导入/导出 Excel 的例子  




### A0801_Excel  
数据导入/导出 Excel 的例子 (A0800_Excel 的重构)
目的为了支持 1个数据类，能够创建多种结构的 Excel 表格。





### A0802_Excel  
数据导入/导出 Excel 的例子 ( A0800_Excel / A0801_Excel 的重构)
将 Excel 数据导出的结构代码定义， 独立出来。
与 Model 数据类分离.
用户数据类不实现任何接口，仅仅存储基础数据。
Excel 格式的处理，由单独的类进行处理。







### A0803_Excel  
数据导入/导出 Excel 的例子 ( A0802_Excel 的 异步处理版本)
关于导出：
本例子代码是 结合  A0340_ThreadReadWrite  与  A0802_Excel 的综合处理.
通过多线程处理
Excel 导出作为  消费者线程来处理数据。
主线程产生数据， 提供给 Excel 导出处理。

关于导入：
本例子代码是结合 A0030_Event 与  A0802_Excel 的综合处理.
通过事件处理
当 Excel 读取到一定行数以后，触发事件给主线程处理。







### A0900_DllImport_StrCmpLogicalW  
使用 DllImport 引用 shlwapi.dll 中 StrCmpLogicalW 方法的例子  






### A1010_Print  
WinForm 环境下，页面设置/打印预览/打印 的例子  





### A1020_Hardware  
使用 System.Management 获取硬件信息的例子  




### A1021_CPU_Info  
使用 PerformanceCounter 获取 CPU 使用率的例子  




### A1030_SMS  
使用 System.IO.Ports.SerialPort  通过 手机 或者 GSM 模块， 发送短消息的例子   





### A1040_Password  
用于检查密码复杂度的一些处理代码。 





### A1050_Email 
通过  System.Net.Mail.MailMessage  构造电子邮件信息.
通过  SmtpClient  发送电子邮件的例子.





### A1055_log4net_Email 
通过配置  Log4Net， 通过电子邮件，发送日志信息的例子。  





### A1060_ImageProperty 
获取 照片的 拍摄时间、照相机、光圈、ISO、经纬度 等相关信息  






### A1070_Image_Process 
图片处理的相关例子， 包含  两张图片合并成一张，   图片缩放。  










### A3001_Office_Excel  
使用 Microsoft.Office.Interop.Excel 来 读写 Excel 的例子  




### A3002_Office_Outlook  
使用 Microsoft.Office.Interop.Outlook 来 读写地址簿, 发送邮件 的例子  







### A4001_DebugRelease  
Vs2010 中， 通过 “生成事件” 管理 app.Debug.config / app.Release.config 的例子。    




### A4001_PathAna  
Dijkstra算法 最短路径处理的例子代码  




### A4002_PI  
圆周率的计算 （用于实现一个比较耗 CPU 的处理）  





### A4005_Settings 
应用程序,修改当前 App.Config 的处理. 
















### A5010_WinPopForm  
WinForm 环境下， 弹出消息窗口 的例子  




### A5020_InputLanguage  
WinForm 环境下， 输入法切换 与  Caps Lock 检测的例子  






### A5030_Mouse_Event 
模拟鼠标移动、点击的处理逻辑  （相当于按键精灵的处理逻辑）   




### A5035_SendKeys 
模拟键盘按钮处理  





### A5040_MDI_SubForm 
MDI 应用程序中，子窗口唯一性的控制处理  





### A5050_UCbo 
WinForm 环境下， 模糊匹配下拉列表的例子  





### A5060_TwoScreen 

当计算机有2个屏幕的情况下， 程序自动把主窗口，定位在主屏幕上， 把子窗口，定位在第二个屏幕上的处理例子。






### A5070_CheckAbleComboBox 
WinForm 下面的 自定义控件， 用于显示 可 Check 的 ComboBox  





### A5080_ComboBoxWithImage 
WinForm 下面的 自定义控件， 用于显示 带图片显示 的 ComboBox
本项目涉及到的知识点, 还包含  根据大图片,  制作缩略图的处理.
以及 自定义控件中, 如何设置 自定义属性的 扩展的备注信息.







### A5090_MovablePanel 
WinForm 下面，通过 鼠标的事件， 实现 图片、Panel 拖动切换的效果.  





### A5100_WndProc 
消息处理的例子  




### A5110_WinFromObserver 
多个窗口,通过观察者的方式, 传递数据.  






### A5120_WebBrowser 
WebBrowser 运行过程中, 不弹 脚本错误对话框的处理
首先，要通过 浏览的方式， 添加引用 c:\windows\system32\shdocvw.dll





### A5121_WebBrowserHtmlText 
通过 WebBrowser 实现，  手头有  HTML 文本， 但是想获取最终显示的文本。







### A5125_WebWithAjax 
一个测试的网站，只有一个页面，数据通过 Ajax 来加载。 




### A5126_WebBrowserAjax 

WebBrowser 调用 js 方法的方式， 来获取画面上面的数据。






### A5150_PowerPacks 
使用 Microsoft.VisualBasic.PowerPacks 进行 画线,圆,矩形 的相关例子.  




### A5200_Chart 
使用 System.Windows.Forms.DataVisualization.Charting 绘制图表的例子  




### A6000_ImportExe_Main / A6010_ImportExe_Sub 

将一个 外部的 Exe, 嵌入到本程序的一个 Panel 里面。
普通 Exe 与 .NET 的 Exe ， 处理机制不同。





