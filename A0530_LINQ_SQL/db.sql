-- 创建测试主表. ID 是主键.
CREATE TABLE TestMain (
	Id      INT,
	Value   VARCHAR(10),
	PRIMARY KEY(Id) 
);


-- 创建测试子表. 
CREATE TABLE TestSub (
	Id      INT,
	Main_id INT,
	Value   VARCHAR(10),
	PRIMARY KEY(Id) 
);


-- 插入测试主表数据.
INSERT INTO TestMain(id, value) VALUES (1, 'ONE');
INSERT INTO TestMain(id, value) VALUES (2, 'TWO');

-- 插入测试子表数据.
INSERT INTO TestSub(id, main_id, value) VALUES (1, 1, 'ONEONE');
INSERT INTO TestSub(id, main_id, value) VALUES (2, 2, 'TWOTWO');


-- 外键约束
ALTER TABLE TestSub ADD CONSTRAINT main_id_cons FOREIGN KEY (main_id) REFERENCES TestMain;






----------
--  Identity 测试.
----------


-- 如果当前数据库中,已经存在有表 test_Identity_tab, 那么先删除掉.
IF EXISTS ( SELECT 1 FROM sys.tables WHERE name = 'test_Identity_tab')  
  DROP TABLE test_Identity_tab
GO


-- 创建测试表. ID 是主键.  数据将由 Identity 方式自增.
CREATE TABLE test_Identity_tab (
	id      INT  identity(1, 1),
	value   VARCHAR(10),
	PRIMARY KEY(id) 
);
GO


-- 创建测试子表. 
CREATE TABLE test_Identity_tab_Sub (
	Id      INT  identity(1, 1),
	Main_id INT,
	Value   VARCHAR(10),
	PRIMARY KEY(Id) 
);


-- 外键约束
ALTER TABLE test_Identity_tab_Sub ADD CONSTRAINT fk_Identity_Sub_M FOREIGN KEY (main_id) REFERENCES test_Identity_tab;









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

