using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ninject;

using B0030_Ninject.Sample;

namespace B0033_Ninject.Sample
{


    
    public class JpPeople
    {

        #region  以构造函数方式. 实现依赖注入.


        private readonly IHelloWorld  peopleHelloWorld;




        [Inject]
        public JpPeople([EnglishKnowAble] IHelloWorld helloWorld)
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
