## ABP 框架， 使用 EF 的例子.

步骤：

1.创建项目。
	类型: 控制台程序.
	.Net框架: 4.6.1


2.管理 NuGet 程序包。
	依次安装下列程序包:
	Abp
	Abp.EntityFramework


3.编写 Model 类.
	需要注意： Model 类需要 继承 Entity<主键的数据类型>


4.创建 DBContext
	需要注意： 继承的是  Abp.EntityFramework.AbpDbContext


5. 测试代码
	包含标准的 EntityFramework， 使用 DbContext 来操作的例子。
	以及使用 Abp.Domain.Repositories.IRepository 来操作的例子.

