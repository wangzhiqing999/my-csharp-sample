-- 创建数据库的时候, 指定字符集.
CREATE DATABASE test_utf8
  DEFAULT CHARACTER SET utf8 
  COLLATE utf8_general_ci;



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

CREATE PROCEDURE testProc()
BEGIN
  SELECT 'Hello 1' AS A, 'World 1' AS B UNION ALL
  SELECT 'Hello 2' AS A, 'World 2' AS B;
END //

DELIMITER ;


-- 由于在 开发环境中, 无法在 “添加函数导入”的窗口中， 选择存储过程名称 之后,  按 "获取列信息(G)" 的按钮.
-- 因为按那个  按钮， 将导致  “添加函数导入”的窗口 直接关闭。 最后无法函数导入.
-- 因此只好手工创建一个 空白的表格， 在 “添加函数导入”的窗口中， 返回以下内容的集合下面， 选择 “实体”， 然后再选择这个表.
CREATE TABLE TestProcResult (
	A	varchar(10),
	B	varchar(10),
	PRIMARY KEY (A,B)
);







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









-- 创建测试主表. ID 是主键.
CREATE TABLE test_main (
id      INT,
value   VARCHAR(10),
PRIMARY KEY(id) 
);


-- 创建测试子表. 
CREATE TABLE test_sub (
id      INT,
main_id INT,
value   VARCHAR(10),
PRIMARY KEY(id) 
);


-- 创建测试子表 (与前面的 test_sub 平级). 
CREATE TABLE test_sub_s (
id      INT,
main_id INT,
value   VARCHAR(10),
PRIMARY KEY(id) 
);


-- 创建测试子表  (该表是  子表的子表 ， 是 test_sub_s 的下一级 ). 
CREATE TABLE test_sub_of_sub (
id      INT,
sub_main_id INT,
value   VARCHAR(10),
PRIMARY KEY(id) 
);



-- 插入测试主表数据.
INSERT INTO test_main(id, value) VALUES (1, 'ONE');
INSERT INTO test_main(id, value) VALUES (2, 'TWO');
INSERT INTO test_main(id, value) VALUES (3, 'THREE');
INSERT INTO test_main(id, value) VALUES (4, 'FOUR');


-- 插入测试子表数据.
INSERT INTO test_sub(id, main_id, value) VALUES (1, 1, 'ONEONE');
INSERT INTO test_sub(id, main_id, value) VALUES (2, 2, 'TWOTWO');




-- 插入测试子表数据.
INSERT INTO test_sub_s(id, main_id, value) VALUES (1, 1, '一一');
INSERT INTO test_sub_s(id, main_id, value) VALUES (2, 2, '二二');
INSERT INTO test_sub_s(id, main_id, value) VALUES (3, 3, '三三');

-- 插入测试子表数据.
INSERT INTO test_sub_of_sub(id, sub_main_id, value) VALUES (1, 1, 'ONEONEONE');
INSERT INTO test_sub_of_sub(id, sub_main_id, value) VALUES (2, 2, 'TWOTWOTWO');



-- 外键约束
ALTER TABLE test_sub ADD CONSTRAINT fk_test_sub FOREIGN KEY (main_id) REFERENCES test_main(id);


ALTER TABLE test_sub_s ADD CONSTRAINT fk_test_sub_s FOREIGN KEY (main_id) REFERENCES test_main(id);


ALTER TABLE test_sub_of_sub ADD CONSTRAINT fk_test_sub_of_sub FOREIGN KEY (sub_main_id) REFERENCES test_sub_s(id);





----------
-- Many to Mang 关系测试.
----------


-- 学生.
CREATE TABLE test_student (
	student_code		INT 			NOT NULL ,
	student_name		VARCHAR(10) 	NOT NULL ,
	PRIMARY KEY(student_code) 
);

-- 课程.
CREATE TABLE test_course (
	course_code		INT 			NOT NULL ,
	course_name		VARCHAR(10) 	NOT NULL ,
	PRIMARY KEY(course_code) 
);

-- 成绩.
CREATE TABLE test_score (
	student_code		INT 			NOT NULL ,
	course_code			INT 			NOT NULL ,
	score_value			INT				NOT NULL ,
	PRIMARY KEY(student_code, course_code) 
);


INSERT INTO test_student VALUES (1, '张三');
INSERT INTO test_student VALUES (2, '李四');
INSERT INTO test_student VALUES (3, '王五');
INSERT INTO test_student VALUES (4, '赵六');



INSERT INTO test_course VALUES (1, '语文');
INSERT INTO test_course VALUES (2, '数学');
INSERT INTO test_course VALUES (3, '英语');



INSERT INTO test_score VALUES (1, 1, 81);
INSERT INTO test_score VALUES (2, 1, 82);
INSERT INTO test_score VALUES (3, 1, 83);
INSERT INTO test_score VALUES (4, 1, 84);

INSERT INTO test_score VALUES (1, 2, 91);
INSERT INTO test_score VALUES (2, 2, 92);
INSERT INTO test_score VALUES (3, 2, 93);
INSERT INTO test_score VALUES (4, 2, 94);



-- 外键约束
ALTER TABLE test_score ADD CONSTRAINT fk_test_score_student FOREIGN KEY (student_code) REFERENCES test_student(student_code);
ALTER TABLE test_score ADD CONSTRAINT fk_test_score_course FOREIGN KEY (course_code) REFERENCES test_course(course_code);



----------
--  AUTO_INCREMENT 测试.
----------



-- 创建测试表. ID 是主键.  数据将由 AUTO_INCREMENT 方式自增.
CREATE TABLE test_AUTO_INCREMENT_tab (
	id      INT  AUTO_INCREMENT,
	value   VARCHAR(10),
	PRIMARY KEY(id) 
);




