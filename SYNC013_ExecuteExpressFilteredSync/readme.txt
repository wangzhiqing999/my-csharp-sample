测试步骤:

1. 先运行  ProvisionServerWithFilteredScope.exe  搭建服务端环境


2. 再运行  ProvisionFilteredScopeClient.exe  搭建客户端环境


3. 运行 ExecuteExpressFilteredSync.exe 首次同步


输出结果：
Start Time: 2014/12/19 15:26:18
Total Changes Uploaded: 0
Total Changes Downloaded: 2
Complete Time: 2014/12/19 15:26:19



客户端数据查询.

SELECT TOP 1000 [OrderID]
      ,[ProductID]
      ,[Quantity]
      ,[OriginState]
  FROM [SyncExpressDB].[dbo].[Orders]
GO

OrderID     ProductID   Quantity    OriginState
----------- ----------- ----------- -----------
1           1           2           NC
2           2           1           NC

(2 行受影响)




4. 测试服务端数据更新， 然后再同步到客户端.

INSERT INTO [SyncDB].[dbo].[Orders] VALUES (5, 1, 1, 'NC')
INSERT INTO [SyncDB].[dbo].[Orders] VALUES (6, 1, 1, 'WA')
INSERT INTO [SyncDB].[dbo].[Orders] VALUES (7, 1, 1, 'NC')
GO

(0 行受影响)

(1 行受影响)

(1 行受影响)

(0 行受影响)

(1 行受影响)

(1 行受影响)

(0 行受影响)

(1 行受影响)

(1 行受影响)



5. 再次运行 ExecuteExpressSync.exe 进行第二次同步

Start Time: 2014/12/19 15:31:57
Total Changes Uploaded: 0
Total Changes Downloaded: 2
Complete Time: 2014/12/19 15:31:57




客户端数据查询.

SELECT TOP 1000 [OrderID]
      ,[ProductID]
      ,[Quantity]
      ,[OriginState]
  FROM [SyncExpressDB].[dbo].[Orders]
GO

OrderID     ProductID   Quantity    OriginState
----------- ----------- ----------- -----------
1           1           2           NC
2           2           1           NC
5           1           1           NC
7           1           1           NC

(4 行受影响)








