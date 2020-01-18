using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestNuGet.Service;

namespace TestNuGet.Client
{
    class Program
    {
        static void Main(string[] args)
        {

            TestService service = new TestService();

            Console.WriteLine("MaxValue = {0}", service.GetMax());
            Console.WriteLine("MinValue = {0}", service.GetMin());

            Console.WriteLine("SumValue = {0}", service.GetSum());
            Console.WriteLine("AvgValue = {0}", service.GetAvg());


            Console.WriteLine("Finish!");
            Console.ReadLine();
        }
    }
}
