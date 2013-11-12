/* SQL Server 建表语句  */ 
IF EXISTS(SELECT * FROM sys.Tables WHERE name='my_serial_number')
  DROP TABLE my_serial_number
go

CREATE TABLE my_serial_number(
  sn_id int IDENTITY(1,1)  NOT NULL ,
  sn_name nvarchar(20) NOT NULL ,
  sn_desc nvarchar(50),
  sn_howto nvarchar(20) NOT NULL ,
  sn_format nvarchar(50) NOT NULL ,
  sn_seq_max int NOT NULL  DEFAULT 9999,
  sn_seq_min int NOT NULL  DEFAULT 1,
  sn_seq_curr int NOT NULL  DEFAULT 1,
  sn_date_curr datetime,
  sn_curr_val nvarchar(50),
  sn_auto_close_date BIT
  CONSTRAINT PK_my_serial_number PRIMARY KEY(sn_id )
);
go

EXECUTE sp_addextendedproperty N'MS_Description', '流水号主表',  N'user',  N'dbo',  N'Table', N'my_serial_number', NULL, NULL;
go

EXECUTE sp_addextendedproperty   N'MS_Description', '流水号编号 主键(自增长)',   N'user',  N'dbo',  N'Table', N'my_serial_number', N'column' , N'sn_id';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '流水号名称',   N'user',  N'dbo',  N'Table', N'my_serial_number', N'column' , N'sn_name';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '流水号描述信息',   N'user',  N'dbo',  N'Table', N'my_serial_number', N'column' , N'sn_desc';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '流水号创建方式',   N'user',  N'dbo',  N'Table', N'my_serial_number', N'column' , N'sn_howto';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '流水号掩码信息',   N'user',  N'dbo',  N'Table', N'my_serial_number', N'column' , N'sn_format';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '流水号中序号的最大值',   N'user',  N'dbo',  N'Table', N'my_serial_number', N'column' , N'sn_seq_max';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '流水号中序号的最小值',   N'user',  N'dbo',  N'Table', N'my_serial_number', N'column' , N'sn_seq_min';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '流水号中序号的当前值',   N'user',  N'dbo',  N'Table', N'my_serial_number', N'column' , N'sn_seq_curr';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '流水号中序号的当前日期/时间',   N'user',  N'dbo',  N'Table', N'my_serial_number', N'column' , N'sn_date_curr';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '当前流水号',   N'user',  N'dbo',  N'Table', N'my_serial_number', N'column' , N'sn_curr_val';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '是否自动完成日期切换(自动的，当日期发生变化，序号自动重新回到1的处理)',   N'user',  N'dbo',  N'Table', N'my_serial_number', N'column' , N'sn_auto_close_date';
go



-- 名称要 唯一.
ALTER TABLE my_serial_number
   ADD CONSTRAINT un_my_serial_number
       UNIQUE (sn_name);






IF EXISTS(SELECT * FROM dbo.sysobjects WHERE
    xtype IN ('IF', 'TF', 'FN')
    AND OBJECTPROPERTY(id, N'IsMSShipped') = 0
    AND name='MySerialNumber_FormatVal')
  DROP FUNCTION MySerialNumber_FormatVal
GO


