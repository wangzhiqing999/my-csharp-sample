using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Net;
using System.Web.Mail;



namespace A1050_Email.Sample
{
    class WebMailSender
    {




        public static void TestSendMail(string mailTo)
        {

            // 配置信息.
            Properties.Settings config = Properties.Settings.Default;



            
            // 邮件消息类.
            MailMessage resultMessage = new MailMessage();


            // 收件人.
            resultMessage.To = mailTo;
            // 发件人
            resultMessage.From = config.MailUserName;

            // 邮件主题.
            resultMessage.Subject = "测试 C# 发送电子邮件标题.";

            // 是 纯文本 格式.
            resultMessage.BodyFormat = System.Web.Mail.MailFormat.Text;  

            // 邮件内容
            resultMessage.Body = "测试 C# 发送电子邮件内容.";



            resultMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1"); //身份验证  

            // 邮箱登录账号，这里跟前面的发送账号一样就行  
            resultMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", config.MailUserName);

            // 这个密码要注意：如果是一般账号，要用授权码；企业账号用登录密码  
            resultMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", config.MailPassword);

            // 端口  
            resultMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", config.SmtpServerPort);


            if (config.SmtpServerPort != 25)
            {
                // SSL加密  
                resultMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true");
            }



            // 企业账号用smtp.exmail.qq.com  
            System.Web.Mail.SmtpMail.SmtpServer = config.SmtpServerName;    


            System.Web.Mail.SmtpMail.Send(resultMessage);  


        }



    }
}
