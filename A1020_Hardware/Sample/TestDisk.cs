using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Management;


namespace A1020_Hardware.Sample
{
    class TestDisk
    {


        // 取第一块硬盘编号
        public static String GetHardDiskID()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
                String strHardDiskID = null;
                foreach (ManagementObject mo in searcher.Get())
                {
                    strHardDiskID = mo["SerialNumber"].ToString().Trim();
                    break;
                }
                return strHardDiskID;
            }
            catch
            {
                return "";
            }
        }


    }
}