-- =============================================
-- Author:		Edward Wang
-- Description:	用于格式化序列号.
-- =============================================
CREATE FUNCTION MySerialNumber_FormatVal (
  @sn_format              NVARCHAR(50),     -- 流水号掩码信息
  @sn_date_curr           DATETIME,         -- 流水号中序号的当前日期/时间
  @sn_seq_curr            INT               -- 流水号中序号的当前值
) RETURNS NVARCHAR(50)
AS
BEGIN

  DECLARE
    @startIndex     INT,                    -- 开始索引.
    @finishIndex    INT,                    -- 结束索引.
    @seqLength      INT,                    -- 序列号长度.
    @seqString      NVARCHAR(50),           -- 准备用于替换的序列号信息
    @formatResult   NVARCHAR(50);           -- 预期结果.


  IF @sn_format IS NULL
  BEGIN
    -- 流水号掩码信息为空.
    RETURN NULL;
  END

  IF @sn_date_curr IS NULL
  BEGIN
    -- 流水号 当前日期/时间 为空.
    SET @sn_date_curr = GETDATE();
  END

  IF @sn_seq_curr IS NULL
  BEGIN
    -- 流水号 序号 为空.
    SET @sn_seq_curr = 1;
  END

  -- 首先简单设置 结果 = 格式
  SET @formatResult = @sn_format;



  -- 检测替换 年月日.
  IF CHARINDEX('[@Today:YYYYMMDD]', @formatResult)  > 0
  BEGIN
    SET @formatResult =
      REPLACE(  @formatResult,
                '[@Today:YYYYMMDD]',
                Convert(VARCHAR(8), @sn_date_curr,  112 )  );
  END

  -- 检测替换 年月.
  IF CHARINDEX('[@Today:YYYYMM]', @formatResult)  > 0
  BEGIN
    SET @formatResult =
      REPLACE(  @formatResult,
                '[@Today:YYYYMM]',
                Convert(VARCHAR(6), @sn_date_curr,  112 )  );
  END

  -- 检测替换 年.
  IF CHARINDEX('[@Today:YYYY]', @formatResult)  > 0
  BEGIN
    SET @formatResult =
      REPLACE(  @formatResult,
                '[@Today:YYYY]',
                Convert(VARCHAR(4), @sn_date_curr,  112 )  );
  END


  -- 定位 序列号 开始标志.
  SET @startIndex = CHARINDEX('[@Seq:', @formatResult);
  IF @startIndex > 0
  BEGIN
    -- 定位 序列号 结束标志.
    SET @finishIndex = CHARINDEX(']', @formatResult, @startIndex);
    IF @finishIndex > 0
    BEGIN
      -- 计算 [@Seq:0000] 信息中的 [ 与 ] 之间的 字符数.
      SET @seqLength = @finishIndex - @startIndex - 6;
      -- 获取准备用于替换的字符内容.
      SET @seqString = SUBSTRING(@formatResult, @startIndex, @seqLength + 7);
      -- 格式化 序号信息.
      SET @formatResult =
        REPLACE(@formatResult,
                @seqString,
                RIGHT(CAST(POWER(10, @seqLength) + @sn_seq_curr AS varchar(20)),@seqLength) );
    END
  END

  -- 返回.
  RETURN @formatResult;

END
GO


----------
-- SELECT
--   dbo.MySerialNumber_FormatVal( '[@Today:YYYYMMDD]_[@Seq:0000]', GETDATE(), 123) AS A1,
--   dbo.MySerialNumber_FormatVal( '[@Today:YYYYMM]_[@Seq:0000]', GETDATE(), 12) AS A2,
--   dbo.MySerialNumber_FormatVal( '[@Today:YYYY]_[@Seq:0000]', GETDATE(), 123) AS A3,
--   dbo.MySerialNumber_FormatVal( '[@Today:YYYYMMDD]_[@Seq:00]', GETDATE(), 123) AS A4,
--   dbo.MySerialNumber_FormatVal( '[@Today:YYYYMMDD]_[@Seq:]', GETDATE(), 123) AS A5
----------








IF EXISTS(SELECT * FROM sys.procedures WHERE name='MySerialNumber_CurrVal')
  DROP PROCEDURE MySerialNumber_CurrVal
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Edward Wang
-- Description:	用于获取 当前流水号
-- =============================================
CREATE PROCEDURE MySerialNumber_CurrVal
  @snName       NVARCHAR(20),               -- 流水号名称.
  @snResult     NVARCHAR(50)    OUTPUT      -- 当前流水号.
AS
BEGIN

  SET NOCOUNT ON;

  -- 查询数据.
  SELECT
    @snResult = sn_curr_val
  FROM
    my_serial_number
  WHERE
    sn_name = @snName;

  -- 如果没有检索到数据，那么需要返回错误.
  IF (@@ROWCOUNT = 0)
  BEGIN
    -- 流水号  不存在.
    RAISERROR(
        N'流水号(%s)不存在。',
        16,
        1,
        @snName);
    RETURN;
  END;

  -- 如果 流水号还没有初始化，那么需要返回错误.
  IF (@snResult IS NULL)
  BEGIN
    -- 流水号还没有初始化.
    RAISERROR(
        N'流水号(%s)尚未初始化，请先调用 NextVal 。',
        0,
        1,
        @snName);
    RETURN;
  END;

END
GO



-----
-- DECLARE
--   @RC int,
--   @id  INT,
--   @resultVal NVARCHAR(50);
-- BEGIN
--   SET @id = 100;
--   EXECUTE @RC = MySerialNumber_CurrVal @id, @resultVal OUTPUT;
--   PRINT @RC;
--   PRINT @resultVal;
-- END
-- GO
-----







IF EXISTS(SELECT * FROM sys.procedures WHERE name='MySerialNumber_NextVal')
  DROP PROCEDURE MySerialNumber_NextVal
GO

-- =============================================
-- Author:		Edward Wang
-- Description:	用于获取 下一个流水号
-- =============================================
CREATE PROCEDURE MySerialNumber_NextVal
  @snName       NVARCHAR(20),           -- 流水号名称.
  @snResult     NVARCHAR(50)    OUTPUT  -- 当前流水号.
