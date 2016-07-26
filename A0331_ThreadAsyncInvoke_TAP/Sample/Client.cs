using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A0331_ThreadAsyncInvoke_TAP.Sample
{
    class Client
    {


        public void Test()
        {
            PrimeNumberCalculator pnc = new PrimeNumberCalculator();
            pnc.Calculate(1000);
        }



        public void TestTap()
        {
            PrimeNumberCalculatorTap pnc = new PrimeNumberCalculatorTap();
            pnc.Calculate(1000);
        }

    }
}
