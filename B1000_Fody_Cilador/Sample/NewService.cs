using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Cilador.Fody.InterfaceMixins;

using B1000_Fody_Cilador_Old;

namespace B1000_Fody_Cilador.Sample
{



    /// <summary>
    /// 新的实现.
    /// </summary>
    [InterfaceMixin(typeof(IOldService))]
    [InterfaceMixin(typeof(IOldService2))]
    public class NewService
    {

        // 新的实现类， 需要有下面的限制.

        // Create a non-generic class type.
        // Implement the mixin interface and only the mixin interface.
        // 不能继承其他的类.
        // 不能写构造函数.



        public string NewHello()
        {
            return "Hello World Version 2";
        }

    }
}
