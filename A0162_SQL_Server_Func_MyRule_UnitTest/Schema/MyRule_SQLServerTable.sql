/* SQL Server 建表语句  */
IF EXISTS(SELECT * FROM sys.Tables WHERE name='mr_permission')
  DROP TABLE mr_permission
go

CREATE TABLE mr_permission(
  permission_id int NOT NULL ,
  permission_name nvarchar(20) NOT NULL ,
  permission_desc nvarchar(100)
  CONSTRAINT PK_mr_permission PRIMARY KEY(permission_id )
);
go

EXECUTE sp_addextendedproperty N'MS_Description', '权限表',  N'user',  N'dbo',  N'Table', N'mr_permission', NULL, NULL;
go

EXECUTE sp_addextendedproperty   N'MS_Description', '权限编号(位运算，只有 1,2,4,8...)',   N'user',  N'dbo',  N'Table', N'mr_permission', N'column' , N'permission_id';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '权限名',   N'user',  N'dbo',  N'Table', N'mr_permission', N'column' , N'permission_name';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '权限描述',   N'user',  N'dbo',  N'Table', N'mr_permission', N'column' , N'permission_desc';
go








/* SQL Server 建表语句  */
IF EXISTS(SELECT * FROM sys.Tables WHERE name='mr_dept_type')
  DROP TABLE mr_dept_type
go

CREATE TABLE mr_dept_type(
  dept_type varchar(10) NOT NULL ,
  dept_type_desc nvarchar(100),
  up_recursive_able bit NOT NULL ,
  down_recursive_able bit NOT NULL ,
  status smallint NOT NULL  DEFAULT 1
  CONSTRAINT PK_mr_dept_type PRIMARY KEY(dept_type )
);
go

EXECUTE sp_addextendedproperty N'MS_Description', '部门',  N'user',  N'dbo',  N'Table', N'mr_dept_type', NULL, NULL;
go

EXECUTE sp_addextendedproperty   N'MS_Description', '部门类型',   N'user',  N'dbo',  N'Table', N'mr_dept_type', N'column' , N'dept_type';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '部门类型描述',   N'user',  N'dbo',  N'Table', N'mr_dept_type', N'column' , N'dept_type_desc';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '是否允许向上递归 ',   N'user',  N'dbo',  N'Table', N'mr_dept_type', N'column' , N'up_recursive_able';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '是否允许向下递归',   N'user',  N'dbo',  N'Table', N'mr_dept_type', N'column' , N'down_recursive_able';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '状态',   N'user',  N'dbo',  N'Table', N'mr_dept_type', N'column' , N'status';
go








/* SQL Server 建表语句  */
IF EXISTS(SELECT * FROM sys.Tables WHERE name='mr_dept')
  DROP TABLE mr_dept
go

CREATE TABLE mr_dept(
  dept_id int IDENTITY(1,1)  NOT NULL ,
  parent_id int,
  dept_name nvarchar(20) NOT NULL ,
  dept_type varchar(10) NOT NULL ,
  status smallint NOT NULL  DEFAULT 1
  CONSTRAINT PK_mr_dept PRIMARY KEY(dept_id )
);
go

EXECUTE sp_addextendedproperty N'MS_Description', '部门',  N'user',  N'dbo',  N'Table', N'mr_dept', NULL, NULL;
go

EXECUTE sp_addextendedproperty   N'MS_Description', '主键(自增长)',   N'user',  N'dbo',  N'Table', N'mr_dept', N'column' , N'dept_id';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '上级部门编号',   N'user',  N'dbo',  N'Table', N'mr_dept', N'column' , N'parent_id';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '部门名',   N'user',  N'dbo',  N'Table', N'mr_dept', N'column' , N'dept_name';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '部门类型(实体部门、虚拟部门、城市等)',   N'user',  N'dbo',  N'Table', N'mr_dept', N'column' , N'dept_type';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '状态',   N'user',  N'dbo',  N'Table', N'mr_dept', N'column' , N'status';
go

ALTER TABLE mr_dept ADD CONSTRAINT FK_mr_dept_parent_id  FOREIGN KEY (parent_id)  REFERENCES  mr_dept
go









/* SQL Server 建表语句  */
IF EXISTS(SELECT * FROM sys.Tables WHERE name='mr_user')
  DROP TABLE mr_user
go

