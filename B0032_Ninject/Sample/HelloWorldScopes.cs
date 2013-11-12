using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


using B0030_Ninject.Sample;




namespace B0032_Ninject.Sample
{



    /// <summary>
    /// 本类用于  测试 Ninject 中的  Object Scopes
    /// 
    /// 也就是
    /// 
    /// 
    /// Scope	Binding Method	Meaning
    /// Transient	.InTransientScope()	A new instance of the type will be created each time one is requested. (This is the default scope)
    /// Singleton	.InSingletonScope()	Only a single instance of the type will be created, and the same instance will be returned for each subsequent request.
    /// Thread	.InThreadScope()	One instance of the type will be created per thread.
    /// Request	.InRequestScope()	One instance of the type will be created for each web request. 
    /// 
    /// 
    /// If no scope is specified, by default, the StandardKernel will use the Transient scope.
    /// </summary>
    public class HelloWorldScopes : IHelloWorld
    {

        /// <summary>
        /// 内部实例变量.
        /// 
        /// 用于判断， 什么时候，创建了新的实例.
        /// 
        /// 假如实例被重新创建了，那么 index 将被复位为 0.
        /// </summary>
        private int index = 0;



        string IHelloWorld.HelloWorld()
        {
            // 假如实例没有被重新创建，那么 index 将持续递增.
            index++;


            // 返回 当前 线程ID 与 index.
            return String.Format(
                "#{0}: Hello World {1}",
                Thread.CurrentThread.ManagedThreadId,
                index);

        }



    }



}
