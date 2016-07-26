using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0370_Lazy.Sample
{

    /// <summary>
    /// 用于测试的 客户信息类.
    /// </summary>
    public class Customer
    {

        /// <summary>
        /// 订单.    (延迟初始化)
        /// </summary>
        private List<Order> _orders;


        /// <summary>
        /// 顾客代码.
        /// </summary>
        public string CustomerID { get; private set; }




        public Customer(string id)
        {
            CustomerID = id;

            // 定义延迟加载的处理逻辑.
            _orders =  new List<Order>();
            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(100);

                _orders.Add(new Order()
                {
                    OrderID = i,
                    ItemCode = i,
                    ItemName = "商品" + i,
                    ItemCount = i,
                });
            }

        }



        public List<Order> MyOrders
        {
            get
            {
                return _orders;
            }
        }

    }


}
