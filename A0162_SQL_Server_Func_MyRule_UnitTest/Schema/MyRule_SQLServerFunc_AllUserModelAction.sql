SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


IF EXISTS(SELECT * FROM dbo.sysobjects WHERE
    xtype IN ('IF', 'TF', 'FN')
    AND OBJECTPROPERTY(id, N'IsMSShipped') = 0
    AND name='MyRule_AllUserAccessAbleModule')
  DROP FUNCTION MyRule_AllUserAccessAbleModule
GO



-- =============================================
-- Author:		Edward.Wang
-- Description:	获取 指定 用户的 全部的 "可访问模块" 列表.
--              可访问模块包含 用户直接可访问模块 与 用户直接可访问模块的下属模块.
--              以及 用户的角色 直接可访问模块 与 用户的角色直接可访问模块的下属模块.
-- =============================================
CREATE FUNCTION MyRule_AllUserAccessAbleModule
(
    @userID     int
)
RETURNS TABLE
AS
RETURN
(
    -- 用户直接可访问模块
    SELECT
        module_id,
        parent_id,
        module_name,
        status
    FROM
        MyRule_UserAccessAbleModule(@userID)
    UNION ALL   -- 这里使用 UNION ALL， 将合并掉 重复的数据
    -- 用户的角色可访问模块
    SELECT
        RAAM.module_id,
        RAAM.parent_id,
        RAAM.module_name,
        RAAM.status
    FROM
        MyRule_UserOwnRole(@userID) AS UOR
        CROSS APPLY
        MyRule_RoleAccessAbleModule( UOR.role_id )  AS  RAAM
)
GO











IF EXISTS(SELECT * FROM dbo.sysobjects WHERE
    xtype IN ('IF', 'TF', 'FN')
    AND OBJECTPROPERTY(id, N'IsMSShipped') = 0
    AND name='MyRule_AllUserAccessAbleAction')
  DROP FUNCTION MyRule_AllUserAccessAbleAction
GO




-- =============================================
-- Author:		Edward.Wang
-- Description:	获取 指定用户 对指定模块 全部的 "可访问动作" 列表.
--              可访问动作，包含 当前模块的 默认可用动作 与 针对用户授权了的动作.
--              以及针对 用户的角色授权了的动作.
-- =============================================
CREATE FUNCTION MyRule_AllUserAccessAbleAction
(
    @userID     int,
    @moduleID   int
)
RETURNS TABLE
AS
RETURN
(
    -- 用户直接可访问模块动作.
    SELECT
        action_id,
        module_id,
        action_name,
        default_rule,
        status
    FROM
        MyRule_UserAccessAbleAction(@userID, @moduleID)
    UNION ALL   -- 这里使用 UNION ALL， 将合并掉 重复的数据
    SELECT
        RAAA.action_id,
        RAAA.module_id,
        RAAA.action_name,
        RAAA.default_rule,
        RAAA.status
    FROM
        MyRule_UserOwnRole(@userID) AS UOR
        CROSS APPLY
        MyRule_RoleAccessAbleAction( UOR.role_id, @moduleID )  AS  RAAA
)
GO

