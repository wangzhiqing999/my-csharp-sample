-- 删除 角色-模块功能关系数据.
DELETE FROM mr_role_action 
WHERE
    role_id < 100
    OR action_id < 100
GO



-- 删除 角色-模块关系数据.
DELETE FROM mr_role_module 
WHERE
    role_id < 100
    OR module_id < 100
GO



-- 删除 用户-角色关系数据.
DELETE FROM mr_user_role
WHERE
    user_id < 100
    OR role_id < 100
GO



-- 删除 角色数据.
DELETE FROM mr_role WHERE role_id < 100
GO



-- 删除 用户-模块功能关系数据.
DELETE FROM mr_user_action
WHERE
    user_id < 100
    OR action_id < 100
GO



-- 删除 用户-模块关系数据.
DELETE FROM mr_user_module
WHERE
    user_id < 100
    OR module_id < 100
GO



-- 删除 模块功能数据.
DELETE FROM mr_action WHERE action_id < 100
GO


-- 删除 模块数据.
DELETE FROM mr_module WHERE module_id < 100
GO



-- 删除 部门-用户关系数据.
DELETE FROM mr_dept_user 
WHERE 
    user_id < 100
GO


-- 删除用户数据.
DELETE FROM mr_user WHERE user_id < 100
GO

-- 删除部门数据.
DELETE FROM mr_dept WHERE dept_id < 100
GO
