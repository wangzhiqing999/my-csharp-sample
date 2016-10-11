using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B1100_AutoMapper.Model
{

    /// <summary>
    /// 用于测试， 业务系统中， 画面上使用的类.
    /// </summary>
    public class TestUiClass
    {
        /// <summary>
        /// 测试的 主键 ID.
        /// </summary>
        public long ID { set; get; }



        /// <summary>
        /// 名称.
        /// </summary>
        public string Name { set; get; }




        /// <summary>
        /// 是否有效.
        /// </summary>
        public bool IsActive { set; get; }




        /// <summary>
        /// 是否更新了.
        /// </summary>
        public bool IsUpdate { set; get; }




        public override string ToString()
        {
            return String.Format("TestUiClass : [ID = {0}; Name = {1}; IsActive = {2};  IsUpdate = {3} ]",
                    ID, Name, IsActive, IsUpdate);
        }

    }
}
