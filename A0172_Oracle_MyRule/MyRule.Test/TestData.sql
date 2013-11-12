

-- 部门类型.
INSERT INTO mr_dept_type (
	dept_type,	dept_type_desc,	status
) VALUES (
	'NORMAL',	'实体部门类型',	1
);


-- 部门.
INSERT INTO mr_dept (
	dept_code,	dept_type,	parent_code,
	dept_name,	status
)
SELECT  'OS_000',  'NORMAL',	NULL,   	'总公司',       1	FROM dual       UNION ALL
SELECT  'OS_010',  'NORMAL',	'OS_000',	'管理部',       1	FROM dual       UNION ALL
SELECT  'OS_020',  'NORMAL',	'OS_000',	'人事部',       1	FROM dual       UNION ALL
SELECT  'OS_030',  'NORMAL',	'OS_000',	'技术开发部',   1	FROM dual       UNION ALL
SELECT  'OS_040',  'NORMAL',	'OS_000',	'系统运行部',   1	FROM dual       UNION ALL
SELECT  'OS_050',  'NORMAL',	'OS_000',	'市场部',       1	FROM dual       UNION ALL
SELECT  'OS_031',  'NORMAL',	'OS_030',	'硬件组',       1	FROM dual       UNION ALL
SELECT  'OS_032',  'NORMAL',	'OS_030',	'软件组',       1	FROM dual       UNION ALL
SELECT  'OS_033',  'NORMAL',	'OS_030',	'核心组',       1	FROM dual;


-- 用户.
INSERT INTO mr_user (
	user_code,	user_name,	status
)
SELECT  'H00I001',  '张三',     1   FROM dual  UNION ALL
SELECT  'H00I002',  '李四',     1   FROM dual  UNION ALL
SELECT  'H00I003',  '王五',     1   FROM dual  UNION ALL
SELECT  'H00I004',  '赵六',     1   FROM dual  UNION ALL
SELECT  'H00I005',  '张Ａ',     1   FROM dual  UNION ALL
SELECT  'H00I006',  '李Ｂ',     1   FROM dual  UNION ALL
SELECT  'H00I007',  '王Ｃ',     1   FROM dual  UNION ALL
SELECT  'H00I008',  '赵Ｄ',     1   FROM dual;


-- 部门 - 用户关系.
INSERT INTO mr_dept_user (
    dept_code,	user_code
)
SELECT  'OS_000',   'H00I001'  FROM dual  UNION ALL
SELECT  'OS_010',   'H00I002'  FROM dual  UNION ALL
SELECT  'OS_020',   'H00I003'  FROM dual  UNION ALL
SELECT  'OS_030',   'H00I004'  FROM dual  UNION ALL
SELECT  'OS_040',   'H00I005'  FROM dual  UNION ALL
SELECT  'OS_050',   'H00I006'  FROM dual  UNION ALL
SELECT  'OS_031',   'H00I007'  FROM dual  UNION ALL
SELECT  'OS_032',   'H00I008'  FROM dual;



--------------------------------------------------------------------------------
--------------------------------------------------------------------------------
--------------------------------------------------------------------------------


-- 功能模块

INSERT INTO mr_module (
	module_code,	parent_code,	module_name,	status
)
SELECT  'M01',  NULL,   	'人事管理',         1   FROM dual	UNION  ALL
SELECT  'M02',  'M01',      '人事组织管理',     1   FROM dual	UNION  ALL
SELECT  'M03',  'M01',      '权限组织管理',     1   FROM dual	UNION  ALL
SELECT  'M04',  'M02',      '部门管理',         1   FROM dual	UNION  ALL
SELECT  'M05',  'M02',      '职位管理',         1   FROM dual	UNION  ALL
SELECT  'M06',  'M02',      '人员管理',         1   FROM dual	UNION  ALL
SELECT  'M07',  'M03',      '权限管理',         1   FROM dual	UNION  ALL
SELECT  'M08',  'M03',      '权限功能管理',     1   FROM dual	UNION  ALL
SELECT  'M09',  'M03',      '接口角色管理',     1   FROM dual;


-- 动作
INSERT INTO mr_action (
	action_code,	module_code,	action_name,
	default_rule,	status
)
SELECT  'A001',   'M04',  '查询部门', 1,  1  FROM dual	 UNION ALL
SELECT  'A002',   'M04',  '新增部门', 0,  1  FROM dual	 UNION ALL
SELECT  'A003',   'M04',  '编辑部门', 0,  1  FROM dual	 UNION ALL
SELECT  'A004',   'M04',  '删除部门', 0,  1  FROM dual	 UNION ALL
SELECT  'A005',   'M05',  '查询职位', 1,  1  FROM dual	 UNION ALL
SELECT  'A006',   'M05',  '新增职位', 0,  1  FROM dual	 UNION ALL
SELECT  'A007',   'M05',  '编辑职位', 0,  1  FROM dual	 UNION ALL
SELECT  'A008',   'M05',  '删除职位', 0,  1  FROM dual	 UNION ALL
SELECT  'A009',   'M06',  '查询人员', 1,  1  FROM dual	 UNION ALL
SELECT  'A010',   'M06',  '新增人员', 0,  1  FROM dual	 UNION ALL
SELECT  'A011',   'M06',  '编辑人员', 0,  1  FROM dual	 UNION ALL
SELECT  'A012',   'M06',  '删除人员', 0,  1  FROM dual;