CREATE TABLE mr_user(
  user_id int IDENTITY(1,1)  NOT NULL ,
  user_name nvarchar(20) NOT NULL ,
  status smallint NOT NULL  DEFAULT 1
  CONSTRAINT PK_mr_user PRIMARY KEY(user_id )
);
go

EXECUTE sp_addextendedproperty N'MS_Description', '用户',  N'user',  N'dbo',  N'Table', N'mr_user', NULL, NULL;
go

EXECUTE sp_addextendedproperty   N'MS_Description', '主键(自增长)',   N'user',  N'dbo',  N'Table', N'mr_user', N'column' , N'user_id';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '用户名',   N'user',  N'dbo',  N'Table', N'mr_user', N'column' , N'user_name';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '状态',   N'user',  N'dbo',  N'Table', N'mr_user', N'column' , N'status';
go







/* SQL Server 建表语句  */
IF EXISTS(SELECT * FROM sys.Tables WHERE name='mr_dept_user')
  DROP TABLE mr_dept_user
go

CREATE TABLE mr_dept_user(
  dept_id int NOT NULL ,
  user_id int NOT NULL ,
  permission_data int NOT NULL  DEFAULT 1
  CONSTRAINT PK_mr_dept_user PRIMARY KEY(dept_id, user_id )
);
go

EXECUTE sp_addextendedproperty N'MS_Description', '部门-用户关系',  N'user',  N'dbo',  N'Table', N'mr_dept_user', NULL, NULL;
go

EXECUTE sp_addextendedproperty   N'MS_Description', '部门编号',   N'user',  N'dbo',  N'Table', N'mr_dept_user', N'column' , N'dept_id';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '用户编号',   N'user',  N'dbo',  N'Table', N'mr_dept_user', N'column' , N'user_id';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '权限数据（使用位运算处理）',   N'user',  N'dbo',  N'Table', N'mr_dept_user', N'column' , N'permission_data';
go

ALTER TABLE mr_dept_user ADD CONSTRAINT FK_mr_dept_user_dept_id  FOREIGN KEY (dept_id)  REFERENCES  mr_dept
go

ALTER TABLE mr_dept_user ADD CONSTRAINT FK_mr_dept_user_user_id  FOREIGN KEY (user_id)  REFERENCES  mr_user
go








/* SQL Server 建表语句  */
IF EXISTS(SELECT * FROM sys.Tables WHERE name='mr_module')
  DROP TABLE mr_module
go

CREATE TABLE mr_module(
  module_id int IDENTITY(1,1)  NOT NULL ,
  parent_id int,
  module_name nvarchar(20) NOT NULL ,
  status smallint NOT NULL  DEFAULT 1
  CONSTRAINT PK_mr_module PRIMARY KEY(module_id )
);
go

EXECUTE sp_addextendedproperty N'MS_Description', '功能模块',  N'user',  N'dbo',  N'Table', N'mr_module', NULL, NULL;
go

EXECUTE sp_addextendedproperty   N'MS_Description', '主键(自增长)',   N'user',  N'dbo',  N'Table', N'mr_module', N'column' , N'module_id';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '父模块编号',   N'user',  N'dbo',  N'Table', N'mr_module', N'column' , N'parent_id';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '模块名称',   N'user',  N'dbo',  N'Table', N'mr_module', N'column' , N'module_name';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '状态',   N'user',  N'dbo',  N'Table', N'mr_module', N'column' , N'status';
go

ALTER TABLE mr_module ADD CONSTRAINT FK_mr_module_parent_id  FOREIGN KEY (parent_id)  REFERENCES  mr_module
go







/* SQL Server 建表语句  */
IF EXISTS(SELECT * FROM sys.Tables WHERE name='mr_action')
  DROP TABLE mr_action
go

CREATE TABLE mr_action(
  action_id int IDENTITY(1,1)  NOT NULL ,
  module_id int NOT NULL ,
  action_name nvarchar(20) NOT NULL ,
  default_rule tinyint NOT NULL  DEFAULT 0,
  status smallint NOT NULL  DEFAULT 1
  CONSTRAINT PK_mr_action PRIMARY KEY(action_id )
);
go

EXECUTE sp_addextendedproperty N'MS_Description', '模块动作',  N'user',  N'dbo',  N'Table', N'mr_action', NULL, NULL;
go

