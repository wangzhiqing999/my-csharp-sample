using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0101_Serializable.Model;

namespace A0101_Serializable.Service
{

    /// <summary>
    /// 序列化 / 反序列化接口.
    /// </summary>
    public interface IDataObjectSerialization
    {


        /// <summary>
        /// 将 类数据， 序列化写入到文件中去.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fileName"></param>
        void WriteToFile(DataObject obj, string fileName);



        /// <summary>
        /// 从文件中，读取数据，赋值到类对象中.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        DataObject ReadFromFile(string fileName);

    }


}
