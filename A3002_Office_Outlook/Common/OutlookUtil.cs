using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;

using Outlook = Microsoft.Office.Interop.Outlook;


using A3002_Office_Outlook.Model;


namespace A3002_Office_Outlook.Common
{


    public class OutlookUtil
    {

        /// <summary>
        /// OUTLOOK APP
        /// </summary>
        private Outlook.Application outlookApp = null;


        /// <summary>
        /// 内部 静态实例.
        /// </summary>
        private static OutlookUtil me = new OutlookUtil();


        /// <summary>
        /// 私有构造函数.
        /// </summary>
        private OutlookUtil()
        {
            // 创建 OUTLOOK APP
            outlookApp = new Microsoft.Office.Interop.Outlook.Application();
        }


        /// <summary>
        /// 获取实例.
        /// </summary>
        /// <returns></returns>
        public static OutlookUtil GetInstance()
        {
            return me;
        }





        #region  邮件.

        /// <summary>
        /// 保存邮件到 草稿.
        /// </summary>
        /// <param name="mailToList"></param>
        /// <returns></returns>
        public bool SendMailToUserList(List<UserAddressBook> mailToList)
        {
            StringBuilder buff = new StringBuilder();
            foreach (UserAddressBook oneLine in mailToList)
            {
                if (!String.IsNullOrEmpty(oneLine.Email))
                {
                    buff.AppendFormat(
                        "{0}<{1}> ; ", 
                        oneLine.UserName,
                        oneLine.Email);
                }
            }

            try
            {
                // 创建邮件.
                Outlook.MailItem newMail =
                    (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);

                // 收信者.
                newMail.To = buff.ToString();

                // 邮件标题
                newMail.Subject =
                        "邮件创建于：" + DateTime.Now.ToString("yyyyMMddHHmmss");

                // 保存到  “草稿” 文件夹.
                newMail.Save();



                // 如果要发送的话， 取消注释掉下面这行代码.
                // newMail.Send();


                return true;
            }
            catch
            {
                return false;
            }

        }



        #endregion






        #region  约会.


        /// <summary>
        /// 创建约会.
        /// </summary>
        /// <param name="satrtDateTime">开始时间</param>
        /// <param name="endDateTime">结束时间</param>
        /// <param name="reminderMinutesBeforeStart">提前多长时间提醒</param>
        /// <param name="subject">标题</param>
        /// <param name="body">内容</param>
        public void CreateAppointment(
            DateTime satrtDateTime, 
            DateTime endDateTime,
            int reminderMinutesBeforeStart,
            string subject,
            string body
            )
        {
            // 创建约会.
            Outlook.AppointmentItem outLookAppointmentItem =
                (Outlook.AppointmentItem)outlookApp.CreateItem(Outlook.OlItemType.olAppointmentItem);
            
            // 开始时间
            outLookAppointmentItem.Start = satrtDateTime;
            // 结束时间
            outLookAppointmentItem.End = endDateTime;

            // 提前多长时间提醒
            outLookAppointmentItem.ReminderMinutesBeforeStart = reminderMinutesBeforeStart;
            // 标题
            outLookAppointmentItem.Subject = subject;
            // 内容
            outLookAppointmentItem.Body = body;

            // 保存.
            outLookAppointmentItem.Save();

        }


        #endregion






        #region 地址簿.


        /// <summary>
        /// 获取 Outlook 地址簿列表.
        /// </summary>
        /// <returns></returns>
        public List<UserAddressBook> ReadAddressBookList()
        {
            List<UserAddressBook> resultList = new List<UserAddressBook>();

            Outlook.NameSpace mynamespace = outlookApp.GetNamespace("MAPI");
            Outlook.MAPIFolder myFolder = mynamespace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts);
            int iMailCount = myFolder.Items.Count;
            

            for (int k = 1; k <= iMailCount; k++)
            {
                Outlook.ContactItem item = (Outlook.ContactItem)myFolder.Items[k];

                UserAddressBook result = new UserAddressBook();

                // 姓名.
                result.UserName = item.LastName;

                // 邮件地址.
                result.Email = item.Email1Address;

                // 号码.
                result.Mobile = item.MobileTelephoneNumber;

                // 部门.
                result.Department = item.Department;

                // 加入列表.
                resultList.Add(result);
            }

            return resultList;
        }





        /// <summary>
        /// 保存 Outlook 地址簿.
        /// </summary>
        /// <param name="dataList"></param>
        public void WriteAddressBookList(List<UserAddressBook>  dataList)
        {
            Outlook.NameSpace mynamespace = outlookApp.GetNamespace("MAPI");
            Outlook.MAPIFolder myFolder = mynamespace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts);


            foreach (UserAddressBook newData in dataList)
            {
                // 存在标志.
                Outlook.ContactItem existContactItem = null;


                foreach (Outlook.ContactItem item in myFolder.Items)
                {
                    if (item.Email1Address == newData.Email)
                    {
                        existContactItem = item;
                        break;
                    }
                }



                if (existContactItem == null)
                {
                    // 地址簿中，没有检索到数据.
                    existContactItem = myFolder.Items.Add();

                     // 邮件地址.
                    existContactItem.Email1Address = newData.Email;
                }


                // 姓名.
                existContactItem.LastName = newData.UserName;

                // 号码.
                existContactItem.MobileTelephoneNumber = newData.Mobile;

                // 部门.
                existContactItem.Department = newData.Department;


                // 保存.
                existContactItem.Save();
            }
       
        }




        #endregion



    }


}
