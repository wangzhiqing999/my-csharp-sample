
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 08/04/2012 15:04:35
-- Generated from EDMX file: E:\my-csharp-sample\A0650_EF_SqlServer\Sample\ModelFirst.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Test];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_STRATEGYTRANS_DETAIL]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TRANS_DETAILS] DROP CONSTRAINT [FK_STRATEGYTRANS_DETAIL];
GO
IF OBJECT_ID(N'[dbo].[FK_STOCKTRANS_DETAIL]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TRANS_DETAILS] DROP CONSTRAINT [FK_STOCKTRANS_DETAIL];
GO
IF OBJECT_ID(N'[dbo].[FK_TRANS_DETAILTRANS_RELATION_OPEN]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TRANS_RELATIONS] DROP CONSTRAINT [FK_TRANS_DETAILTRANS_RELATION_OPEN];
GO
IF OBJECT_ID(N'[dbo].[FK_TRANS_DETAILTRANS_RELATION_CLOSE]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TRANS_RELATIONS] DROP CONSTRAINT [FK_TRANS_DETAILTRANS_RELATION_CLOSE];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[STRATEGYS]', 'U') IS NOT NULL
    DROP TABLE [dbo].[STRATEGYS];
GO
IF OBJECT_ID(N'[dbo].[STOCKS]', 'U') IS NOT NULL
    DROP TABLE [dbo].[STOCKS];
GO
IF OBJECT_ID(N'[dbo].[TRANS_DETAILS]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TRANS_DETAILS];
GO
IF OBJECT_ID(N'[dbo].[TRANS_RELATIONS]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TRANS_RELATIONS];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'STRATEGYS'
CREATE TABLE [dbo].[STRATEGYS] (
    [STRATEGY_CODE] varchar(20)  NOT NULL,
    [STRATEGY_NAME] nvarchar(50)  NOT NULL,
    [STRATEGY_DESC] nvarchar(200)  NULL
);
GO

-- Creating table 'STOCKS'
CREATE TABLE [dbo].[STOCKS] (
    [STOCK_CODE] varchar(20)  NOT NULL,
    [STOCK_NAME] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'TRANS_DETAILS'
CREATE TABLE [dbo].[TRANS_DETAILS] (
    [TRANS_ID] int IDENTITY(1,1) NOT NULL,
    [STRATEGY_CODE] varchar(20)  NOT NULL,
    [STOCK_CODE] varchar(20)  NOT NULL,
    [TRANS_DATETIME] datetime  NOT NULL,
    [TRANS_DIRECTION] nvarchar(1)  NOT NULL,
    [TRANS_TYPE] nvarchar(1)  NOT NULL,
    [TRANS_VOLUME] int  NOT NULL,
    [TRANS_PRICE] decimal(12,2)  NOT NULL,
    [PROFIT_POINT] decimal(8,2)  NULL,
    [PROFIT_AMOUNT] decimal(12,2)  NULL
);
GO

-- Creating table 'TRANS_RELATIONS'
CREATE TABLE [dbo].[TRANS_RELATIONS] (
    [OPEN_TRANS_ID] int  NOT NULL,
    [CLOSE_TRANS_ID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [STRATEGY_CODE] in table 'STRATEGYS'
ALTER TABLE [dbo].[STRATEGYS]
ADD CONSTRAINT [PK_STRATEGYS]
    PRIMARY KEY CLUSTERED ([STRATEGY_CODE] ASC);
GO

-- Creating primary key on [STOCK_CODE] in table 'STOCKS'
ALTER TABLE [dbo].[STOCKS]
ADD CONSTRAINT [PK_STOCKS]
    PRIMARY KEY CLUSTERED ([STOCK_CODE] ASC);
GO

-- Creating primary key on [TRANS_ID] in table 'TRANS_DETAILS'
ALTER TABLE [dbo].[TRANS_DETAILS]
ADD CONSTRAINT [PK_TRANS_DETAILS]
    PRIMARY KEY CLUSTERED ([TRANS_ID] ASC);
GO

-- Creating primary key on [OPEN_TRANS_ID], [CLOSE_TRANS_ID] in table 'TRANS_RELATIONS'
ALTER TABLE [dbo].[TRANS_RELATIONS]
ADD CONSTRAINT [PK_TRANS_RELATIONS]
    PRIMARY KEY NONCLUSTERED ([OPEN_TRANS_ID], [CLOSE_TRANS_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [STRATEGY_CODE] in table 'TRANS_DETAILS'
ALTER TABLE [dbo].[TRANS_DETAILS]
ADD CONSTRAINT [FK_STRATEGYTRANS_DETAIL]
    FOREIGN KEY ([STRATEGY_CODE])
    REFERENCES [dbo].[STRATEGYS]
        ([STRATEGY_CODE])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_STRATEGYTRANS_DETAIL'
CREATE INDEX [IX_FK_STRATEGYTRANS_DETAIL]
ON [dbo].[TRANS_DETAILS]
    ([STRATEGY_CODE]);
GO

-- Creating foreign key on [STOCK_CODE] in table 'TRANS_DETAILS'
ALTER TABLE [dbo].[TRANS_DETAILS]
ADD CONSTRAINT [FK_STOCKTRANS_DETAIL]
    FOREIGN KEY ([STOCK_CODE])
    REFERENCES [dbo].[STOCKS]
        ([STOCK_CODE])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_STOCKTRANS_DETAIL'
CREATE INDEX [IX_FK_STOCKTRANS_DETAIL]
ON [dbo].[TRANS_DETAILS]
    ([STOCK_CODE]);
GO

-- Creating foreign key on [OPEN_TRANS_ID] in table 'TRANS_RELATIONS'
ALTER TABLE [dbo].[TRANS_RELATIONS]
ADD CONSTRAINT [FK_TRANS_DETAILTRANS_RELATION_OPEN]
    FOREIGN KEY ([OPEN_TRANS_ID])
    REFERENCES [dbo].[TRANS_DETAILS]
        ([TRANS_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [CLOSE_TRANS_ID] in table 'TRANS_RELATIONS'
ALTER TABLE [dbo].[TRANS_RELATIONS]
ADD CONSTRAINT [FK_TRANS_DETAILTRANS_RELATION_CLOSE]
    FOREIGN KEY ([CLOSE_TRANS_ID])
    REFERENCES [dbo].[TRANS_DETAILS]
        ([TRANS_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TRANS_DETAILTRANS_RELATION_CLOSE'
CREATE INDEX [IX_FK_TRANS_DETAILTRANS_RELATION_CLOSE]
ON [dbo].[TRANS_RELATIONS]
    ([CLOSE_TRANS_ID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------