using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B0030_Ninject.Sample
{


    public class HelloWorldChinese : IHelloWorld
    {
        string IHelloWorld.HelloWorld()
        {
            return "您好 世界 ！";
        }
    }


}
