using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using A0101_Serializable.Model;
using A0101_Serializable.Service;
using A0101_Serializable.ServiceImpl;


namespace A0101_Serializable
{


    class Program
    {


        static void Main(string[] args)
        {

            DataObject testData = new DataObject();
            testData.UserName = "测试 序列化 / 反序列化";
            testData.Password = "123456";

            testData.FirendList = new List<string>();
            testData.FirendList.Add("XMLDataObjectSerialization");
            testData.FirendList.Add("BinaryDataObjectSerialization");


            Console.WriteLine("原始数据：");
            Console.WriteLine(testData.ToString());



            IDataObjectSerialization iService = null;



            Console.WriteLine("测试使用 XML 进行 序列化与反序列化！");
            
            iService = new XMLDataObjectSerialization();

            // 写入文件.
            iService.WriteToFile(testData, "test.xml");
            
            // 读取文件.
            Console.WriteLine(iService.ReadFromFile("test.xml"));






            Console.WriteLine("测试使用 BinaryFormatter 进行 序列化与反序列化！");

            iService = new BinaryDataObjectSerialization();

            // 写入文件.
            iService.WriteToFile(testData, "test.dat");

            // 读取文件.
            Console.WriteLine(iService.ReadFromFile("test.dat"));






            //Console.WriteLine("测试使用 SoapFormatter 进行 序列化与反序列化！");

            //iService = new SoapDataObjectSerialization();

            //// 写入文件.
            //iService.WriteToFile(testData, "test.soap");

            //// 读取文件.
            //Console.WriteLine(iService.ReadFromFile("test.soap"));





            Console.WriteLine("测试使用 System.Runtime.Serialization.Json 进行 序列化与反序列化！");

            iService = new JsonDataObjectSerialization();

            // 写入文件.
            iService.WriteToFile(testData, "test.js");

            // 读取文件.
            Console.WriteLine(iService.ReadFromFile("test.js"));



            Console.ReadLine();
        }




    }
}
