using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EdmxService.Model
{

    /// <summary>
    /// 列 信息.
    /// </summary>
    public class ColumnInfo : ICloneable
    {


        /// <summary>
        /// 名.
        /// </summary>
        public string Name { set; get; }


        /// <summary>
        /// 备注
        /// </summary>
        private string comment;

        /// <summary>
        /// 备注/说明信息.
        /// </summary>
        public string Comment
        {
            set
            {
                comment = value;
            }

            get
            {
                if (string.IsNullOrEmpty(comment))
                {
                    return Name;
                }
                else
                {
                    return comment;
                }
            }
        }

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }



        public override string ToString()
        {
            StringBuilder buff = new StringBuilder();
            buff.Append("列[");
            buff.AppendFormat("列名={0};", Name);
            buff.AppendFormat("备注/说明信息.={0}", Comment);
            buff.Append("]");
            return buff.ToString();
        }




    }

}