AS
BEGIN

  DECLARE
    @sn_format              NVARCHAR(50),       -- 流水号掩码信息
    @sn_seq_max             INT,                -- 流水号中序号的最大值
    @sn_seq_min             INT,                -- 流水号中序号的最小值
    @sn_seq_curr            INT,                -- 流水号中序号的当前值
    @sn_date_curr           DATETIME,           -- 流水号中序号的当前日期/时间
    @sn_curr_val            NVARCHAR(50),       -- 当前流水号
    @sn_auto_close_date     BIT;                -- 是否自动完成日期切换(自动的，当日期发生变化，序号自动重新回到1的处理)

  SET NOCOUNT ON;

  SELECT
    @sn_format          = sn_format
    ,@sn_seq_max         = sn_seq_max
    ,@sn_seq_min         = sn_seq_min
    ,@sn_seq_curr        = sn_seq_curr
    ,@sn_date_curr       = sn_date_curr
    ,@sn_curr_val        = sn_curr_val
    ,@sn_auto_close_date = sn_auto_close_date
  FROM
    my_serial_number
  WHERE
    sn_name = @snName;


  -- 如果没有检索到数据，那么需要返回错误.
  IF (@@ROWCOUNT = 0)
  BEGIN
    -- 流水号 ID 不存在.
    RAISERROR(
        N'流水号(%s)不存在。',
        16,
        1,
        @snName);
    RETURN;
  END;



  IF (@sn_curr_val IS NULL)
  BEGIN
    -- 流水号还没有初始化.
    -- 不需要做比较处理.

    -- 设置 报表当前日期时间.
    SET @sn_date_curr = GETDATE();

    -- 格式化 流水号.
    SET @snResult =
      dbo.MySerialNumber_FormatVal(
        @sn_format,
        @sn_date_curr,
        @sn_seq_curr);

  END
  ELSE
  BEGIN
    -- 已经有了 当前流水号
    -- 可能需要做 对比的处理.
    IF ( @sn_auto_close_date = 1)
    BEGIN
      -- 需要自动调整日期.
      IF (dbo.MySerialNumber_FormatVal(@sn_format, GETDATE(), @sn_seq_curr)
            <> @sn_curr_val)
      BEGIN
        -- 如果 按照当前的日期时间， 计算上一次的 流水号
        -- 但是 发生结果不一致的情况
        -- 那么需要重置 流水号的 日期时间 并将 序号设置回到 1.

        SET @sn_date_curr = GETDATE();
        SET @sn_seq_curr = 1;
      END
      ELSE
      BEGIN
        -- 如果 按照当前的日期时间， 计算上一次的 流水号
        -- 如果结果是一致的
        -- 那么认为是 当前的日期， 与上次的计算日期，是在同一个范围内的
        -- 只需要简单 递增序号就可以了.
        SET @sn_seq_curr = @sn_seq_curr + 1;
      END
    END
    ELSE
    BEGIN
      -- 不需要自动调整.
      -- 流水号递增.
      SET @sn_seq_curr = @sn_seq_curr + 1;
    END

    IF (@sn_seq_curr > @sn_seq_max)
    BEGIN
      -- 序列号 大于 序列号的最大值.
      RAISERROR(
          N'流水号的序号超过了序号的最大值。',
          16,
          1);
      RETURN;
    END

    -- 格式化 流水号.
    SET @snResult =
      dbo.MySerialNumber_FormatVal(
        @sn_format,
        @sn_date_curr,
        @sn_seq_curr);

  END




  -- 更新 最新序列号 与 日期.
  UPDATE
    my_serial_number
  SET
    sn_seq_curr   = @sn_seq_curr,
    sn_date_curr  = @sn_date_curr,
    sn_curr_val   = @snResult
  WHERE
    sn_name = @snName;


END
GO





-----
-- INSERT INTO [my_serial_number]
--            ([sn_name]
--            ,[sn_desc]
--            ,[sn_howto]
--            ,[sn_format]
--            ,[sn_seq_max]
--            ,[sn_seq_min]
--            ,[sn_seq_curr]
--            ,[sn_auto_close_date])
--      VALUES
--            ('TEST_SEQ'
--            ,'测试流水号'
--            ,'Normal'
--            ,'X-[@Today:YYYYMMDD]_[@Seq:0000]'
--            ,9999
--            ,1
--            ,1
--            ,1)
-- GO
--
--


-- DECLARE
--   @RC int,
--   @resultVal NVARCHAR(50);
-- BEGIN
-- 
--   EXECUTE @RC = MySerialNumber_NextVal 'TEST_SEQ', @resultVal OUTPUT;
--   PRINT @RC;
--   PRINT @resultVal;
-- 
--   EXECUTE @RC = MySerialNumber_CurrVal 'TEST_SEQ', @resultVal OUTPUT;
--   PRINT @RC;
--   PRINT @resultVal;
-- END
-- GO

-----