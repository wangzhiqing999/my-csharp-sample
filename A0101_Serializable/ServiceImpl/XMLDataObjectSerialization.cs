using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Xml;
using System.Xml.Serialization;

using A0101_Serializable.Model;
using A0101_Serializable.Service;


namespace A0101_Serializable.ServiceImpl
{

    public class XMLDataObjectSerialization : IDataObjectSerialization
    {

        /// <summary>
        /// 将 类数据， 序列化写入到文件中去.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fileName"></param>
        void IDataObjectSerialization.WriteToFile(DataObject obj, string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(DataObject));
            StreamWriter sw = new StreamWriter(fileName);
            xs.Serialize(sw, obj);
            sw.Close();
        }



        /// <summary>
        /// 从文件中，读取数据，赋值到类对象中.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        DataObject IDataObjectSerialization.ReadFromFile(string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(DataObject));
            StreamReader sr = new StreamReader(fileName);
            DataObject result = xs.Deserialize(sr) as DataObject;
            sr.Close();
            return result;
        }
    }


}
