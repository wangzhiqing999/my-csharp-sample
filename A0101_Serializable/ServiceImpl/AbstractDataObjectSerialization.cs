using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;
using System.IO;


using A0101_Serializable.Model;
using A0101_Serializable.Service;


namespace A0101_Serializable.ServiceImpl
{
    

    public abstract class AbstractDataObjectSerialization : IDataObjectSerialization
    {

        /// <summary>
        /// IFormat接口引用，来自于BinaryFormatter类对象
        /// </summary>
        protected IFormatter fmt;


        /// <summary>
        /// 将 类数据， 序列化写入到文件中去.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fileName"></param>
        void IDataObjectSerialization.WriteToFile(DataObject obj, string fileName)
        {
            // 创建stream类型引用fs，并传递fileName做路径参数
            Stream fs = new FileStream(
                fileName, FileMode.Create, FileAccess.Write, FileShare.None);

            // 调用serialize方法，传递fs和obj参数
            fmt.Serialize(fs, obj);

            //关闭fs对象
            fs.Close();
        }



        /// <summary>
        /// 从文件中，读取数据，赋值到类对象中.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        DataObject IDataObjectSerialization.ReadFromFile(string fileName)
        {
            // 创建stream类型引用fs，并传递fileName做路径参数
            Stream fs = new FileStream(
                fileName, FileMode.Open, FileAccess.Read, FileShare.None);

            DataObject result = fmt.Deserialize(fs) as DataObject;

            // 关闭fs对象
            fs.Close();

            return result;
        }
    }

}
