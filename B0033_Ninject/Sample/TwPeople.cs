using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ninject;

using B0030_Ninject.Sample;

namespace B0033_Ninject.Sample
{


    [ChineseKnowAble]
    public class TwPeople
    {

        #region  以构造函数方式. 实现依赖注入.


        private readonly IHelloWorld  peopleHelloWorld;




        [Inject]
        public TwPeople(IHelloWorld helloWorld)
        {
            if (helloWorld == null)
                throw new ArgumentNullException("helloWorld");

            this.peopleHelloWorld = helloWorld;
        }


        #endregion




        public void SayHello()
        {
            Console.WriteLine(this.peopleHelloWorld.HelloWorld());
        }



    }

}
