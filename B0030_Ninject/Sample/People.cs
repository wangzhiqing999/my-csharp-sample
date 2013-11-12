using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ninject;


namespace B0030_Ninject.Sample
{

    public class People
    {

        #region  以构造函数方式. 实现依赖注入.


        private readonly IHelloWorld  peopleHelloWorld;



        [Inject]
        public People(IHelloWorld helloWorld)
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
