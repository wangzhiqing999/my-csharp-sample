-- 建表
CREATE TABLE sale_report (
     sale_date  DATE NOT NULL ,
     sale_item  VARCHAR(2) NOT NULL ,
     sale_money DECIMAL(10,2) NOT NULL,
     PRIMARY KEY(sale_date, sale_item)
);


-- 测试数据
DECLARE
  v_begin_day DATE;
  v_end_day DATE;
BEGIN
  v_begin_day := TO_DATE('2009-01-01', 'YYYY-MM-DD');
  v_end_day   := TO_DATE('2010-01-01', 'YYYY-MM-DD');

  WHILE v_begin_day < v_end_day LOOP
    INSERT INTO SALE_REPORT VALUES(v_begin_day,  'A',   1 );
    INSERT INTO SALE_REPORT VALUES(v_begin_day,  'B',   2 );
    INSERT INTO SALE_REPORT VALUES(v_begin_day,  'C',   3 );
    v_begin_day := v_begin_day + 1;
  END LOOP;
END;
/

-- 测试函数
CREATE OR REPLACE FUNCTION HelloWorldFunc
RETURN VARCHAR2
AS
BEGIN
  RETURN 'Hello World!';
END;
/

-- 测试存储过程
CREATE OR REPLACE PROCEDURE HelloWorld2 (
  p_user_name IN     VARCHAR2,
  p_out_val   OUT    VARCHAR2,
  p_inout_val IN OUT VARCHAR2
) AS
BEGIN
   dbms_output.put_line('Hello ' || p_user_name || p_inout_val || '!');
   p_out_val := 'A';
   p_inout_val := 'B';
END HelloWorld2;
/

-- 测试返回结果集的函数
create or replace package pkg_HelloWorld as
  -- 定义ref cursor类型
  type myrctype is ref cursor;
  --函数申明
  function getHelloWorld return myrctype;
end pkg_HelloWorld;
/

CREATE OR REPLACE package body pkg_HelloWorld as
  function getHelloWorld return myrctype
  IS
    return_cursor  myrctype;
  BEGIN
    OPEN return_cursor FOR 'SELECT ''Hello'' AS a, ''World'' AS B FROM dual';
    return return_cursor;
  END getHelloWorld;
end pkg_HelloWorld;
/
