项目目的:

在 SQL Server 下，实现 MySQL 的 GROUP_CONCAT 函数的功能.




执行的前提
sp_configure 'clr enabled', 1 
GO 
RECONFIGURE 
GO 



然后在 VS2010 里面，创建一个 “Visual C# SQL CLR 数据库项目”

然后创建 “聚集”.

编写代码.

编译通过完毕以后。
回到  SQL Server Management Studio 中的 [可编程性] 下的 [程序集]中。
先把这个编译好的 S0001_GROUP_CONCAT.dll  加进去。



C# 项目需要记得设置 目标框架为 .NET Framework 3.5
如果使用默认的 .NET Framework 4，可能无法成功的把编译好的 DLL 文件发布到 SQL Server 2008 上面去。


在把编辑好的 DLL 文件，加入到数据库的程序集之后。
再执行下面的 SQL 语句。

-- 创建聚集函数.
CREATE AGGREGATE [dbo].[GROUP_CONCAT](@Value NVARCHAR(30))
 RETURNS NVARCHAR(MAX)
 EXTERNAL NAME [S0001_GROUP_CONCAT].[GROUP_CONCAT];



-- 模拟测试.
CREATE TABLE TestTitle (
  name   VARCHAR(10),
  title  VARCHAR(20)
);


INSERT INTO TestTitle VALUES ('张三', '程序员');
INSERT INTO TestTitle VALUES ('张三', '系统管理员');
INSERT INTO TestTitle VALUES ('张三', '网络管理员');

INSERT INTO TestTitle VALUES ('李四', '项目经理');
INSERT INTO TestTitle VALUES ('李四', '系统分析员');

INSERT INTO TestTitle VALUES ('王五', '系统分析员');
GO


SELECT
  name,
  Convert(nvarchar(30), dbo.GROUP_CONCAT(title)) AS allTitle
FROM
  TestTitle
GROUP BY
  name;
GO


执行结果.

name       allTitle
---------- ------------------------------
李四         项目经理,系统分析员
王五         系统分析员
张三         程序员,系统管理员,网络管理员

(3 行受影响)