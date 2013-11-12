using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ninject;

using B0030_Ninject.Sample;

namespace B0033_Ninject.Sample
{

    public class ChinesePeople
    {

        #region  以构造函数方式. 实现依赖注入.


        private readonly IHelloWorld  peopleHelloWorld;



        /// <summary>
        ///  下面的 Named ， 命名了依赖注入的时候， 具体使用哪一个 类.
        /// </summary>
        /// <param name="helloWorld"></param>
        [Inject]
        public ChinesePeople([Named("Chinese")] IHelloWorld helloWorld)
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
