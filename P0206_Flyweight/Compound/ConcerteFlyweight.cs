using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0206_Flyweight.Compound
{

    /// <summary>
    /// 具体享元角色
    /// </summary>
    public class ConcerteFlyweight : IFlyweight
    {

        /// <summary>
        /// 内蕴状态。
        /// </summary>
        private Char intrinsicState;


        private Guid myGuid;


        /// <summary>
        /// 构造函数. 
        /// </summary>
        /// <param name="state"></param>
        public ConcerteFlyweight(Char state)
        {  
            this.intrinsicState = state;

            myGuid = Guid.NewGuid();
        }  


        void IFlyweight.Operation(string state)
        {
            Console.WriteLine(
                "内蕴状态={0}, {1};  外蕴状态={2}",
                intrinsicState,
                myGuid,
                state);
        }

    }


}
