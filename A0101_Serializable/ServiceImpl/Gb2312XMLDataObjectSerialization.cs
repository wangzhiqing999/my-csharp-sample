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


    /// <summary>
    /// XML 序列化 （文件编码，使用 GB2312 编码）
    /// </summary>
    public class Gb2312XMLDataObjectSerialization : IDataObjectSerialization
    {

        /// <summary>
        /// 将 类数据， 序列化写入到文件中去.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fileName"></param>
        void IDataObjectSerialization.WriteToFile(DataObject obj, string fileName)
        {


            // 注意：下面的，是为了去除结果文件中，  xmlns:xsi 定义的。
            // Create our own namespaces for the output
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            // Add an empty namespace and empty value
            ns.Add("", "");


            XmlSerializer serializer = new XmlSerializer(typeof(DataObject));

            XmlWriterSettings setting = new XmlWriterSettings();
            setting.Encoding = Encoding.GetEncoding("GB2312");
            setting.Indent = true;


            // 注意： 如果要去除掉   <?xml version="1.0" encoding="编码"?> 的信息，
            // setting.OmitXmlDeclaration = true;


            using (XmlWriter writer = XmlWriter.Create(fileName, setting))
            {
                // 注意： 这里要增加一个  ns 的参数.w
                serializer.Serialize(writer, obj, ns);
            }

        }



        /// <summary>
        /// 从文件中，读取数据，赋值到类对象中.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        DataObject IDataObjectSerialization.ReadFromFile(string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(DataObject));

            StreamReader sr = new StreamReader(fileName, Encoding.GetEncoding("GB2312"));

            DataObject result = xs.Deserialize(sr) as DataObject;
            sr.Close();
            return result;
        }
    }


}
