using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using A3002_Office_Outlook.Common;
using A3002_Office_Outlook.Model;


namespace A3002_Office_Outlook
{
    class Program
    {


        static void Main(string[] args)
        {

            OutlookUtil outlookUtil = OutlookUtil.GetInstance();

            
            List<UserAddressBook> testList = new List<UserAddressBook>();


            UserAddressBook test1 = new UserAddressBook()
            {
                UserName = "测试用户1",
                Department = "测试部门1",
                Email = "test1@test.com",
                Mobile = "13800000001",
                SubPhone = "001"
            };

            UserAddressBook test2 = new UserAddressBook()
            {
                UserName = "测试用户2",
                Department = "测试部门2",
                Email = "test2@test.com",
                Mobile = "13800000002",
                SubPhone = "002"
            };


            testList.Add(test1);
            testList.Add(test2);



            Console.WriteLine("将测试数据写入 Outlook 地址簿！");
            outlookUtil.WriteAddressBookList(testList);



            Console.WriteLine("从 Outlook 地址簿读取数据！");
            List<UserAddressBook> newList = outlookUtil.ReadAddressBookList();



            Console.WriteLine("向前面获取的 用户信息，发送电子邮件！");
            outlookUtil.SendMailToUserList(newList);



            Console.WriteLine("处理完毕，按回车键退出！");
            Console.ReadLine();

        }
    }
}
