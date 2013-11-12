using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0007_Reflection_ModelCopyer.Model
{


    /// <summary>
    /// 用于测试  对象数据复制的  目标类.
    /// </summary>
    public class TestModelTo
    {


        /// <summary>
        /// 测试一个  通用的属性.
        /// 
        /// 源、目标类都有的，此属性数据将被复制.
        /// </summary>
        public string TestNormal { set; get; }


        /// <summary>
        /// 测试一个  只有 目标类有的属性。
        /// 
        /// 源类无此属性， 此属性将被忽略
        /// </summary>
        public string TestToOnly { set; get; }




        /// <summary>
        /// 测试一个  源类 只读属性。
        /// 
        /// 目标类 此属性 可读写， 此属性数据将被复制
        /// </summary>
        public string TestFromReadOnly { set; get; }


        /// <summary>
        /// 测试一个   源类 只写属性。
        /// 
        /// 目标类 此属性 可读写， 此属性将被忽略
        /// </summary>
        public string TestFromWriteOnly { set; get; }




        /// <summary>
        /// 测试一个  目标类 只读属性。
        /// 
        /// 源类 此属性 可读写，此属性将被忽略
        /// </summary>
        public string TestToReadOnly
        {
            get
            {
                return "TestToReadOnly";
            }
        }



        private string _TestToWriteOnly;

        /// <summary>
        /// 测试一个  目标类 只写属性。
        /// 
        /// 源类 此属性 可读写，此属性数据将被复制
        /// </summary>
        public string TestToWriteOnly {
            set
            {
                _TestToWriteOnly = value;
            }
        }





        public override string ToString()
        {
            StringBuilder buff = new StringBuilder();

            buff.AppendFormat("TestNormal = {0};", TestNormal);
            buff.AppendFormat("TestToOnly = {0};", TestToOnly);
            buff.AppendFormat("TestFromReadOnly = {0};", TestFromReadOnly);
            buff.AppendFormat("TestFromWriteOnly = {0};", TestFromWriteOnly);
            buff.AppendFormat("TestToReadOnly = {0};", TestToReadOnly);
            buff.AppendFormat("_TestToWriteOnly = {0}", _TestToWriteOnly);

            return buff.ToString();
        }

    }


}
