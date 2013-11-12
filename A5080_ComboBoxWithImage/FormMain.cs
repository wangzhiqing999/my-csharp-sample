using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace A5080_ComboBoxWithImage
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            List<TestData> testDataList = new List<TestData>();
            testDataList.Add(new TestData() { Code = "001", DisplayName = "支援型布兰奇芙蓉", PicName = @"full_thumbnail_chara_100_horo.png" });
            testDataList.Add(new TestData() { Code = "002", DisplayName = "第二型卡多", PicName = @"full_thumbnail_chara_105_horo.png" });
            testDataList.Add(new TestData() { Code = "003", DisplayName = "特异型罗宾汉", PicName = @"full_thumbnail_chara_27_horo.png" });
            testDataList.Add(new TestData() { Code = "005", DisplayName = "支援型律涅特", PicName = @"full_thumbnail_chara_49_horo.png" });
            testDataList.Add(new TestData() { Code = "006", DisplayName = "特异型维尔薇尤", PicName = @"full_thumbnail_chara_56_horo.png" });
            testDataList.Add(new TestData() { Code = "007", DisplayName = "特异型达芬奇", PicName = @"full_thumbnail_chara_96_horo.png" });

            this.comboBoxPlus1.DataSource = testDataList;
            this.comboBoxPlus1.DisplayMember = "DisplayName";
            this.comboBoxPlus1.ValueMember = "Code";
            this.comboBoxPlus1.ImageMember = "PicName";

            this.comboBox1.DataSource = testDataList;
            this.comboBox1.DisplayMember = "DisplayName";
            this.comboBox1.ValueMember = "Code";
        }
    }
}
