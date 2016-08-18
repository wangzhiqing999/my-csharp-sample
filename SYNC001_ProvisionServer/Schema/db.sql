
-- 数据同步过程中，服务器端，创建测试数据/表的脚本.

USE [master]
GO

IF EXISTS(SELECT name FROM sys.databases WHERE name = 'SyncDB')
DROP DATABASE SyncDB

CREATE DATABASE [SyncDB] 
GO

USE [SyncDB]
GO


-- 测试 产品表.
CREATE TABLE [dbo].[Products](
[ID] [int] NOT NULL,
[Name] [nvarchar](50) NOT NULL,
[ListPrice] [money] NOT NULL,
      
      CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([ID] ASC)
)

GO


-- 测试 订单表.
CREATE TABLE [dbo].[Orders](
[OrderID] [int] NOT NULL,
[ProductID] [int] NOT NULL,
[Quantity] [int] NOT NULL,
[OriginState] [nvarchar](2) NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([OrderID] ASC,[ProductID] ASC)
)
GO

ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ID])
GO

ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Products]
GO

INSERT INTO Products VALUES (1, 'PC', 400)
INSERT INTO Products VALUES (2, 'Laptop', 600)
INSERT INTO Products VALUES (3, 'NetBook', 300)
INSERT INTO Orders VALUES (1, 1, 2, 'NC')
INSERT INTO Orders VALUES (2, 2, 1, 'NC')
INSERT INTO Orders VALUES (3, 1, 5, 'WA')
INSERT INTO Orders VALUES (3, 3, 10, 'WA')
INSERT INTO Orders VALUES (4, 2, 4, 'WA')
GO


