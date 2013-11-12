----------------------------------------
-----   角色测试数据.               ----
----------------------------------------

SET IDENTITY_INSERT mr_role ON
GO


INSERT INTO mr_role (
    role_id,
    role_name,
    status
)
SELECT  1,  '全部权限', 1      UNION
SELECT  2,  '只读权限', 1      UNION
SELECT  3,  '读写权限', 1      


SET IDENTITY_INSERT mr_role OFF
GO


DBCC CHECKIDENT('mr_role', RESEED, 100)
GO




----------------------------------------
-----   用户-角色关系 测试数据.      ----
----------------------------------------

INSERT INTO mr_user_role (
    user_id,
    role_id
)
SELECT  5,  1   UNION ALL       -- 张Ａ : 全部权限
SELECT  6,  2   UNION ALL       -- 李Ｂ : 只读权限
SELECT  7,  3                   -- 王Ｃ : 读写权限
GO



