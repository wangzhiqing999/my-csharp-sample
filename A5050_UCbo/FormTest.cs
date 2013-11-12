using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace A5050_UCbo
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }



        /// <summary>
        /// 用于模拟的测试数据.
        /// </summary>
        private List<TestClass> testList = new List<TestClass>();


        /// <summary>
        /// 初始化.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormTest_Load(object sender, EventArgs e)
        {
            testList.Add(new TestClass(1, "测试模糊匹配"));
            testList.Add(new TestClass(2, "测试模糊AB"));
            testList.Add(new TestClass(3, "测试BC匹配"));
            testList.Add(new TestClass(4, "CD模糊匹配"));
            testList.Add(new TestClass(5, "ABCDEF"));

            this.myComboBoxEx1.DisplayMember = "Name";
            this.myComboBoxEx1.ValueMember = "Code";
            this.myComboBoxEx1.DataSource = testList;
            
        }
    }
}
