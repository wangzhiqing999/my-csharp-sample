本项目， 为 EF Code First 在 MySQL 数据库下， 实现 [Timestamp] 的功能。


SQL Server 数据库下， 使用下面的方式， 进行处理。

/// <summary>
/// 数据行版本号
/// </summary>
[Display(Name ="数据行版本号")]
[Timestamp]
public byte[] RowVersion { get; set; }



但是， MySQL 下面， 会报错。

解决的办法。


步骤1. 使用下面的属性。

/// <summary>
/// 版本 （并发控制使用列）
/// </summary>
[Column("RowVersion")]
[Display(Name = "版本")]
public DateTime RowVersion { get; set; }



步骤2. DbContext 的 OnModelCreating 方法中， 增加下面的配置.

// 测试表时间戳.
modelBuilder.Entity<TestTable>()
	 .Property(p => p.RowVersion).IsConcurrencyToken()
	 .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);


步骤3. 到数据库去额外执行的SQL语句.

ALTER TABLE `test2`.`test_table`
	CHANGE COLUMN `RowVersion` `RowVersion` DATETIME(6) NOT NULL
	DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6);
