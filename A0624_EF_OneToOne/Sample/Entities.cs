using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;


namespace A0624_EF_OneToOne.Sample
{

    /// <summary>
    /// 车.
    /// </summary>
    public class Car
    {
        /// <summary>
        /// 车ID.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarID { set; get; }


        /// <summary>
        /// 车名称.
        /// </summary>
        public string CarName { set; get; }



        /// <summary>
        /// 发动机.
        /// 一对一关系.
        /// 一个发动机只装在一辆车上.
        /// 一辆车只装一个发动机.
        /// </summary>
        public virtual Engine Engine { get; set; } 

    }



    /// <summary>
    /// 发动机.
    /// </summary>
    public class Engine
    {
        /// <summary>
        /// 发动机ID.
        /// 
        /// 这里通过定义 ForeignKey
        /// 将 Car 设置为 一对一关系中的 “主”
        /// Engine 为一对一关系当中的 “次”.
        /// 
        /// 主次关系意味着：
        ///   不能单独创建一个 “次”
        ///   要 先创建了 “主”， 有了 “主”以后， 才能创建 “次”
        /// </summary>
        [Key]
        [ForeignKey("OnCar")] 
        public int EngineID { set; get; }


        /// <summary>
        /// 发动机名称.
        /// </summary>
        public string EngineName { set; get; }


        /// <summary>
        /// 车.
        /// 一对一关系.
        /// 一个发动机只装在一辆车上.
        /// 一辆车只装一个发动机.
        /// </summary>
        public virtual Car OnCar { get; set; }  
    }


}
