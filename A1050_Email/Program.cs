using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using A1050_Email.Sample;


namespace A1050_Email
{
    class Program
    {
        static void Main(string[] args)
        {

            // 邮件发送测试类.
            MailSender mailSender = new MailSender();


            // 测试发送邮件.
            mailSender.TestSendMail();



            Console.WriteLine("邮件发送处理完毕， 按回车键结束处理！");
            Console.ReadLine();
        }
    }
}
