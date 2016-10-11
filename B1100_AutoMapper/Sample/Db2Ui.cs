using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;


using B1100_AutoMapper.Model;



namespace B1100_AutoMapper.Sample
{

    /// <summary>
    /// 测试  数据库的类， 转换为  画面的类.
    /// </summary>
    class Db2Ui
    {

        public Db2Ui()
        {
            Mapper.CreateMap<TestDbClass, TestUiClass>();
        }




        public void DoTest()
        {

            // 先 手动 模拟一个  从数据库中获取的类.
            TestDbClass dbClass = new TestDbClass()
            {
                ID = 1,
                Name = "测试",
                IsActive = true,


                CreateTime = DateTime.Now,
                LastUpdateTime = DateTime.Now,

                CreateUser = "Tester",
                LastUpdateUser = "Tester",
            };




            


            // 测试将其转换为 UI 上使用的类.
            TestUiClass uiClass = Mapper.Map<TestDbClass, TestUiClass>(dbClass);
            

            Console.WriteLine("DB to UI......");

            Console.WriteLine("DB类 = {0}", dbClass);
            Console.WriteLine("UI类 = {0}", uiClass);

            Console.WriteLine("DB to UI finish!!!");
        }


    }

}
