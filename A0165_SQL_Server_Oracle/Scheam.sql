

-- 本项目用于测试, Oracle 与 SQL Server 的事务处理.
-- 首先， SQL Server 中有一个存储过程  test_SqlServer_Proc。  Oracle 中有一个存储过程  test_Oracle_Proc  。

-- 测试的 Case：
-- Case 1:
--   如果 test_SqlServer_Proc 执行失败， 回滚.  test_Oracle_Proc 将不执行。

-- Case 2:
--   如果 test_SqlServer_Proc 执行成功， test_Oracle_Proc 执行失败， 回滚 （Oracle 和 SQL Server 都回滚掉）.

-- Case 3:
--   如果 test_SqlServer_Proc 执行成功， test_Oracle_Proc 执行成功， 提交修改.



-------------------------------------------------
-- Orcle 的表与存储过程.
-------------------------------------------------
CREATE TABLE Test_Trans (
  id   INT,
  val  INT
);


CREATE OR REPLACE PROCEDURE test_Oracle_Proc (
  p_param  INT
) AS
BEGIN
  -- 首先插入一行
  INSERT INTO Test_Trans (id, val) VALUES(1, p_param);
  -- 如果参数 = 0， 那么抛异常.
  -- 用于测试 事务处理
  IF p_param = 0 THEN
    RAISE_APPLICATION_ERROR(-20000, '测试存储过程发生了异常!');
  END IF; 
END test_Oracle_Proc;
/


-------------------------------------------------
-- SQL Server 的表与存储过程
-------------------------------------------------
CREATE TABLE  Test_Trans (
  id   INT,
  val  INT
);
GO



CREATE PROCEDURE test_SqlServer_Proc
  @Param INT
AS
BEGIN
  -- 首先插入一行
  INSERT INTO Test_Trans (id, val) VALUES(1,  @Param);
  
  -- 如果参数 = 0， 那么抛异常.
  -- 用于测试 事务处理
  IF @Param = 0
  BEGIN
    RAISERROR('测试存储过程发生了异常！', 16, 1);
  END;
END;
go

