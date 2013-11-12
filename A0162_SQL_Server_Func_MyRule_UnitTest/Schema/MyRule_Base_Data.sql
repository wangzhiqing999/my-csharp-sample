
TRUNCATE TABLE mr_permission;
GO


INSERT INTO mr_permission (
    permission_id,
    permission_name,
    permission_desc
) 
SELECT 1,   'DEFAULT',  '默认的权限[如果不启用复杂的权限管理，那么只需要这一个就可以了]' UNION ALL
SELECT 2,   'SELECT',   '检索的权限'    UNION  ALL
SELECT 4,   'INSERT',   '新增的权限'    UNION  ALL
SELECT 8,   'UPDATE',   '更新的权限'    UNION  ALL
SELECT 16,  'DELETE',   '删除的权限'
GO
