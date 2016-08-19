using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using System.Reflection;

using System.Security;
using System.Security.Permissions;
using System.Security.Policy;

using B0015_RazorEngine.Sample;



namespace B0015_RazorEngine
{
    class Program
    {
        static void Main(string[] args)
        {


            // 这个 if 里面的代码， 是用来 创建一个新的 AppDomain .
            if (AppDomain.CurrentDomain.IsDefaultAppDomain())
            {
                // RazorEngine cannot clean up from the default appdomain...
                Console.WriteLine("Switching to secound AppDomain, for RazorEngine...");
                AppDomainSetup adSetup = new AppDomainSetup();
                adSetup.ApplicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                var current = AppDomain.CurrentDomain;
                // You only need to add strongnames when your appdomain is not a full trust environment.
                var strongNames = new StrongName[0];

                var domain = AppDomain.CreateDomain(
                    "MyMainDomain", null,
                    current.SetupInformation, 
                    new PermissionSet(PermissionState.Unrestricted),
                    strongNames);
                var exitCode = domain.ExecuteAssembly(Assembly.GetExecutingAssembly().Location);
                // RazorEngine will cleanup. 
                AppDomain.Unload(domain);


                return;
            }



            // 下面是实际执行的具体的代码.


            RazorEngineSample.TestHelloWorld();

            RazorEngineSample.Test1();
            RazorEngineSample.Test2();


            Console.WriteLine("Finish!");
            Console.ReadKey();


        }
    }
}
