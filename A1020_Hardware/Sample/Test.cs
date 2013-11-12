using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Management;

namespace A1020_Hardware.Sample
{
    public class Test
    {

        public static void ShowHardwareInfo(string keyInfo)
        {

            Console.WriteLine("获取 {0} 的信息...", keyInfo);

            // Get the WMI class
            ManagementClass processClass = new ManagementClass(keyInfo);

            ManagementObjectCollection moc = processClass.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                Console.WriteLine(
                    mo.GetText(TextFormat.Mof));
            }
        }




        /// <summary>
        /// 获取硬件信息数值
        /// </summary>
        /// <param name="path"> 路径 </param>
        /// <param name="propName"> 属性 </param>
        /// <returns></returns>
        public static string GetHardwareInfoValue(string path, string propName)
        {
            // Get the WMI class
            ManagementClass processClass = new ManagementClass(path);
            // Get the properties in the class
            PropertyDataCollection properties = processClass.Properties;
            ManagementObjectCollection moc = processClass.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                return mo.GetPropertyValue(propName).ToString();
            }
            return null;
        }



    }
}