EXECUTE sp_addextendedproperty   N'MS_Description', '主键(自增长)',   N'user',  N'dbo',  N'Table', N'mr_action', N'column' , N'action_id';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '模块编号',   N'user',  N'dbo',  N'Table', N'mr_action', N'column' , N'module_id';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '模块名称',   N'user',  N'dbo',  N'Table', N'mr_action', N'column' , N'action_name';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '默认可用标志',   N'user',  N'dbo',  N'Table', N'mr_action', N'column' , N'default_rule';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '状态',   N'user',  N'dbo',  N'Table', N'mr_action', N'column' , N'status';
go

ALTER TABLE mr_action ADD CONSTRAINT FK_mr_action_module_id  FOREIGN KEY (module_id)  REFERENCES  mr_module
go








/* SQL Server 建表语句  */
IF EXISTS(SELECT * FROM sys.Tables WHERE name='mr_user_module')
  DROP TABLE mr_user_module
go

CREATE TABLE mr_user_module(
  user_id int NOT NULL ,
  module_id int NOT NULL
  CONSTRAINT PK_mr_user_module PRIMARY KEY(user_id, module_id )
);
go

EXECUTE sp_addextendedproperty N'MS_Description', '用户-模块关系',  N'user',  N'dbo',  N'Table', N'mr_user_module', NULL, NULL;
go

EXECUTE sp_addextendedproperty   N'MS_Description', '用户编号',   N'user',  N'dbo',  N'Table', N'mr_user_module', N'column' , N'user_id';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '模块编号',   N'user',  N'dbo',  N'Table', N'mr_user_module', N'column' , N'module_id';
go

ALTER TABLE mr_user_module ADD CONSTRAINT FK_mr_user_module_user_id  FOREIGN KEY (user_id)  REFERENCES  mr_user
go

ALTER TABLE mr_user_module ADD CONSTRAINT FK_mr_user_module_module_id  FOREIGN KEY (module_id)  REFERENCES  mr_module
go







/* SQL Server 建表语句  */
IF EXISTS(SELECT * FROM sys.Tables WHERE name='mr_user_action')
  DROP TABLE mr_user_action
go

CREATE TABLE mr_user_action(
  user_id int NOT NULL ,
  action_id int NOT NULL
  CONSTRAINT PK_mr_user_action PRIMARY KEY(user_id, action_id )
);
go

EXECUTE sp_addextendedproperty N'MS_Description', '用户-动作关系',  N'user',  N'dbo',  N'Table', N'mr_user_action', NULL, NULL;
go

EXECUTE sp_addextendedproperty   N'MS_Description', '用户编号',   N'user',  N'dbo',  N'Table', N'mr_user_action', N'column' , N'user_id';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '动作编号',   N'user',  N'dbo',  N'Table', N'mr_user_action', N'column' , N'action_id';
go

ALTER TABLE mr_user_action ADD CONSTRAINT FK_mr_user_action_user_id  FOREIGN KEY (user_id)  REFERENCES  mr_user
go

ALTER TABLE mr_user_action ADD CONSTRAINT FK_mr_user_action_action_id  FOREIGN KEY (action_id)  REFERENCES  mr_action
go








/* SQL Server 建表语句  */
IF EXISTS(SELECT * FROM sys.Tables WHERE name='mr_role')
  DROP TABLE mr_role
go

CREATE TABLE mr_role(
  role_id int IDENTITY(1,1)  NOT NULL ,
  role_name nvarchar(20) NOT NULL ,
  status smallint NOT NULL  DEFAULT 1
  CONSTRAINT PK_mr_role PRIMARY KEY(role_id )
);
go

EXECUTE sp_addextendedproperty N'MS_Description', '角色',  N'user',  N'dbo',  N'Table', N'mr_role', NULL, NULL;
go

EXECUTE sp_addextendedproperty   N'MS_Description', '主键(自增长)',   N'user',  N'dbo',  N'Table', N'mr_role', N'column' , N'role_id';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '角色名称',   N'user',  N'dbo',  N'Table', N'mr_role', N'column' , N'role_name';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '状态',   N'user',  N'dbo',  N'Table', N'mr_role', N'column' , N'status';
go








/* SQL Server 建表语句  */
IF EXISTS(SELECT * FROM sys.Tables WHERE name='mr_user_role')
  DROP TABLE mr_user_role
go

CREATE TABLE mr_user_role(
  user_id int NOT NULL ,
  role_id int NOT NULL
  CONSTRAINT PK_mr_user_role PRIMARY KEY(user_id, role_id )
);
go

