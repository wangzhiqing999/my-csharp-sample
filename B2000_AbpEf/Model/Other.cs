using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;



namespace B2000_AbpEf.Model
{


    /// <summary>
    /// 其他测试.
    /// </summary>
    [Table("test_abp_other")]
    public class Other : Entity<Int64>,
        ICreationAudited, IModificationAudited, IDeletionAudited,         
        IPassivable
    {

        // 注意：
        // 上面的 ICreationAudited, IModificationAudited, IDeletionAudited
        // 可以缩略为 IFullAudited
        // 因为：
        // public interface IFullAudited : IAudited, ICreationAudited, IHasCreationTime, IModificationAudited, IHasModificationTime, IDeletionAudited, IHasDeletionTime, ISoftDelete




        /// <summary>
        /// 名称
        /// </summary>
        [Column("other_name")]
        [StringLength(64)]
        public virtual string Name { get; set; }





        #region  ICreationAudited 接口的实现.

        /// <summary>
        /// 创建用户.
        /// </summary>
        [Column("creation_user")]
        public virtual long? CreatorUserId { get; set; }

        /// <summary>
        /// 创建时间.
        /// </summary>
        [Column("creation_time")]
        public virtual DateTime CreationTime { get; set; }


        #endregion





        #region  IModificationAudited 接口的实现.

        /// <summary>
        /// 最后修改人.
        /// </summary>
        [Column("lastmodifier_user")]
        public virtual long? LastModifierUserId { get; set; }


        /// <summary>
        /// 最后修改时间.
        /// </summary>
        [Column("lastmodification_time")]
        public virtual DateTime? LastModificationTime { get; set; }

        #endregion







        #region  IDeletionAudited 接口的实现.


        /// <summary>
        /// 数据是否被删除.
        /// </summary>
        [Column("is_deleted")]
        public virtual bool IsDeleted { get; set; }


        /// <summary>
        /// 删除人.
        /// </summary>
        [Column("deleter_user")]
        public virtual long? DeleterUserId { get; set; }


        /// <summary>
        /// 删除时间.
        /// </summary>
        [Column("deletion_time")]
        public virtual DateTime? DeletionTime { get; set; }



        #endregion





        #region  IPassivable 接口的实现.


        /// <summary>
        /// 状态.
        /// </summary>
        [Column("is_active")]
        public virtual bool IsActive { set; get; }


        #endregion







        public Other()
        {
            // 初始化创建时间.
            CreationTime = DateTime.Now;
        }



        public override string ToString()
        {
            StringBuilder buff = new StringBuilder("Other Data [");

            // 名称.
            buff.AppendFormat("Name = {0}; ", this.Name);

            // 状态.
            buff.AppendFormat("IsActive = {0}; ", this.IsActive);




            // 创建人/创建时间.
            buff.AppendFormat("CreatorUserId = {0}; ", this.CreatorUserId);
            buff.AppendFormat("CreationTime = {0}; ", this.CreationTime);


            // 修改人/修改时间.
            buff.AppendFormat("LastModifierUserId = {0}; ", this.LastModifierUserId);
            buff.AppendFormat("LastModificationTime = {0}; ", this.LastModificationTime);


            // 是否被删除/删除人/删除时间.
            buff.AppendFormat("IsDeleted = {0}; ", this.IsDeleted);
            buff.AppendFormat("DeleterUserId = {0}; ", this.DeleterUserId);
            buff.AppendFormat("DeletionTime = {0}; ", this.DeletionTime);





            buff.Append("]");
            return buff.ToString();
        }



    }


}
