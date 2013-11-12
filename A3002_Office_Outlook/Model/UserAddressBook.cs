using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A3002_Office_Outlook.Model
{


    /// <summary>
    /// 用户地址簿.
    /// </summary>
    public class UserAddressBook
    {

        #region 基础数据.

        /// <summary>
        /// 姓名
        /// </summary>
        private string userName;

        /// <summary>
        /// 分机号码
        /// </summary>
        private string subPhone;

        /// <summary>
        /// 手机号码
        /// </summary>
        private string mobile;

        /// <summary>
        /// 电子邮件地址
        /// </summary>
        private string email;

        /// <summary>
        /// 部门
        /// </summary>
        private string department;


        /// <summary>
        /// 姓名
        /// </summary>
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName= value;
            }
        }

        /// <summary>
        /// 分机号码
        /// </summary>
        public string SubPhone
        {
            get
            {
                return subPhone;
            }
            set
            {
                subPhone= value;
            }
        }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile
        {
            get
            {
                return mobile;
            }
            set
            {
                mobile= value;
            }
        }

        /// <summary>
        /// 电子邮件地址
        /// </summary>
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email= value;
            }
        }

        /// <summary>
        /// 部门
        /// </summary>
        public string Department
        {
            get
            {
                return department;
            }
            set
            {
                department= value;
            }
        }





        #endregion





        public override string ToString()
        {
            StringBuilder buff = new StringBuilder();
            buff.Append("UserAddressBook(");
            buff.AppendFormat("UserName={0}; ", userName);
            buff.AppendFormat("SubPhone={0}; ", subPhone);
            buff.AppendFormat("Mobile={0}; ", mobile);
            buff.AppendFormat("Email={0}; ", email);
            buff.AppendFormat("Department={0}", department);

            return base.ToString();
        }



    }




}
