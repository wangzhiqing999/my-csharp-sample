using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0550_PLINQ_Base1.Sample
{
    class AutoStopwatch : System.Diagnostics.Stopwatch, IDisposable
    {
       public AutoStopwatch()
       { 
           Start();
       }
       public void Dispose()
       {
           Stop();
           Console.WriteLine("Elapsed: {0}", this.Elapsed);
       }
    }
}
