using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0007_Reflection_ModelCopyer.Model
{


    /// <summary>
    /// 用于测试  对象数据复制的  源类.
    /// </summary>
    public class TestModelFrom
    {


        /// <summary>
        /// 测试一个  通用的属性.
        /// 
        /// 源、目标类都有的，此属性数据将被复制.
        /// </summary>
        public string TestNormal { set; get; }



        /// <summary>
        /// 测试一个  只有 源类有的属性。
        /// 
        /// 目标类无此属性， 此属性将被忽略
        /// </summary>
        public string TestFromOnly { set; get; }




        /// <summary>
        /// 测试一个  源类 只读属性。
        /// 
        /// 目标类 此属性 可读写， 此属性数据将被复制
        /// </summary>
        public string TestFromReadOnly
        {
            get
            {
                return "TestFromReadOnly";
            }
        }



        private string _TestFromWriteOnly;

        /// <summary>
        /// 测试一个   源类 只写属性。
        /// 
        /// 目标类 此属性 可读写， 此属性将被忽略
        /// </summary>
        public string TestFromWriteOnly
        {
            set
            {
                _TestFromWriteOnly = value;
            }
        }



        /// <summary>
        /// 测试一个  目标类 只读属性。
        /// 
        /// 源类 此属性 可读写，此属性将被忽略
        /// </summary>
        public string TestToReadOnly { set; get; }



        /// <summary>
        /// 测试一个  目标类 只写属性。
        /// 
        /// 源类 此属性 可读写，此属性数据将被复制
        /// </summary>
        public string TestToWriteOnly { set; get; }





        public override string ToString()
        {
            StringBuilder buff = new StringBuilder();

            buff.AppendFormat("TestNormal = {0};", TestNormal);
            buff.AppendFormat("TestFromOnly = {0};", TestFromOnly);
            buff.AppendFormat("TestFromReadOnly = {0};", TestFromReadOnly);
            buff.AppendFormat("_TestFromWriteOnly = {0};", _TestFromWriteOnly);
            buff.AppendFormat("TestToReadOnly = {0};", TestToReadOnly);
            buff.AppendFormat("TestToWriteOnly = {0}", TestToWriteOnly);

            return buff.ToString();
        }

    }


}
