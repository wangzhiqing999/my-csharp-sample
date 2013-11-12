-- 如果当前数据库中,已经存在有表 test_sub_of_sub, 那么先删除掉.
IF EXISTS ( SELECT 1 FROM sys.tables WHERE name = 'test_sub_of_sub')  
  DROP TABLE test_sub_of_sub
GO

-- 如果当前数据库中,已经存在有表 test_sub_s, 那么先删除掉.
IF EXISTS ( SELECT 1 FROM sys.tables WHERE name = 'test_sub_s')  
  DROP TABLE test_sub_s
GO

-- 如果当前数据库中,已经存在有表 test_sub, 那么先删除掉.
IF EXISTS ( SELECT 1 FROM sys.tables WHERE name = 'test_sub')  
  DROP TABLE test_sub
GO

-- 如果当前数据库中,已经存在有表 test_main, 那么先删除掉.
IF EXISTS ( SELECT 1 FROM sys.tables WHERE name = 'test_main')  
  DROP TABLE test_main
GO



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
GO


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
GO


-- 外键约束
ALTER TABLE test_sub ADD CONSTRAINT fk_test_sub FOREIGN KEY (main_id) REFERENCES test_main;
GO

ALTER TABLE test_sub_s ADD CONSTRAINT fk_test_sub_s FOREIGN KEY (main_id) REFERENCES test_main;
GO

ALTER TABLE test_sub_of_sub ADD CONSTRAINT fk_test_sub_of_sub FOREIGN KEY (sub_main_id) REFERENCES test_sub_s;
GO






----------
-- 并发的 流水号测试.
----------

-- 如果当前数据库中,已经存在有表 test_sequence, 那么先删除掉.
IF EXISTS ( SELECT 1 FROM sys.tables WHERE name = 'test_sequence')  
  DROP TABLE test_sequence
GO


CREATE TABLE test_sequence (
	table_name 			VARCHAR(32) 	NOT NULL ,
	sequence_number 	INT 			NOT NULL 
	PRIMARY KEY(table_name) 
);
GO

INSERT INTO test_sequence VALUES ('test_main',  100);
INSERT INTO test_sequence VALUES ('test_sub',  100);
GO



----------
-- Many to Mang 关系测试.
----------

-- 如果当前数据库中,已经存在有表 test_score, 那么先删除掉.
IF EXISTS ( SELECT 1 FROM sys.tables WHERE name = 'test_score')  
  DROP TABLE test_score
GO

-- 如果当前数据库中,已经存在有表 test_course, 那么先删除掉.
IF EXISTS ( SELECT 1 FROM sys.tables WHERE name = 'test_course')  
  DROP TABLE test_course
GO


-- 如果当前数据库中,已经存在有表 test_student, 那么先删除掉.
IF EXISTS ( SELECT 1 FROM sys.tables WHERE name = 'test_student')  
  DROP TABLE test_student
GO



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
GO

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
GO


-- 外键约束
ALTER TABLE test_score ADD CONSTRAINT fk_test_score_student FOREIGN KEY (student_code) REFERENCES test_student;
ALTER TABLE test_score ADD CONSTRAINT fk_test_score_course FOREIGN KEY (course_code) REFERENCES test_course;
GO





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





----------
--  存储过程 测试.
----------
-- 如果当前数据库中,已经存在有存储过程 test_insert_main_sub, 那么先删除掉.
IF EXISTS ( SELECT 1 FROM sys.procedures WHERE name = 'test_insert_main_sub')  
  DROP PROCEDURE test_insert_main_sub
GO

CREATE PROCEDURE test_insert_main_sub (
	@main_val  	VARCHAR(10),
	@sub_val  	VARCHAR(10)
) AS
BEGIN

	DECLARE @main_id	INT,
			@sub_id		INT;

	SELECT 
		@main_id = sequence_number
	FROM 
		test_sequence
	WHERE
		table_name = 'test_main';

	UPDATE 
		test_sequence
	SET
		sequence_number = sequence_number + 1
	WHERE
		table_name = 'test_main';
		
		
	SELECT 
		@sub_id = sequence_number
	FROM 
		test_sequence
	WHERE
		table_name = 'test_sub';
	
	UPDATE 
		test_sequence
	SET
		sequence_number = sequence_number + 1
	WHERE
		table_name = 'test_sub';

	-- 先插入主表数据.
	INSERT INTO test_main (id, value) VALUES (@main_id, @main_val);

	-- 后插入子表数据.
	INSERT INTO test_sub (id, main_id, value) VALUES (@sub_id, @main_id, @sub_val);

END;
GO


-- 如果当前数据库中,已经存在有存储过程 test_remove_main_sub, 那么先删除掉.
IF EXISTS ( SELECT 1 FROM sys.procedures WHERE name = 'test_remove_main_sub')  
  DROP PROCEDURE test_remove_main_sub
GO

CREATE PROCEDURE test_remove_main_sub (
	@main_id  	INT
) AS
BEGIN

	-- 先删除子表数据.
	DELETE 
		test_sub 
	WHERE
		main_id = @main_id;

	-- 后删除主表数据.
	DELETE 
		test_main
	WHERE
		id = @main_id;

END;
GO




