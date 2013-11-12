using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using MongoDB.Bson;



namespace A0190_MongoDB.Sample
{

    /// <summary>
    /// 测试用于存储到 MongoDB 上的数据类.
    /// </summary>
    public class TestLinq
    {
        /// <summary>
        /// 由数据库系统管理的自增 ID.
        /// </summary>
        public ObjectId Id { get; set; }


        /// <summary>
        /// 名
        /// </summary>
        public string FirstName { get; set; }


        /// <summary>
        /// 姓
        /// </summary>
        public string LastName { get; set; }



        /// <summary>
        /// 流水号.
        /// </summary>
        public int SeqNumber { set; get; }




        public override string ToString()
        {
            return String.Format("测试 TestLinq 数据：ID={0}; FirstName={1}; LastName={2}; SeqNumber={3} ", this.Id, this.FirstName, this.LastName, this.SeqNumber);
        }


    }
}
