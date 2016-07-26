using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Google.ProtocolBuffers;
using Google.ProtocolBuffers.Examples.AddressBook;



namespace A0101_ProtocolBuffers.Test
{

    /// <summary>
    /// 测试类.
    /// </summary>
    public class TestAddressBook
    {



        public void TestProtocolBuffers()
        {

            // 注意： 这里没办法简单  Person person = new Person();

            Person.Builder builder = new Person.Builder();
            builder.SetEmail("zhangsan@testprotocolbuffers.com");
            builder.SetId(123);
            builder.SetName("张三");

            builder.AddPhone(new Person.Types.PhoneNumber.Builder().SetNumber("13012345678").SetType(Person.Types.PhoneType.MOBILE));
            builder.AddPhone(new Person.Types.PhoneNumber.Builder().SetNumber("02112345678").SetType(Person.Types.PhoneType.HOME));

            // 生成 person 类
            Person person = builder.Build();

            // 序列化.
            byte[] buf = person.ToByteArray();

            // 写入文件.
            System.IO.File.WriteAllBytes("test.dat", buf);





            // 读取.
            byte[] dataBuff = System.IO.File.ReadAllBytes("test.dat");


            // 反序列化.
            try
            {
                Person person2 = Person.ParseFrom(dataBuff);
                Console.WriteLine(person2.Id + "," + person2.Name + "， " + person2.Email);
                IList<Person.Types.PhoneNumber> lstPhones = person2.PhoneList;
                foreach (Person.Types.PhoneNumber phoneNumber in lstPhones)
                {
                    Console.WriteLine(phoneNumber.Number + " : " + phoneNumber.Type);
                }
            }
            catch (InvalidProtocolBufferException e)
            {
                // TODO Auto-generated catch block
                Console.WriteLine(e.Message);
            }



            Console.WriteLine("Finish!!!");
            Console.ReadLine();

        }


    }

}
