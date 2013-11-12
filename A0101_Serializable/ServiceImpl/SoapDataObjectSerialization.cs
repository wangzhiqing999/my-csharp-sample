using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// 这个 System.Runtime.Serialization.Formatters.Soap 需要手动添加引用.
using System.Runtime.Serialization.Formatters.Soap;

using A0101_Serializable.Model;
using A0101_Serializable.Service;


namespace A0101_Serializable.ServiceImpl
{

    public class SoapDataObjectSerialization : AbstractDataObjectSerialization
    {

        // 注意：
        // 在使用 SoapFormatter 的过程中， 如果遇到 List<string> 这样的泛型数据

        // 将会提示：
        // Soap 序列化程序不支持序列化一般类型


        // 从 .NET Framework 3.5 版开始， SoapFormatter 类已过时。应改用 BinaryFormatter。
 

        public SoapDataObjectSerialization()
        {
            base.fmt = new SoapFormatter();
        }


    }
}
