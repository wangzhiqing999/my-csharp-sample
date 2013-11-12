CREATE TABLE SALE_REPORT (
      SALE_DATE  DATETIME NOT NULL ,
      SALE_ITEM  VARCHAR(2) NOT NULL ,
      SALE_MONEY DECIMAL(10,2) NOT NULL
);

ALTER TABLE sale_report
  ADD CONSTRAINT pk_sale_report PRIMARY KEY(sale_date, sale_item);
  
  
DELIMITER //
CREATE PROCEDURE CreateReportData()
BEGIN
  DECLARE  v_begin_day  DATE;
  DECLARE  v_end_day  DATE;

  SET v_begin_day = STR_TO_DATE('2009-01-01', '%Y-%m-%d');
  SET v_end_day = STR_TO_DATE('2010-01-01', '%Y-%m-%d');

  WHILE v_begin_day < v_end_day DO
    INSERT INTO SALE_REPORT VALUES
      (v_begin_day,  'A',
          Year(v_begin_day) );
    INSERT INTO SALE_REPORT VALUES
      (v_begin_day,  'B',
          Month(v_begin_day) );
    INSERT INTO SALE_REPORT VALUES
      (v_begin_day,  'C',
          DAY(v_begin_day) );
    SET v_begin_day = DATE_ADD(v_begin_day, INTERVAL 1 DAY);
  END WHILE;
END;
//

DELIMITER ;


call CreateReportData();




/* 用于测试 调用存储过程  */


DELIMITER //
CREATE PROCEDURE HelloWorld2(
  IN vUserName VARCHAR(10),
  OUT vOutValue VARCHAR(10),
  INOUT vInOutValue VARCHAR(10))
BEGIN
  SELECT CONCAT('Hello ', vUserName);
  SET vOutValue = 'A';
  SET vInOutValue = 'B';
END//

DELIMITER ;




/* 用于测试 调用函数  */

DELIMITER //
CREATE FUNCTION HelloWorldFunc()
RETURNS VARCHAR(20)
BEGIN
  RETURN 'Hello World!';
END;
//

DELIMITER ;








DELIMITER //

CREATE DEFINER=`root`@`%` PROCEDURE testProc()
BEGIN
  SELECT 'Hello 1' AS A, 'World 1' AS B UNION ALL
  SELECT 'Hello 2' AS A, 'World 2' AS B;
END //

DELIMITER ;








/* 用于测试 UTF-8 的脚本  */

-- 创建数据库的时候, 指定字符集.
CREATE DATABASE test_utf8
  DEFAULT CHARACTER SET utf8 
  COLLATE utf8_general_ci;

/*
mysql> use test_utf8
Database changed
mysql> show variables like 'character%';
+--------------------------+----------------------------------------------------
-----+
| Variable_name            | Value
     |
+--------------------------+----------------------------------------------------
-----+
| character_set_client     | latin1
     |
| character_set_connection | latin1
     |
| character_set_database   | utf8
     |
| character_set_filesystem | binary
     |
| character_set_results    | latin1
     |
| character_set_server     | latin1
     |
| character_set_system     | utf8
     |
| character_sets_dir       | C:\Program Files\MySQL\MySQL Server 5.0\share\chars
ets\ |
+--------------------------+----------------------------------------------------
-----+
8 rows in set (0.00 sec)
*/


-- 创建表的时候, 指定字符集.
CREATE  TABLE  test_tab (
    id   	INT  AUTO_INCREMENT,
    value1  varchar(20),
	value2  nvarchar(20),
	PRIMARY KEY (id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*  
  处理 UTF8 的时候， C# 的连接字符串中，要加上  charset=utf8   
例如：
Server=192.168.56.101;Database=test_utf8;Uid=test_user;Pwd=testpassword; charset=utf8


注：
dos下不支持UTF8的显示.

*/



