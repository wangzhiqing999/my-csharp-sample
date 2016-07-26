using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0370_Lazy.Sample
{

    /// <summary>
    /// 用于测试的 客户信息类.
    /// 
    /// 使用  Lazy  加载的处理.
    /// 
    /// 
    /// </summary>
    class CustomerWithLazy
    {

        /// <summary>
        /// 订单.    (延迟初始化)
        /// </summary>
        private Lazy<List<Order>> _orders;


        /// <summary>
        /// 顾客代码.
        /// </summary>
        public string CustomerID { get; private set; }




        public CustomerWithLazy(string id)
        {
            CustomerID = id;

            // 定义延迟加载的处理逻辑.
            _orders = new Lazy<List<Order>>(() =>
            {

                // 这里可以追加查询处理的逻辑。
                // 现在就简单模拟一个耗时操作了。

                

                List<Order> orderList = new List<Order>();
                for (int i = 0; i < 10; i++)
                {
                    System.Threading.Thread.Sleep(100);

                    orderList.Add(new Order()
                    {
                        OrderID = i,
                        ItemCode = i,
                        ItemName = "商品" + i,
                        ItemCount = i,
                    });
                }

                return orderList;
            });
        }



        public List<Order> MyOrders
        {
            get
            {
                // 如果不用 Lazy<List<Order>> 的话。
                // 也可以通过
                // if( _orders == null) {  加载数据 }  
                // return _orders;
                // 来实现.



                // Orders is created on first access here.
                return _orders.Value;
            }
        }

    }
}
