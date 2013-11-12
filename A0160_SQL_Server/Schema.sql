-- 建表
CREATE TABLE sale_report (
     sale_date  DATETIME NOT NULL ,
     sale_item  VARCHAR(2) NOT NULL ,
     sale_money DECIMAL(10,2) NOT NULL,
     PRIMARY KEY(sale_date, sale_item)
)
go



-- 测试数据
DECLARE
  @v_begin_day DATETIME, @v_end_day DATETIME;
BEGIN
  SET @v_begin_day = '2009-01-01';
  SET @v_end_day = '2010-01-01';

  WHILE @v_begin_day < @v_end_day
  BEGIN
    INSERT INTO SALE_REPORT VALUES(@v_begin_day,  'A',   YEAR(@v_begin_day) )

     INSERT INTO SALE_REPORT VALUES(@v_begin_day,  'B',   MONTH(@v_begin_day) )

     INSERT INTO SALE_REPORT VALUES(@v_begin_day,  'C',   DAY(@v_begin_day) )

     SET @v_begin_day = @v_begin_day + 1;
   END;
END;
go



-- 测试函数
CREATE FUNCTION HelloWorldFunc()
RETURNS VARCHAR(20)
AS
BEGIN
  RETURN 'Hello World!';
END
go


-- 测试返回结果集函数
CREATE FUNCTION getHelloWorld()
RETURNS TABLE
AS
RETURN
  SELECT 'Hello' AS A, 'World' AS B;
GO



-- 测试存储过程
CREATE PROCEDURE HelloWorld2
  @UserName VARCHAR(10),
  @OutVal   VARCHAR(10) OUTPUT,
  @InoutVal VARCHAR(20) OUTPUT
AS
BEGIN
  SET @OutVal = 'A';
  SET @InoutVal = @UserName + @InoutVal;
END;
go



-- 测试返回结果集的存储过程
CREATE PROCEDURE testProc
AS
BEGIN
  SELECT 'Hello 1' AS A, 'World 1' AS B UNION ALL
  SELECT 'Hello 2' AS A, 'World 2' AS B;
END

go


-- 测试存储过程
CREATE PROCEDURE HelloWorldLongTime
  @UserName VARCHAR(10),
  @OutVal   VARCHAR(10) OUTPUT,
  @InoutVal VARCHAR(20) OUTPUT
AS
BEGIN
  -- 模拟一个长时间的处理
  -- 时间为5分钟.
  WAITFOR DELAY '00:05:00';
  SET @OutVal = 'A';
  SET @InoutVal = @UserName + @InoutVal;

END;
go




-- 测试 identity 列.
CREATE TABLE test_SCOPE_IDENTITY (
  id   int IDENTITY(1,1) PRIMARY KEY,
  val VARCHAR(10)
)
go



-- 测试 二进制数据的存储.
CREATE TABLE Test_BinData (
  Test_Name    varchar(10)  PRIMARY KEY,
  Test_Data    varbinary(MAX)
);
