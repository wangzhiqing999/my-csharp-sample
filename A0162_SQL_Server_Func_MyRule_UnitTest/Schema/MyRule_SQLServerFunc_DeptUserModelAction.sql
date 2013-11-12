SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



IF EXISTS(SELECT * FROM dbo.sysobjects WHERE
    xtype IN ('IF', 'TF', 'FN')
    AND OBJECTPROPERTY(id, N'IsMSShipped') = 0
    AND name='MyRule_UserAccessAbleDept')
  DROP FUNCTION MyRule_UserAccessAbleDept
GO



-- =============================================
-- Author:		Edward.Wang
-- Description:	获取 指定 用户的 "可访问部门" 列表.
--              可访问部门包含 用户当前部门 与 用户当前部门的下属部门.
-- =============================================
CREATE FUNCTION MyRule_UserAccessAbleDept
(
    @userID     int,
    @deptType   varchar(10)
)
RETURNS TABLE
AS
RETURN
(
    WITH StepCTE
    AS
    (
        SELECT
            mr_dept.dept_id,
            parent_id,
            dept_name,
            dept_type,
            status,
            mr_dept_user.permission_data           
        FROM
            mr_dept
              JOIN  mr_dept_user
                ON (mr_dept.dept_id = mr_dept_user.dept_id)
        WHERE
            mr_dept_user.user_id = @userID
            AND mr_dept.dept_type = @deptType
        UNION ALL
        SELECT
            T.dept_id,
            T.parent_id,
            T.dept_name,
            T.dept_type,
            T.status,
            CTE.permission_data 
        FROM
            mr_dept T INNER JOIN StepCTE CTE
            ON T.parent_id = CTE.dept_id
     )
     SELECT
        dept_id,
        parent_id,
        dept_name,
        dept_type
        status,
        permission_data
     FROM
        StepCTE
)
GO



---------------------------------------------------------------
-- SELECT * FROM MyRule_UserAccessAbleDept(1);
-- SELECT * FROM MyRule_UserAccessAbleDept(2);
---------------------------------------------------------------




IF EXISTS(SELECT * FROM dbo.sysobjects WHERE
    xtype IN ('IF', 'TF', 'FN')
    AND OBJECTPROPERTY(id, N'IsMSShipped') = 0
    AND name='MyRule_UserAccessAbleModule')
  DROP FUNCTION MyRule_UserAccessAbleModule
GO



-- =============================================
-- Author:		Edward.Wang
-- Description:	获取 指定 用户的 "可访问模块" 列表.
--              可访问模块包含 用户直接可访问模块 与 用户直接可访问模块的下属模块.
-- =============================================
CREATE FUNCTION MyRule_UserAccessAbleModule
(
    @userID     int
)
RETURNS TABLE
AS
RETURN
(
    WITH StepCTE
    AS
    (
        SELECT
            module_id,
            parent_id,
            module_name,
            status
        FROM
            mr_module
        WHERE
            EXISTS (
                SELECT 1
                FROM mr_user_module
                WHERE
                    mr_module.module_id = mr_user_module.module_id
                    AND mr_user_module.user_id = @userID
            )
        UNION ALL
        SELECT
            T.module_id,
            T.parent_id,
            T.module_name,
            T.status
        FROM
            mr_module T INNER JOIN StepCTE CTE
            ON T.parent_id = CTE.module_id
     )
     SELECT
        module_id,
        parent_id,
        module_name,
        status
     FROM
        StepCTE
)
GO



---------------------------------------------------------------
-- SELECT * FROM MyRule_UserAccessAbleModule(1);
-- SELECT * FROM MyRule_UserAccessAbleModule(2);
---------------------------------------------------------------





IF EXISTS(SELECT * FROM dbo.sysobjects WHERE
    xtype IN ('IF', 'TF', 'FN')
    AND OBJECTPROPERTY(id, N'IsMSShipped') = 0
    AND name='MyRule_UserAccessAbleAction')
  DROP FUNCTION MyRule_UserAccessAbleAction
GO




-- =============================================
-- Author:		Edward.Wang
-- Description:	获取 指定用户 对指定模块 的 "可访问动作" 列表.
--              可访问动作，包含 当前模块的 默认可用动作 与 针对用户授权了的动作.
-- =============================================
CREATE FUNCTION MyRule_UserAccessAbleAction
(
    @userID     int,
    @moduleID   int
)
RETURNS TABLE
AS
RETURN
(
    SELECT
        action_id,
        module_id,
        action_name,
        default_rule,
        status
    FROM
        mr_action
    WHERE
        module_id = @moduleID
        AND (
            -- 动作为 模块的默认可用动作.
            default_rule = 1
            -- 直接针对用户授权了的动作.
            OR             
            EXISTS (
                SELECT 1
                FROM
                    mr_user_action
                WHERE
                    mr_user_action.user_id = @userID
                    AND mr_user_action.action_id = mr_action.action_id
            )
        )
        AND -- 用户有 模块的权限.
            EXISTS (
                SELECT 1
                FROM
                    MyRule_UserAccessAbleModule(@userID) AS UAAM
                WHERE
                    UAAM.module_id = mr_action.module_id
            )        
)
GO



---------------------------------------------------------------
-- SELECT * FROM MyRule_UserAccessAbleAction(1, 4);
-- SELECT * FROM MyRule_UserAccessAbleAction(2, 4);
---------------------------------------------------------------

