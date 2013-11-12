IF EXISTS(SELECT * FROM sys.Tables WHERE name='mr_role_action')
  DROP TABLE mr_role_action
go


IF EXISTS(SELECT * FROM sys.Tables WHERE name='mr_role_module')
  DROP TABLE mr_role_module
go


IF EXISTS(SELECT * FROM sys.Tables WHERE name='mr_user_role')
  DROP TABLE mr_user_role
go


IF EXISTS(SELECT * FROM sys.Tables WHERE name='mr_role')
  DROP TABLE mr_role
go


IF EXISTS(SELECT * FROM sys.Tables WHERE name='mr_user_action')
  DROP TABLE mr_user_action
go


IF EXISTS(SELECT * FROM sys.Tables WHERE name='mr_user_module')
  DROP TABLE mr_user_module
go


IF EXISTS(SELECT * FROM sys.Tables WHERE name='mr_action')
  DROP TABLE mr_action
go


IF EXISTS(SELECT * FROM sys.Tables WHERE name='mr_module')
  DROP TABLE mr_module
go






IF EXISTS(SELECT * FROM sys.Tables WHERE name='mr_dept_user')
  DROP TABLE mr_dept_user
go



IF EXISTS(SELECT * FROM sys.Tables WHERE name='mr_user')
  DROP TABLE mr_user
go



IF EXISTS(SELECT * FROM sys.Tables WHERE name='mr_dept')
  DROP TABLE mr_dept
go


IF EXISTS(SELECT * FROM sys.Tables WHERE name='mr_dept_type')
  DROP TABLE mr_dept_type
go


IF EXISTS(SELECT * FROM sys.Tables WHERE name='mr_permission')
  DROP TABLE mr_permission
go