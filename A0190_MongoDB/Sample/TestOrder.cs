using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MongoDB.Bson;



namespace A0190_MongoDB.Sample
{

    /// <summary>
    /// 商品
    /// </summary>
    public class TestGoods
    {
        /// <summary>
        /// 由数据库系统管理的自增 ID.
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// 商品代码.
        /// </summary>
        public string GoodsCode { set; get; }

        /// <summary>
        /// 商品名.
        /// </summary>
        public string GoodsName { set; get; }

        /// <summary>
        /// 商品价格.
        /// </summary>
        public int GoodsPrice { set; get; }

    }




    /// <summary>
    /// 订单
    /// </summary>
    public class TestOrder
    {
        /// <summary>
        /// 由数据库系统管理的自增 ID.
        /// </summary>
        public ObjectId Id { get; set; }


        /// <summary>
        /// 顾客代码.
        /// </summary>
        public string CustomerCode { set; get; }


        /// <summary>
        /// 顾客姓名.
        /// </summary>
        public string CustomerName { set; get; }


        /// <summary>
        /// 订单日期.
        /// </summary>
        public DateTime OrderDate { set; get; }


        /// <summary>
        /// 订单明细.
        /// </summary>
        public List<TeseOrderDetail> OrderDetail { set; get; }

    }



    public class TeseOrderDetail
    {

        /// <summary>
        /// 由数据库系统管理的自增 ID.
        /// </summary>
        public ObjectId Id { get; set; }


        /// <summary>
        /// 商品代码.
        /// </summary>
        public string GoodsCode { set; get; }

        /// <summary>
        /// 商品名.
        /// </summary>
        public string GoodsName { set; get; }

        /// <summary>
        /// 商品价格.
        /// </summary>
        public int GoodsPrice { set; get; }

        /// <summary>
        /// 购买商品的数量.
        /// </summary>
        public int GoodsCount { set; get; }
    }


}
