本项目用于返回汉字的拼音首字母。(英文数字简单返回)

执行的前提
sp_configure 'clr enabled', 1
GO
RECONFIGURE
GO



然后在 VS2010 里面，创建一个 “Visual C# SQL CLR 数据库项目”
创建一个函数




写完C#函数以后. 编译通过完毕以后。
回到  SQL Server Management Studio 中的 [可编程性] 下的 [程序集]中。
先把这个编译好的 S0021_GetPinYin.dll 加进去。


C# 项目需要记得设置 目标框架为 .NET Framework 3.5
如果使用默认的 .NET Framework 4，可能无法成功的把编译好的 DLL 文件发布到 SQL Server 2008 上面去。


在把编辑好的 DLL 文件，加入到数据库的程序集之后。
再执行下面的 SQL 语句。

-- 创建函数.
CREATE FUNCTION [dbo].[GetPinYin]
(@word NVARCHAR (100))
RETURNS NVARCHAR (100)
AS
  EXTERNAL NAME[S0021_GetPinYin].[UserDefinedFunctions].[GetPinYin]
go


-- 测试
SELECT
  Convert(nvarchar(10), [dbo].[GetPinYin]('张三')) A,
  Convert(nvarchar(10), [dbo].[GetPinYin]('李四')) B,
  Convert(nvarchar(10), [dbo].[GetPinYin]('王五')) C,
  Convert(nvarchar(10), [dbo].[GetPinYin]('赵六')) D,
  Convert(nvarchar(10), [dbo].[GetPinYin]('测试123')) E,
  Convert(nvarchar(10), [dbo].[GetPinYin]('123Test')) F
GO

A          B          C          D          E          F
---------- ---------- ---------- ---------- ---------- ----------
ZS         LS         WW         ZL         CS123      123Test

(1 行受影响)
