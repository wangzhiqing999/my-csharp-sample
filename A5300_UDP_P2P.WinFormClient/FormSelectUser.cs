using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace A5300_UDP_P2P
{
    public partial class FormSelectUser : Form
    {

        public FormSelectUser()
        {
            InitializeComponent();
        }


        private List<string> userList;

        /// <summary>
        /// 用户列表.
        /// </summary>
        public List<string> UserList
        {
            set
            {
                userList = value;
                this.cboUser.DataSource = userList;
            }
            get
            {
                return userList;
            }
        }


        /// <summary>
        /// 已选择的用户.
        /// </summary>
        public string SelectUser
        {
            get
            {
                return this.cboUser.Text;
            }
            set
            {
                this.cboUser.Text = value;
            }
        }

    }
}
