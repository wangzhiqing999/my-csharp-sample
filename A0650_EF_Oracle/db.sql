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


-- 插入测试主表数据.
INSERT INTO test_main(id, value) VALUES (1, 'ONE');
INSERT INTO test_main(id, value) VALUES (2, 'TWO');

-- 插入测试子表数据.
INSERT INTO test_sub(id, main_id, value) VALUES (1, 1, 'ONEONE');
INSERT INTO test_sub(id, main_id, value) VALUES (2, 2, 'TWOTWO');


-- 外键约束
ALTER TABLE test_sub ADD CONSTRAINT main_id_cons FOREIGN KEY (main_id) REFERENCES test_main;



----------
-- 并发的 流水号测试.
----------
CREATE TABLE test_sequence (
	table_name 			VARCHAR(32) 	NOT NULL ,
	sequence_number 	INT 			NOT NULL ,
	PRIMARY KEY(table_name) 
);

INSERT INTO test_sequence VALUES ('test_main',  100);
INSERT INTO test_sequence VALUES ('test_sub',  100);








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
ALTER TABLE test_score 
	ADD CONSTRAINT fk_test_score_student 
		FOREIGN KEY (student_code) 
			REFERENCES test_student;

ALTER TABLE test_score ADD CONSTRAINT fk_test_score_course FOREIGN KEY (course_code) REFERENCES test_course;








----------
--  SEQUENCE 测试.
----------

CREATE SEQUENCE SEQ_TEST_EF
	INCREMENT BY 1    -- 每次递增1
	START WITH 1       -- 从1开始
	NOMAXVALUE      -- 没有最大值
	MINVALUE 1       -- 最小值=1
	NOCYCLE      -- 不循环
;


-- 创建测试表. ID 是主键.  数据将由 触发器 从序列号中获取.
CREATE TABLE test_seq_tab (
	id      INT,
	value   VARCHAR(10),
	PRIMARY KEY(id) 
);


-- 触发器.
CREATE OR REPLACE TRIGGER "T_SEQ_TEST_EF" BEFORE INSERT
ON test_seq_tab FOR EACH ROW
BEGIN
	SELECT SEQ_TEST_EF.NEXTVAL INTO :NEW.id FROM DUAL;
END;
/






----------
--  存储过程 测试.
----------

CREATE OR REPLACE PROCEDURE "TEST_INSERT_MAIN_SUB" (
	p_main_val  	test_main.value%TYPE,
	p_sub_val  		test_sub.value%TYPE
) AS
	v_main_id	test_main.id%TYPE;
	v_sub_id	test_sub.id%TYPE;
BEGIN

	SELECT 
		sequence_number  INTO  v_main_id
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
		sequence_number  INTO  v_sub_id
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
	INSERT INTO test_main (id, value) VALUES ( v_main_id, p_main_val);

	-- 后插入子表数据.
	INSERT INTO test_sub (id, main_id, value) VALUES ( v_sub_id, v_main_id, p_sub_val);

END;
/


CREATE OR REPLACE PROCEDURE "TEST_REMOVE_MAIN_SUB" (
	p_main_id  	test_main.id%TYPE
) AS
BEGIN

	-- 先删除子表数据.
	DELETE 
		test_sub 
	WHERE
		main_id = p_main_id;

	-- 后删除主表数据.
	DELETE 
		test_main
	WHERE
		id = p_main_id;

END;
/





----------
--  手动执行 SQL 语句的测试.
--  这里仅仅是为了 验证  “手动执行 SQL 语句”  技术上的可行性。
----------


-- 这个表， 是用于模拟 sql 语句返回结果的  结构。 
-- 仅仅是一个 空壳， 不需要添加任何数据的。
CREATE TABLE QUERY_RESULT_MAIN_AND_SUB (
	id				INT,
	main_value		VARCHAR(10),
	sub_value		VARCHAR(10),
	PRIMARY KEY(id) 
);


-- 下面是 准备在 Entity Framework 中， 执行的 SQL 语句.
-- 需要注意， 每一列， 需要与 上面的那个 空壳的表的 字段相一致.
select
  s.id		as id,
  m.value 	as main_value, 
  s.value 	as sub_value
from
  test_main  m
    join test_sub  s
      on (m.id = s.main_id)


