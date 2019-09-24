using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;

using A5400_Validatetion.Util;
using A5400_Validatetion.Sample;


namespace A5400_Validatetion
{
    class Program
    {
        static void Main(string[] args)
        {

            BaseTest1("zh-CN");
            BaseTest1("en-US");


            BaseTest2();


            BaseTest3();


            Console.WriteLine("Finish.");
            Console.ReadLine();
        }





        /// <summary>
        /// 基本测试1.
        /// </summary>
        private static void BaseTest1(string lang = "zh-CN")
        {
            Console.WriteLine($"----- BaseTest1 {lang} start.-----");


            CultureInfo cultureInfo = new CultureInfo(lang);
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;


            TestPerson1 person = new TestPerson1();
            person.Name = "";
            person.Email = "hahaha Test";
            person.Phone = "ABC";
            person.Salary = 1;
            var result = ValidatetionHelper.IsValid(person);
            if (!result.IsVaild)
            {
                foreach (ErrorMember errorMember in result.ErrorMembers)
                {
                    Console.WriteLine(errorMember.ErrorMemberName + "：" + errorMember.ErrorMessage);
                }
            }
            Console.WriteLine($"----- BaseTest1 {lang} finsih.-----");
            Console.WriteLine();
        }



        /// <summary>
        /// 基本测试2.
        /// </summary>
        private static void BaseTest2()
        {
            Console.WriteLine("----- BaseTest2 start.-----");
            TestPerson2 person = new TestPerson2();
            person.Name = "";
            person.Email = "hahaha Test";
            person.Phone = "ABC";
            person.Salary = 1;
            var result = ValidatetionHelper.IsValid(person);
            if (!result.IsVaild)
            {
                foreach (ErrorMember errorMember in result.ErrorMembers)
                {
                    Console.WriteLine(errorMember.ErrorMemberName + "：" + errorMember.ErrorMessage);
                }
            }
            Console.WriteLine("----- BaseTest2 finish.-----");
            Console.WriteLine();
        }





        /// <summary>
        /// 基本测试3.
        /// </summary>
        private static void BaseTest3()
        {
            Console.WriteLine("----- BaseTest3 start.-----");
            TestPerson3 person = new TestPerson3();
            person.Name = "";
            person.Email = "hahaha Test";
            person.Phone = "ABC";
            person.Salary = 1;
            var result = ValidatetionHelper.IsValid(person);
            if (!result.IsVaild)
            {
                foreach (ErrorMember errorMember in result.ErrorMembers)
                {
                    Console.WriteLine(errorMember.ErrorMemberName + "：" + errorMember.ErrorMessage);
                }
            }
            Console.WriteLine("----- BaseTest3 finish.-----");
            Console.WriteLine();
        }


    }
}
