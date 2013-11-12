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
    class TestBasic
    {
        /// <summary>
        /// 由数据库系统管理的自增 ID.
        /// </summary>
        public ObjectId Id { get; set; }


        /// <summary>
        /// 程序需要直接存取的属性
        /// </summary>
        public string Name { get; set; }



        public override string ToString()
        {
            return String.Format("测试 TestBasic 数据：ID={0}; Name={1}", this.Id, this.Name);
        }
    }


}
