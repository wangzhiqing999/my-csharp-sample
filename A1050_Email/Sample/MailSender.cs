using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Net.Mail;


namespace A1050_Email.Sample
{


    class MailSender
    {


        /// <summary>
        /// SMTP 服务器名.
        /// </summary>
        private static readonly string SmtpServerName = @"smtp.test.com.cn";


        /// <summary>
        /// 邮件发送用户名.
        /// </summary>
        private static readonly string mailUserName = @"it@test.com.cn";


        /// <summary>
        /// 邮件发送密码.
        /// </summary>
        private static readonly string mailPassword = @"123456";



        



        /// <summary>
        /// 测试邮件发送.
        /// </summary>
        public void TestSendMail()
        {

            MailMessage myTxtMessage = GetMailMessage();
            // 不是 HTML 格式.
            myTxtMessage.IsBodyHtml = false;
            // 邮件内容
            myTxtMessage.Body = "这是在测试 C# 发送的电子邮件。";




            // 邮件消息类.
            MailMessage myHtmlMessage = GetMailMessage();
            // 是 HTML 格式.
            myHtmlMessage.IsBodyHtml = true;
            // 邮件内容
            myHtmlMessage.Body = "<html><body>  <h3> C# 测试发送邮件 </h3> <div>这是在测试 C# 发送的电子邮件。</div> </body></html>";



            // SMTP 客户端.
            SmtpClient client = new SmtpClient();

            // 发送邮件的用户名与密码.
            client.Credentials = new System.Net.NetworkCredential(mailUserName, mailPassword);

            // SMTP 服务器地址.
            client.Host = SmtpServerName;

            // 发送邮件. (文本格式的)
            client.Send(myTxtMessage);

            // 发送邮件. (Html格式的)
            client.Send(myHtmlMessage);
        }




        /// <summary>
        /// 获取一个邮件信息类.
        /// </summary>
        /// <returns></returns>
        private MailMessage GetMailMessage()
        {
            // 邮件消息类.
            MailMessage resultMessage = new MailMessage();
            // 收件人.
            resultMessage.To.Add(mailUserName);
            resultMessage.To.Add("test@test.com.cn");
            // 发件人
            resultMessage.From = new MailAddress(mailUserName, "IT");
            // 邮件主题.
            resultMessage.Subject = "C# 测试消息";

            // 返回.
            return resultMessage;
        }



    }
}
