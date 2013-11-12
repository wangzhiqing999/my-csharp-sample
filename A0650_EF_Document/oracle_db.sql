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



COMMENT ON TABLE "TEST_MAIN" IS '测试主表'
/
COMMENT ON TABLE "TEST_SUB" IS '测试子表'
/


COMMENT ON COLUMN "TEST_MAIN"."ID" IS '测试主表编号'
/
COMMENT ON COLUMN "TEST_MAIN"."VALUE" IS '测试主表数值'
/


COMMENT ON COLUMN "TEST_SUB"."ID" IS '测试子表编号'
/
COMMENT ON COLUMN "TEST_SUB"."MAIN_ID" IS '测试主表编号'
/
COMMENT ON COLUMN "TEST_SUB"."VALUE" IS '测试子表数值'
/