EXECUTE sp_addextendedproperty N'MS_Description', '用户-角色关系',  N'user',  N'dbo',  N'Table', N'mr_user_role', NULL, NULL;
go

EXECUTE sp_addextendedproperty   N'MS_Description', '用户编号',   N'user',  N'dbo',  N'Table', N'mr_user_role', N'column' , N'user_id';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '角色编号',   N'user',  N'dbo',  N'Table', N'mr_user_role', N'column' , N'role_id';
go

ALTER TABLE mr_user_role ADD CONSTRAINT FK_mr_user_role_user_id  FOREIGN KEY (user_id)  REFERENCES  mr_user
go

ALTER TABLE mr_user_role ADD CONSTRAINT FK_mr_user_role_role_id  FOREIGN KEY (role_id)  REFERENCES  mr_role
go






/* SQL Server 建表语句  */
IF EXISTS(SELECT * FROM sys.Tables WHERE name='mr_role_module')
  DROP TABLE mr_role_module
go

CREATE TABLE mr_role_module(
  role_id int NOT NULL ,
  module_id int NOT NULL
  CONSTRAINT PK_mr_role_module PRIMARY KEY(role_id, module_id )
);
go

EXECUTE sp_addextendedproperty N'MS_Description', '角色-模块关系',  N'user',  N'dbo',  N'Table', N'mr_role_module', NULL, NULL;
go

EXECUTE sp_addextendedproperty   N'MS_Description', '角色编号',   N'user',  N'dbo',  N'Table', N'mr_role_module', N'column' , N'role_id';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '模块编号',   N'user',  N'dbo',  N'Table', N'mr_role_module', N'column' , N'module_id';
go

ALTER TABLE mr_role_module ADD CONSTRAINT FK_mr_role_module_role_id  FOREIGN KEY (role_id)  REFERENCES  mr_role
go

ALTER TABLE mr_role_module ADD CONSTRAINT FK_mr_role_module_module_id  FOREIGN KEY (module_id)  REFERENCES  mr_module
go








/* SQL Server 建表语句  */
IF EXISTS(SELECT * FROM sys.Tables WHERE name='mr_role_action')
  DROP TABLE mr_role_action
go

CREATE TABLE mr_role_action(
  role_id int NOT NULL ,
  action_id int NOT NULL
  CONSTRAINT PK_mr_role_action PRIMARY KEY(role_id, action_id )
);
go

EXECUTE sp_addextendedproperty N'MS_Description', '角色-动作关系',  N'user',  N'dbo',  N'Table', N'mr_role_action', NULL, NULL;
go

EXECUTE sp_addextendedproperty   N'MS_Description', '角色编号',   N'user',  N'dbo',  N'Table', N'mr_role_action', N'column' , N'role_id';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '动作编号',   N'user',  N'dbo',  N'Table', N'mr_role_action', N'column' , N'action_id';
go

ALTER TABLE mr_role_action ADD CONSTRAINT FK_mr_role_action_role_id  FOREIGN KEY (role_id)  REFERENCES  mr_role
go

ALTER TABLE mr_role_action ADD CONSTRAINT FK_mr_role_action_action_id  FOREIGN KEY (action_id)  REFERENCES  mr_action
go


















/* SQL Server 建表语句  */
IF EXISTS(SELECT * FROM sys.Tables WHERE name='mr_demo_data')
  DROP TABLE mr_demo_data
go

CREATE TABLE mr_demo_data(
  demo_id int IDENTITY(1,1)  NOT NULL ,
  city_id int NOT NULL ,
  dept_id int NOT NULL ,
  demo_info varchar(30)
  CONSTRAINT PK_mr_demo_data PRIMARY KEY(demo_id )
);
go

EXECUTE sp_addextendedproperty N'MS_Description', '演示数据',  N'user',  N'dbo',  N'Table', N'mr_demo_data', NULL, NULL;
go

EXECUTE sp_addextendedproperty   N'MS_Description', '主键(自增长)',   N'user',  N'dbo',  N'Table', N'mr_demo_data', N'column' , N'demo_id';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '城市编号',   N'user',  N'dbo',  N'Table', N'mr_demo_data', N'column' , N'city_id';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '部门编号',   N'user',  N'dbo',  N'Table', N'mr_demo_data', N'column' , N'dept_id';
go

EXECUTE sp_addextendedproperty   N'MS_Description', '演示数据',   N'user',  N'dbo',  N'Table', N'mr_demo_data', N'column' , N'demo_info';
go

