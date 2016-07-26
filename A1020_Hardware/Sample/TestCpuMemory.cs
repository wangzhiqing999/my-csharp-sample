using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Management;

using System.Diagnostics;


namespace A1020_Hardware.Sample
{
    class TestCpuMemory
    {



        public static void DoTest()
        {
            Console.WriteLine("Machine: {0}", Environment.MachineName);
            Console.WriteLine("# of processors (logical): {0}", Environment.ProcessorCount);
            Console.WriteLine("# of processors (physical): {0}",  CountPhysicalProcessors());
            Console.WriteLine("RAM installed: {0:N0} bytes",  CountPhysicalMemory());
            Console.WriteLine("Is OS 64-bit? {0}",   Environment.Is64BitOperatingSystem);
            Console.WriteLine("Is process 64-bit? {0}",  Environment.Is64BitProcess);
            Console.WriteLine("Little-endian: {0}", BitConverter.IsLittleEndian);




            Console.WriteLine(".NET给程序分配的内存数量");
            long available = GC.GetTotalMemory(false);
            Console.WriteLine("Before allocations: {0:N0}", available);
            int allocSize = 40000000;
            byte[] bigArray = new byte[allocSize];
            available = GC.GetTotalMemory(false);
            Console.WriteLine("After allocations: {0:N0}", available);



            Console.WriteLine("当前应用程序占用的内存");
            Process proc = Process.GetCurrentProcess();
            Console.WriteLine("Process Info: "+Environment.NewLine+ 
             "Private Memory Size: {0:N0}"+Environment.NewLine +
            "Virtual Memory Size: {1:N0}" + Environment.NewLine +
            "Working Set Size: {2:N0}" + Environment.NewLine +
            "Paged Memory Size: {3:N0}" + Environment.NewLine +
            "Paged System Memory Size: {4:N0}" + Environment.NewLine +
              "Non-paged System Memory Size: {5:N0}" + Environment.NewLine,
            proc.PrivateMemorySize64,   proc.VirtualMemorySize64,  proc.WorkingSet64,  proc.PagedMemorySize64, proc.PagedSystemMemorySize64,  proc.NonpagedSystemMemorySize64 );

        }



        private static UInt32 CountPhysicalProcessors()
        {
             ManagementObjectSearcher objects = new ManagementObjectSearcher(
                "SELECT * FROM Win32_ComputerSystem");
             ManagementObjectCollection coll = objects.Get();
             foreach(ManagementObject obj in coll)
            {
                return (UInt32)obj["NumberOfProcessors"];
            } 
            return 0;
        }


        private static UInt64 CountPhysicalMemory()
        {
           ManagementObjectSearcher objects =new ManagementObjectSearcher(
              "SELECT * FROM Win32_PhysicalMemory");
           ManagementObjectCollection coll = objects.Get();
           UInt64 total = 0;
           foreach (ManagementObject obj in coll)
           {
               total += (UInt64)obj["Capacity"];
            }
            return total;
        }


    }
}
