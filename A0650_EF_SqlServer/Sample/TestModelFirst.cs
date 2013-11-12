using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0650_EF_SqlServer.Sample
{


    /// <summary>
    /// 测试  Model First 的 代码.
    /// 
    /// 这种开发方式的步骤是：
    /// 首先创建一个空白的 edmx.
    /// 然后在设计环境下， 
    /// 添加 “实体” （也就是表）
    /// 为 “实体” 添加 “属性” （也就是表的字段）
    /// 
    /// 通过在 “文档” 的 “摘要” 位置， 填写 表/字段 的注释信息
    /// （此注释信息在 C# 中可用， 但是不会创建到数据库中去）
    /// 
    /// 
    /// 实体与实体之间，拖动关联 （也就是表与表的外键关联）
    /// 拖关联的时候， 通过双击 关联， 设置 父表的主键， 与 子表的哪一个字段相关联。
    /// 如果不指定，那么系统在生成数据库脚本的时候，将自动创建一列。
    /// </summary>
    public class TestModelFirst
    {

        public static void DoTest()
        {

            Console.WriteLine("测试 Model First 的处理代码！");


            using (ModelFirstContainer context = new ModelFirstContainer())
            {
                // 新建股票.
                STOCK stock = new STOCK()
                {
                    // 股票代码.
                    STOCK_CODE = "IF1208",
                    // 股票名称.
                    STOCK_NAME = "沪深08(IF1208)",
                };

                // 插入数据.
                context.STOCKS.AddObject(stock);



                // 新建策略.
                STRATEGY straegy = new STRATEGY()
                {
                    // 策略代码.
                    STRATEGY_CODE = "A",
                    // 策略名.
                    STRATEGY_NAME = "测试A",
                    // 策略描述
                    STRATEGY_DESC = "Just For Test",
                };

                // 插入数据.
                context.STRATEGYS.AddObject(straegy);




                // 新建交易记录.
                TRANS_DETAIL transDetail1 = new TRANS_DETAIL()
                {
                    // 策略代码.
                    STRATEGY_CODE = "A",
                    // 股票代码.
                    STOCK_CODE = "IF1208",
                    // 成交日时.
                    TRANS_DATETIME = new DateTime(2012,7,19,9,40,59),
                    // 成交方向： 买入
                    TRANS_DIRECTION = "B",
                    // 成交类型: 开仓
                    TRANS_TYPE = "O",
                    // 成交数量
                    TRANS_VOLUME = 2,
                    // 成交价位
                    TRANS_PRICE = 2426.4M,

                };

                TRANS_DETAIL transDetail2 = new TRANS_DETAIL()
                {
                    // 策略代码.
                    STRATEGY_CODE = "A",
                    // 股票代码.
                    STOCK_CODE = "IF1208",
                    // 成交日时.
                    TRANS_DATETIME = new DateTime(2012, 7, 19, 10, 00, 59),
                    // 成交方向： 卖出
                    TRANS_DIRECTION = "S",
                    // 成交类型: 平仓
                    TRANS_TYPE = "C",
                    // 成交数量
                    TRANS_VOLUME = 2,
                    // 成交价位
                    TRANS_PRICE = 2426.6M,

                };


                context.TRANS_DETAILS.AddObject(transDetail1);
                context.TRANS_DETAILS.AddObject(transDetail2);



                // 保存更改.
                context.SaveChanges();
            }


            Console.WriteLine("测试 Model First 处理 完毕，请自行到数据库查询数据，并根据需要删除数据！");
            
        }


    }



}
