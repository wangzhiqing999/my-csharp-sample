using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B0030_Ninject.Sample
{


    public class HelloWorldEnglish : IHelloWorld
    {
        string IHelloWorld.HelloWorld()
        {
            return "Hello World !";
        }
    }


}
