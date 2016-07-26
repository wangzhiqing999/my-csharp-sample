using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;


namespace A0205_XmlSerializer.Sample
{
    class XmlUtility
    {


        /// <summary>
        /// 对象序列化成 XML String
        /// (编码为 GB2312)
        /// </summary>
        public static string XmlSerialize<T>(T obj)
        {
            string xmlString = string.Empty;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {

                XmlWriterSettings setting = new XmlWriterSettings();
                setting.Encoding = Encoding.GetEncoding("GB2312");
                setting.Indent = true;

                using (XmlWriter writer = XmlWriter.Create(ms, setting))
                {
                    xmlSerializer.Serialize(writer, obj);
                }

                xmlString = Encoding.GetEncoding("GB2312").GetString(ms.ToArray());
            }
            return xmlString;
        }



        /// <summary>
        /// XML String 反序列化成对象
        /// (编码为 GB2312)
        /// </summary>
        public static T XmlDeserialize<T>(string xmlString)
        {
            T t = default(T);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (Stream xmlStream = new MemoryStream(Encoding.GetEncoding("GB2312").GetBytes(xmlString)))
            {
                using (XmlReader xmlReader = XmlReader.Create(xmlStream))
                {
                    Object obj = xmlSerializer.Deserialize(xmlReader);
                    t = (T)obj;
                }
            }
            return t;
        }


    }
}