----------------------------------------
-----   用户-模块关系 测试数据.      ----
----------------------------------------



INSERT INTO mr_user_module (
    user_code,
    module_code
)
SELECT  'H00I001',  'M01'	FROM dual   UNION ALL       -- 张三 : 人事管理（人事组织+权限管理） 全部功能
SELECT  'H00I002',  'M02'	FROM dual   UNION ALL       -- 李四 : 人事组织管理(部门+职位+人员) 全部功能
SELECT  'H00I003',  'M04'	FROM dual   UNION ALL       -- 王五 : 部门管理
SELECT  'H00I004',  'M07'	FROM dual                   -- 赵六 : 权限管理
;




----------------------------------------
-----   用户-模块动作关系 测试数据.  ----
----------------------------------------

INSERT INTO mr_user_action (
    user_code,
    action_code
)
SELECT  'H00I001',  'A002'	FROM  dual   UNION ALL       -- 张三 新增、编辑、删除 部门
SELECT  'H00I001',  'A003'	FROM  dual   UNION ALL
SELECT  'H00I001',  'A004'	FROM  dual   UNION ALL
SELECT  'H00I002',  'A003'	FROM  dual   UNION ALL       -- 李四 编辑、删除 部门
SELECT  'H00I002',  'A004'	FROM  dual   UNION ALL
SELECT  'H00I003',  'A003'	FROM  dual                   -- 王五 编辑 部门
;








----------------------------------------
-----   角色测试数据.               ----
----------------------------------------

INSERT INTO mr_role (
    role_code,
    role_name,
    status
)
SELECT  'R01',  '全部权限', 1  FROM dual    UNION
SELECT  'R02',  '只读权限', 1  FROM dual    UNION
SELECT  'R03',  '读写权限', 1  FROM dual;




----------------------------------------
-----   用户-角色关系 测试数据.      ----
----------------------------------------

INSERT INTO mr_user_role (
    user_code,
    role_code
)
SELECT  'H00I005',  'R01'	FROM dual   UNION ALL       -- 张Ａ : 全部权限
SELECT  'H00I006',  'R02'	FROM dual   UNION ALL       -- 李Ｂ : 只读权限
SELECT  'H00I007',  'R03'	FROM dual                   -- 王Ｃ : 读写权限
;






----------------------------------------
-----   角色-模块关系 测试数据.     ----
----------------------------------------
INSERT INTO mr_role_module (
    role_code,    module_code 
)
SELECT  'R01',  'M01'	FROM dual   UNION  ALL
SELECT  'R02',  'M02'	FROM dual   UNION  ALL
SELECT  'R03',  'M04'	FROM dual;





----------------------------------------
-----   角色-模块动作关系 测试数据.  ----
----------------------------------------
INSERT INTO mr_role_action (
    role_code,    action_code
)
SELECT  'R01',  'A001'  FROM  dual   UNION  ALL
SELECT  'R01',  'A002'  FROM  dual   UNION  ALL
SELECT  'R01',  'A003'  FROM  dual   UNION  ALL
SELECT  'R01',  'A004'  FROM  dual   UNION  ALL
SELECT  'R01',  'A005'  FROM  dual   UNION  ALL
SELECT  'R01',  'A006'  FROM  dual   UNION  ALL
SELECT  'R01',  'A007'  FROM  dual   UNION  ALL
SELECT  'R01',  'A008'  FROM  dual   UNION  ALL
SELECT  'R01',  'A009'  FROM  dual   UNION  ALL
SELECT  'R01',  'A010'  FROM  dual  UNION  ALL
SELECT  'R01',  'A011'  FROM  dual  UNION  ALL
SELECT  'R01',  'A012'  FROM  dual  UNION  ALL
SELECT  'R02',  'A001'  FROM  dual   UNION  ALL
SELECT  'R02',  'A005'  FROM  dual   UNION  ALL
SELECT  'R02',  'A009'  FROM  dual   UNION  ALL
SELECT  'R03',  'A001'  FROM  dual   UNION  ALL
SELECT  'R03',  'A003'  FROM  dual   UNION  ALL
SELECT  'R03',  'A005'  FROM  dual   UNION  ALL
SELECT  'R03',  'A007'  FROM  dual   UNION  ALL
SELECT  'R03',  'A009'  FROM  dual   UNION  ALL
SELECT  'R03',  'A011'  FROM  dual;




