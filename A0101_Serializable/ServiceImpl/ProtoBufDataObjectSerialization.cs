using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using A0101_Serializable.Model;
using A0101_Serializable.Service;

namespace A0101_Serializable.ServiceImpl
{
    class ProtoBufDataObjectSerialization : IDataObjectSerialization
    {

        /// <summary>
        /// 将 类数据， 序列化写入到文件中去.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fileName"></param>
        public void WriteToFile(DataObject obj, string fileName)
        {
            using (var file = System.IO.File.Create(fileName))
            {
                ProtoBuf.Serializer.Serialize(file, obj);
            }
        }



        /// <summary>
        /// 从文件中，读取数据，赋值到类对象中.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public DataObject ReadFromFile(string fileName)
        {
            DataObject result = null;
            using (var file = System.IO.File.OpenRead(fileName))
            {
                result = ProtoBuf.Serializer.Deserialize<DataObject>(file);
            }
            return result;

        }
    }
}
