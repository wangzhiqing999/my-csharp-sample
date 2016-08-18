
-- 数据同步过程中，客户端，创建测试数据的脚本.

USE [master]
GO

IF EXISTS(SELECT name FROM sys.databases WHERE name = 'SyncExpressDB')
DROP DATABASE SyncExpressDB

CREATE DATABASE [SyncExpressDB] 
GO

