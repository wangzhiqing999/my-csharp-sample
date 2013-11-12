本项目用于 实现在 函数中完成动态 SQL 的处理.


参数有2个， 一个是表名称， 一个是查询条件.


执行的前提
sp_configure 'clr enabled', 1
GO
RECONFIGURE
GO



然后在 VS2010 里面，创建一个 “Visual C# SQL CLR 数据库项目”
创建一个函数





写完C#函数以后. 编译通过完毕以后。
回到  SQL Server Management Studio 中的 [可编程性] 下的 [程序集]中。
先把这个编译好的 S0031_IsTableExists.dll 加进去。



C# 项目需要记得设置 目标框架为 .NET Framework 3.5
如果使用默认的 .NET Framework 4，可能无法成功的把编译好的 DLL 文件发布到 SQL Server 2008 上面去。


在把编辑好的 DLL 文件，加入到数据库的程序集之后。
再执行下面的 SQL 语句。

-- 创建函数.
CREATE FUNCTION [dbo].[IsTableExists]
(@tableName NVARCHAR (64), @queryInfo NVARCHAR (1000))
RETURNS INT
AS
  EXTERNAL NAME[S0031_IsTableExists].[UserDefinedFunctions].[IsTableExists]
go





系统中很多表， 都有2个特殊的字段。比如 Code1  与 Code2.
这个2个字段的值，都是有关联关系的。
不能在一个表中， 只有Code1 ， 没有 Code2 这种情况。

换句话说，这个 Code1 与 Code2 ， 要么2个都为 NULL， 要么2个都不为NULL.

但是由于程序上面的错误，数据库更新出了点问题，要收拾残局了。
怎么办呢？

由于这个 Code1 与 Code2 在每个表里面，实际的字段名，都不一样
例如 
在A表， 叫  A_Code1 与 A_Code2
在B表， 叫  B_Code1 与 B_Code2

-- 测试表
CREATE TABLE a  ( A_CODE1 INT, A_CODE2 INT);
CREATE TABLE b  ( B_CODE1 INT, B_CODE2 INT);

-- 测试数据。 a表存在非法数据.
INSERT INTO a VALUES( 1, null);
INSERT INTO b VALUES( 1, 1);

 

通过 关联 sys.tables 与 sys.columns 可以比较方便把有这种关系的表/字段定位出来

SELECT
  t.name AS TableName,
  c1.name AS Code1Name,
  c2.name AS Code1Name
FROM
  sys.tables t
    JOIN sys.columns c1 ON (t.object_id = c1.object_id AND c1.name LIKE '%Code1')
    JOIN sys.columns c2 ON (t.object_id = c2.object_id AND c2.name LIKE '%Code2')

TableName  Code1Name     Code1Name
---------- ------------- ---------
a          A_CODE1       A_CODE2
b          B_CODE1       B_CODE2

(2 行受影响)





SELECT
  Convert(varchar(10), t.name) AS TableName,
  Convert(varchar(10), c1.name) AS Code1Name,
  Convert(varchar(10), c2.name) AS Code1Name,
  dbo.[IsTableExists](
      t.name,
      c1.name + ' IS NOT NULL AND ' 
        + c2.name + ' IS NULL' ) AS [是否存在问题数据]
FROM
  sys.tables t
    JOIN sys.columns c1 ON (t.object_id = c1.object_id AND c1.name LIKE '%Code1')
    JOIN sys.columns c2 ON (t.object_id = c2.object_id AND c2.name LIKE '%Code2')
go


TableName  Code1Name  Code1Name  是否存在问题数据
---------- ---------- ---------- -----------
a          A_CODE1    A_CODE2              1
b          B_CODE1    B_CODE2              0

(2 行受影响)

