using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ninject;


using B0030_Ninject.Sample;



namespace B0031_Ninject.Sample
{


    public class People2
    {

        #region  以属性. 实现依赖注入.


        IEnumerable<IHelloWorld> allPeopleHelloWorld;


        [Inject]
        public IEnumerable<IHelloWorld> HelloWorlds
        {
            set { allPeopleHelloWorld = value; }

            get
            {
                return allPeopleHelloWorld;
            }
        }


        #endregion




        public void SayHello()
        {
            foreach (IHelloWorld oneHelloWorld in allPeopleHelloWorld)
            {
                Console.WriteLine(oneHelloWorld.HelloWorld());
            }
        }

    }
}
