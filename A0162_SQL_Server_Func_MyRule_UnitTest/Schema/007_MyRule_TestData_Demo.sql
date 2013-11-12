TRUNCATE TABLE mr_demo_data
GO


-- 本演示数据，  通过 将  城市 与 组织机构， 进行排列组合的处理.
-- 用于测试  权限体系中
-- 一个用户， 哪些数据能够看到，哪些数据不能看到。


-- 关于 哪些数据 只读、 哪些数据 可读写的 扩展的权限
-- 由 mr_dept_user 表中的  permission_data  进行定义.


INSERT INTO mr_demo_data(
    city_id,
    dept_id,
    demo_info
)
SELECT  11,     1,      '全国 总公司 数据'   UNION ALL
SELECT  11,     2,      '全国 管理部 数据'   UNION ALL
SELECT  11,     3,      '全国 人事部 数据'   UNION ALL
SELECT  11,     4,      '全国 开发部 数据'   UNION ALL
SELECT  11,     5,      '全国 运行部 数据'   UNION ALL
SELECT  11,     6,      '全国 市场部 数据'   UNION ALL
SELECT  11,     7,      '全国 硬件组 数据'   UNION ALL
SELECT  11,     8,      '全国 软件组 数据'   UNION ALL
SELECT  11,     9,      '全国 核心组 数据'   UNION ALL
SELECT  12,     1,      '北京 总公司 数据'   UNION ALL
SELECT  12,     2,      '北京 管理部 数据'   UNION ALL
SELECT  12,     3,      '北京 人事部 数据'   UNION ALL
SELECT  12,     4,      '北京 开发部 数据'   UNION ALL
SELECT  12,     5,      '北京 运行部 数据'   UNION ALL
SELECT  12,     6,      '北京 市场部 数据'   UNION ALL
SELECT  12,     7,      '北京 硬件组 数据'   UNION ALL
SELECT  12,     8,      '北京 软件组 数据'   UNION ALL
SELECT  12,     9,      '北京 核心组 数据'   UNION ALL
SELECT  13,     1,      '上海 总公司 数据'   UNION ALL
SELECT  13,     2,      '上海 管理部 数据'   UNION ALL
SELECT  13,     3,      '上海 人事部 数据'   UNION ALL
SELECT  13,     4,      '上海 开发部 数据'   UNION ALL
SELECT  13,     5,      '上海 运行部 数据'   UNION ALL
SELECT  13,     6,      '上海 市场部 数据'   UNION ALL
SELECT  13,     7,      '上海 硬件组 数据'   UNION ALL
SELECT  13,     8,      '上海 软件组 数据'   UNION ALL
SELECT  13,     9,      '上海 核心组 数据'   UNION ALL
SELECT  14,     1,      '广州 总公司 数据'   UNION ALL
SELECT  14,     2,      '广州 管理部 数据'   UNION ALL
SELECT  14,     3,      '广州 人事部 数据'   UNION ALL
SELECT  14,     4,      '广州 开发部 数据'   UNION ALL
SELECT  14,     5,      '广州 运行部 数据'   UNION ALL
SELECT  14,     6,      '广州 市场部 数据'   UNION ALL
SELECT  14,     7,      '广州 硬件组 数据'   UNION ALL
SELECT  14,     8,      '广州 软件组 数据'   UNION ALL
SELECT  14,     9,      '广州 核心组 数据'   UNION ALL
SELECT  15,     1,      '重庆 总公司 数据'   UNION ALL
SELECT  15,     2,      '重庆 管理部 数据'   UNION ALL
SELECT  15,     3,      '重庆 人事部 数据'   UNION ALL
SELECT  15,     4,      '重庆 开发部 数据'   UNION ALL
SELECT  15,     5,      '重庆 运行部 数据'   UNION ALL
SELECT  15,     6,      '重庆 市场部 数据'   UNION ALL
SELECT  15,     7,      '重庆 硬件组 数据'   UNION ALL
SELECT  15,     8,      '重庆 软件组 数据'   UNION ALL
SELECT  15,     9,      '重庆 核心组 数据'   UNION ALL
SELECT  16,     1,      '浙江省 总公司 数据'   UNION ALL
SELECT  16,     2,      '浙江省 管理部 数据'   UNION ALL
SELECT  16,     3,      '浙江省 人事部 数据'   UNION ALL
SELECT  16,     4,      '浙江省 开发部 数据'   UNION ALL
SELECT  16,     5,      '浙江省 运行部 数据'   UNION ALL
SELECT  16,     6,      '浙江省 市场部 数据'   UNION ALL
SELECT  16,     7,      '浙江省 硬件组 数据'   UNION ALL
SELECT  16,     8,      '浙江省 软件组 数据'   UNION ALL
SELECT  16,     9,      '浙江省 核心组 数据'   UNION ALL
SELECT  17,     1,      '杭州 总公司 数据'   UNION ALL
SELECT  17,     2,      '杭州 管理部 数据'   UNION ALL
SELECT  17,     3,      '杭州 人事部 数据'   UNION ALL
SELECT  17,     4,      '杭州 开发部 数据'   UNION ALL
SELECT  17,     5,      '杭州 运行部 数据'   UNION ALL
SELECT  17,     6,      '杭州 市场部 数据'   UNION ALL
SELECT  17,     7,      '杭州 硬件组 数据'   UNION ALL
SELECT  17,     8,      '杭州 软件组 数据'   UNION ALL
SELECT  17,     9,      '杭州 核心组 数据'   UNION ALL            
SELECT  18,     1,      '宁波 总公司 数据'   UNION ALL
SELECT  18,     2,      '宁波 管理部 数据'   UNION ALL
SELECT  18,     3,      '宁波 人事部 数据'   UNION ALL
SELECT  18,     4,      '宁波 开发部 数据'   UNION ALL
SELECT  18,     5,      '宁波 运行部 数据'   UNION ALL
SELECT  18,     6,      '宁波 市场部 数据'   UNION ALL
SELECT  18,     7,      '宁波 硬件组 数据'   UNION ALL
SELECT  18,     8,      '宁波 软件组 数据'   UNION ALL
SELECT  18,     9,      '宁波 核心组 数据'   UNION ALL
SELECT  19,     1,      '温州 总公司 数据'   UNION ALL
SELECT  19,     2,      '温州 管理部 数据'   UNION ALL
SELECT  19,     3,      '温州 人事部 数据'   UNION ALL
SELECT  19,     4,      '温州 开发部 数据'   UNION ALL
SELECT  19,     5,      '温州 运行部 数据'   UNION ALL
SELECT  19,     6,      '温州 市场部 数据'   UNION ALL
SELECT  19,     7,      '温州 硬件组 数据'   UNION ALL
SELECT  19,     8,      '温州 软件组 数据'   UNION ALL
SELECT  19,     9,      '温州 核心组 数据'
GO

