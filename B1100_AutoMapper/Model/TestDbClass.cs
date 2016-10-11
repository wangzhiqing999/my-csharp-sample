using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B1100_AutoMapper.Model
{

    /// <summary>
    /// 用于测试， ORM 中， 数据库中的类.
    /// </summary>
    public class TestDbClass
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
        /// 状态
        /// </summary>
        public string Status { set; get; }


        /// <summary>
        /// 状态是有效的.
        /// </summary>
        public const string STATUS_IS_ACTIVE = "ACTIVE";


        /// <summary>
        /// 状态是无效的.
        /// </summary>
        public const string STATUS_IS_INACTIVE = "INACTIVE";


        // ==================================================
        // 如果有其他的状态， 可以尝试在这里扩展.
        // ==================================================

        /// <summary>
        /// 状态是否有效.
        /// </summary>
        public virtual bool IsActive
        {
            set
            {
                this.Status = value ? STATUS_IS_ACTIVE : STATUS_IS_INACTIVE;
            }
            get
            {
                return this.Status == STATUS_IS_ACTIVE;
            }
        }







        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { set; get; }



        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { set; get; }




        /// <summary>
        /// 最后更新人
        /// </summary>
        public string LastUpdateUser { set; get; }



        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime LastUpdateTime { set; get; }









        /// <summary>
        /// 这个用于测试 数据库类的上的属性名，   与 画面类名上的属性名  命名机制不一致的情况下，  如何互相转换的处理.
        /// </summary>
        public string sys_user_code { set; get; }





        public override string ToString()
        {
            return String.Format("TestDbClass : [ID = {0}; Name = {1}; Status = {2}; CreateUser = {3}; CreateTime = {4}; LastUpdateUser = {5}; LastUpdateTime = {6};  sys_user_code={7} ]",
                    ID, Name, Status, CreateUser, CreateTime, LastUpdateUser, LastUpdateTime, sys_user_code);
        }

    }

}
