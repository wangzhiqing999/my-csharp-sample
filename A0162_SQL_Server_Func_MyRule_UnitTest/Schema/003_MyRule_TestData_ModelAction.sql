----------------------------------------
-----   模块测试数据.               ----
----------------------------------------


SET IDENTITY_INSERT mr_module ON
GO


INSERT INTO mr_module (
    module_id,
    parent_id,
    module_name,
    status
)
SELECT  1,  NULL,   '人事管理',         1   UNION  ALL
SELECT  2,  1,      '人事组织管理',     1   UNION  ALL
SELECT  3,  1,      '权限组织管理',     1   UNION  ALL
SELECT  4,  2,      '部门管理',         1   UNION  ALL
SELECT  5,  2,      '职位管理',         1   UNION  ALL
SELECT  6,  2,      '人员管理',         1   UNION  ALL
SELECT  7,  3,      '权限管理',         1   UNION  ALL
SELECT  8,  3,      '权限功能管理',     1   UNION  ALL
SELECT  9,  3,      '接口角色管理',     1
GO


SET IDENTITY_INSERT mr_module OFF
GO


DBCC CHECKIDENT('mr_module', RESEED, 100)
GO



----------------------------------------
-----   模块动作测试数据.           ----
----------------------------------------

SET IDENTITY_INSERT mr_action ON
GO


INSERT INTO mr_action (
    action_id,
    module_id,
    action_name,
    default_rule,
    status
)
SELECT  1,   4,  '查询部门', 1,  1   UNION ALL
SELECT  2,   4,  '新增部门', 0,  1   UNION ALL
SELECT  3,   4,  '编辑部门', 0,  1   UNION ALL
SELECT  4,   4,  '删除部门', 0,  1   UNION ALL
SELECT  5,   5,  '查询职位', 1,  1   UNION ALL
SELECT  6,   5,  '新增职位', 0,  1   UNION ALL
SELECT  7,   5,  '编辑职位', 0,  1   UNION ALL
SELECT  8,   5,  '删除职位', 0,  1   UNION ALL
SELECT  9,   6,  '查询人员', 1,  1   UNION ALL
SELECT  10,  6,  '新增人员', 0,  1   UNION ALL
SELECT  11,  6,  '编辑人员', 0,  1   UNION ALL
SELECT  12,  6,  '删除人员', 0,  1


SET IDENTITY_INSERT mr_action OFF
GO


DBCC CHECKIDENT('mr_action', RESEED, 100)
GO

