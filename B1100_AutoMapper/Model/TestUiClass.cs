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






        /// <summary>
        /// 这个用于测试 数据库类的上的属性名，   与 画面类名上的属性名  命名机制不一致的情况下，  如何互相转换的处理.
        /// </summary>
        public string SysUserCode { set; get; }




        public override string ToString()
        {
            return String.Format("TestUiClass : [ID = {0}; Name = {1}; IsActive = {2};  IsUpdate = {3};  SysUserCode = {4} ]",
                    ID, Name, IsActive, IsUpdate, SysUserCode);
        }

    }
}
