using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EdmxService.Model
{

    /// <summary>
    /// 表信息.
    /// </summary>
    public class TableOrViewInfo : ICloneable
    {


        /// <summary>
        /// 名.
        /// </summary>
        public string Name { set; get; }


        private string comment;

        /// <summary>
        /// 备注/说明信息.
        /// </summary>
        public string Comment {
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
        /// 所有的子节点.
        /// </summary>
        public List<ColumnInfo> ColumnList { set; get; }


        /// <summary>
        /// 是 视图.
        /// </summary>
        public bool IsView { get; set; }





        /// <summary>
        /// 类名.
        /// </summary>
        public string ClassName { set; get; }





        #region ICloneable 成员

        public object Clone()
        {
            // 浅层克隆,
            TableOrViewInfo newTableInfo = this.MemberwiseClone() as TableOrViewInfo;

            // 重新克隆 列信息.
            if (newTableInfo.ColumnList != null)
            {

                newTableInfo.ColumnList = new List<ColumnInfo>();

                foreach (ColumnInfo col in this.ColumnList)
                {
                    newTableInfo.ColumnList.Add(col.Clone() as ColumnInfo);
                }
            }

            // 返回.
            return newTableInfo;
        }

        #endregion




        public override string ToString()
        {
            StringBuilder buff = new StringBuilder();

            if (this.IsView)
            {
                buff.Append("视图[");
            }
            else
            {
                buff.Append("表[");
            }

            
            buff.AppendFormat("名称={0};", Name);
            buff.AppendFormat("备注/说明信息.={0};", Comment);
            buff.Append("列List={");
            if (ColumnList != null)
            {
                buff.AppendLine();
                for (int i = 0; i < ColumnList.Count; i++)
                {
                    ColumnInfo column = ColumnList[i];
                    buff.AppendFormat("    列{0}={1}", i + 1, column);
                    buff.AppendLine();
                }
            }
            buff.Append("}");
            buff.Append("]");
            return buff.ToString();
        }
    }
}
