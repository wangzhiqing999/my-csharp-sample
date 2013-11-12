using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0110_DateTime.Sample;


namespace A0110_DateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTimeSample sample = new DateTimeSample();
            sample.TestDateTimeUse();


            sample.TestTimeSpanUse();

            Console.ReadLine();
        }


    }
}
