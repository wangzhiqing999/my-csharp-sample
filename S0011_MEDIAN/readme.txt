使用  Visual C# SQL CLR  创建的聚合函数来处理 中位数




中位数（Median）统计学名词

 1、定义：一组数据按从小到大（或从大到小）的顺序依次排列，处在中间位置的一个数（或最中间两个数据的平均数，注意：和众数不同，中位数不一定在这组数据中）。　 　　
 2、中位数的优缺点：中位数是样本数据所占频率的等分线，它不受少数几个极端值得影响，有时用它代表全体数据的一般水平更合适。 　
 3、在频率分布直方图中，中位数左边和右边的直方图的面积应该相等，由此可以估计中位数的值。 　　
 4、中位数也可表述为第50百分位数，二者等价。 　　
 5、直观印象描述：一半比“我”小，一半比“我”大。



中位数的算法
 求中位数时，首先要先进行数据的排序（从小到大），然后计算中位数的序号，分数据为奇数个与偶数个两种来求. 　　
 中位数算出来可避免极端数据，代表着数据总体的中等情况。 　　
 如果总数个数是奇数的话,按从小到大的顺序,取中间的那个数 　　
 如果总数个数是偶数个的话,按从小到大的顺序,取中间那两个数的平均数






使用 VS2010，创建一个
Visual C# SQL CLR 数据库项目 命名为 S0011_MEDIAN
在项目中添加一个 [聚合] 的类



C# 项目需要记得设置 目标框架为 .NET Framework 3.5
如果使用默认的 .NET Framework 4，可能无法成功的把编译好的 DLL 文件发布到 SQL Server 2008 上面去。


在把编辑好的 DLL 文件，加入到数据库的程序集之后。
再执行下面的 SQL 语句。
CREATE AGGREGATE [dbo].[Median](@Value NUMERIC (18))
  RETURNS NUMERIC (18)
  EXTERNAL NAME [S0011_MEDIAN].[Median];


-- 测试表 与数据.

-- 测试表
CREATE TABLE test_median (
  Name  varchar(10),
  val   INT
);
GO

-- 测试数据.
INSERT INTO test_median
  SELECT 'A',  1000  UNION ALL
  SELECT 'A',  2000  UNION ALL
  SELECT 'A',  3000  UNION ALL
  SELECT 'A',  4000  UNION ALL
  SELECT 'A',  5000  UNION ALL
  SELECT 'B',  100   UNION ALL
  SELECT 'B',  200   UNION ALL
  SELECT 'B',  300   UNION ALL
  SELECT 'B',  400   UNION ALL
  SELECT 'B',  7000  UNION ALL
  SELECT 'B',  10000
GO

Name 为 A 的数据，有5条
Name 为 B 的数据，有6条



SELECT
  ISNULL(Name, '全部') AS 名称,
  SUM(val)  AS  合计,
  AVG(val)  AS  平均数,
  dbo.Median(val) AS 中位数
FROM
  test_median
GROUP BY
  Name
WITH ROLLUP;
GO


名称         合计          平均数         中位数
---------- ----------- ----------- --------------------
A                15000        3000                 3000
B                18000        3000                  350
全部               33000        3000                 2000

(3 行受影响)

