using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0206_Flyweight.Compound
{

    public class ConcreteCompositeFlyweight : IFlyweight
    {

        /// <summary>
        /// 缓存享元数据的 Dictionary.
        /// </summary>
        private List<IFlyweight> buffList = new List<IFlyweight>();



        /// <summary>
        /// 增加一个新的单纯享元对象到聚集中  
        /// </summary>
        /// <param name="fly"></param>
        public void Add(IFlyweight fly)  
        {  
            buffList.Add(fly);  
        }  


        /// <summary>
        /// 外蕴状态作为参数传入到方法中  
        /// </summary>
        /// <param name="extrinsicState"></param>
        public void Operation(String extrinsicState)  
        {
            foreach(IFlyweight fly in this.buffList) {
                fly.Operation(extrinsicState);  
            }
        }  


    }
}
