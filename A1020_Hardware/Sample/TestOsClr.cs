using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A1020_Hardware.Sample
{
    class TestOsClr
    {


        /// <summary>
        /// 读取操作系统和CLR的版本
        /// </summary>
        public static void DoTest()
        {
            OperatingSystem os = System.Environment.OSVersion;
            Console.WriteLine("Platform: {0}", os.Platform);
            Console.WriteLine("Service Pack: {0}", os.ServicePack);
            Console.WriteLine("Version: {0}", os.Version);
            Console.WriteLine("VersionString: {0}", os.VersionString);
            Console.WriteLine("CLR Version: {0}", System.Environment.Version);
        }

    }
}
