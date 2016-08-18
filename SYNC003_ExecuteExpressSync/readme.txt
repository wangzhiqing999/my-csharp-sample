测试步骤:

1. 先运行  ProvisionServer.exe  搭建服务端环境


2. 再运行  ProvisionClient.exe  搭建客户端环境


3. 运行 ExecuteExpressSync.exe 首次同步


输出结果：
Start Time: 2014/12/19 14:29:40
Total Changes Uploaded: 0
Total Changes Downloaded: 3
Complete Time: 2014/12/19 14:29:42

客户端数据查询.

SELECT 
	[ID],[Name],[ListPrice]
FROM 
	[SyncExpressDB].[dbo].[Products]
GO

ID          Name                                               ListPrice
----------- -------------------------------------------------- ---------------------
1           PC                                                 400.00
2           Laptop                                             600.00
3           NetBook                                            300.00

(3 行受影响)



4. 测试服务端数据更新， 然后再同步到客户端.

INSERT INTO Products VALUES (4, 'iPad', 500);

(0 行受影响)

(1 行受影响)

(1 行受影响)



5. 再次运行 ExecuteExpressSync.exe 进行第二次同步

Start Time: 2014/12/19 14:34:54
Total Changes Uploaded: 0
Total Changes Downloaded: 1
Complete Time: 2014/12/19 14:34:55

客户端数据查询.

SELECT 
	[ID],[Name],[ListPrice]
FROM 
	[SyncExpressDB].[dbo].[Products]
GO

ID          Name                                               ListPrice
----------- -------------------------------------------------- ---------------------
1           PC                                                 400.00
2           Laptop                                             600.00
3           NetBook                                            300.00
4           iPad                                               500.00

(4 行受影响)



6. 尝试 客户端 插入 / 更新数据， 并 同步到 服务端.

INSERT INTO [SyncExpressDB].[dbo].[Products] VALUES (5, 'iPhone', 600);

UPDATE [SyncExpressDB].[dbo].[Products] SET Name = 'iPad Air' WHERE id = 4;
GO

(0 行受影响)

(1 行受影响)

(1 行受影响)

(1 行受影响)

(1 行受影响)




7. 再次运行 ExecuteExpressSync.exe 进行第三次同步.

Start Time: 2014/12/19 14:38:26
Total Changes Uploaded: 2
Total Changes Downloaded: 0
Complete Time: 2014/12/19 14:38:27


服务端核对数据.

SELECT TOP 1000 [ID]
      ,[Name]
      ,[ListPrice]
  FROM [SyncDB].[dbo].[Products]
GO

ID          Name                                               ListPrice
----------- -------------------------------------------------- ---------------------
1           PC                                                 400.00
2           Laptop                                             600.00
3           NetBook                                            300.00
4           iPad Air                                           500.00
5           iPhone                                             600.00

(5 行受影响)






