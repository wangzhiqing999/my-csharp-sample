

## EntityFramework + MySql 日常问题解决办法.





### 版本问题

日常工作中，长期使用的 版本是
EntityFramework 6.2.0
MySql.Data.Entity 6.9.12

然而，随着时间推移，直接在NuGet包管理器上， 搜索 MySql.Data.Entity ， 已经无法搜索到。
只能通过手动执行 Install-Package MySql.Data.Entity -Version 6.9.12  进行安装。


本例子已修改为使用
EntityFramework 6.4.4
MySql.Data.EntityFramework 8.0.26


修改 App.config 后
测试 Code First 没有问题。






### Unable to convert MySQL date/time value to System.DateTime 的问题.

原因：该字段（date/datetime）的值默认缺省值为：0000-00-00/0000-00-00 00:00:00,这样的数据读出来转换成System.DateTime时就会有问题；

解决办法：
可以通过修改数据库连接字符串，增加
Convert Zero Datetime=True;Allow Zero Datetime=True
来规避。







### 获取分组中， 最新的一行数据.

参考 TestGroup.cs 里面的处理.







### RowVersion

两个方案：

方案一：

新增一个 IRowVersion， 用于定义  并发控制的列。
参考 MyWorkContext.cs
覆盖 OnModelCreating() 方法，增加这个 RowVersion 的存储机制的处理。
覆盖 SaveChanges() 方法，增加存储时，对 RowVersion 额外设置数据的处理。


优点：
可移植性好， 写代码的时候，是 MySQL，万一后面要变更数据库了，不需要做修改的处理。

缺点：
代码多一点，需要覆盖 SaveChanges() 方法， 自己写 RowVersion 的处理逻辑。



方案二：

使用 [Column("row_version", TypeName= "TIMESTAMP")] 的机制。
参考 MyWork2Context.cs

优点：
代码修改得少，只需要在 RowVersion 列上加标签即可。

缺点：
如果发生数据库变更，例如，写代码的时候，是 MySQL， 运营发布的时候， 数据库变更为 SQL Server 什么的，那就尴尬了。







### 同一个数据库下， 多个 DbContext 的事务处理


参考 TestTwoContextInSameDB.cs 的处理.




