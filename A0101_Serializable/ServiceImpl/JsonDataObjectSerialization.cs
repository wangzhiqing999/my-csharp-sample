using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Runtime.Serialization;

// 注意：
// 要想 下面这一行不抱错
// 需要引用 System.ServiceModel    System.ServiceModel.Web
using System.Runtime.Serialization.Json;


using System.IO;


using A0101_Serializable.Model;
using A0101_Serializable.Service;




namespace A0101_Serializable.ServiceImpl
{

    public class JsonDataObjectSerialization : IDataObjectSerialization
    {


        #region IDataObjectSerialization 成员

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

            // 构造 序列化类.
            DataContractJsonSerializer dcjs = new DataContractJsonSerializer(obj.GetType());

            // 写入文件数据流 
            dcjs.WriteObject(fs, obj);

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

            // 构造 序列化类.
            DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(DataObject));

            // 读取结果.
            DataObject result = (DataObject) dcjs.ReadObject(fs);

            // 返回.
            return result;

        }

        #endregion
    }


}
