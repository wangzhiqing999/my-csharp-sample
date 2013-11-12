using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using G0001_Sudoku.Model;
using G0001_Sudoku.Service;


namespace G0001_Sudoku
{
    public partial class Form9x9 : Form
    {
        public Form9x9()
        {
            InitializeComponent();
        }




        /// <summary>
        /// 画面上的输入控件.
        /// </summary>
        private TextBox[,] displayDataArray = new TextBox[9, 9];


        /// <summary>
        /// 用于计算的数组.
        /// </summary>
        private int[,] inputDataArray = new int[9, 9];





        // 测试数据.
        // http://zh.wikipedia.org/wiki/%E6%95%B8%E7%8D%A8
        //int[,] testDataArray = new int[,] { 
        //    {5,3,0,0,7,0,0,0,0},
        //    {6,0,0,1,9,5,0,0,0},
        //    {0,9,8,0,0,0,0,6,0},
        //    {8,0,0,0,6,0,0,0,3},
        //    {4,0,0,8,0,3,0,0,1},
        //    {7,0,0,0,2,0,0,0,6},
        //    {0,6,0,0,0,0,2,8,0},
        //    {0,0,0,4,1,9,0,0,5},
        //    {0,0,0,0,8,0,0,7,9}
        //};




        //int[,] testDataArray = new int[,] { 
        //    {0,4,0,  0,8,0,  0,0,0},
        //    {8,0,0,  5,7,3,  9,0,0},
        //    {0,0,0,  2,9,0,  0,1,0},

        //    {0,9,5,  0,0,0,  0,8,0},
        //    {4,3,7,  0,0,0,  1,9,5},
        //    {0,2,0,  0,0,0,  6,4,0},
                             
        //    {0,1,0,  0,6,9,  0,0,0},
        //    {0,0,9,  3,4,8,  0,0,1},
        //    {0,0,0,  0,5,0,  0,3,0}
        //};



       //int[,] testDataArray = new int[,] { 
       //    {0,0,0,  3,0,2,  0,0,0},
       //    {0,9,7,  0,0,0,  3,5,0},
       //    {0,3,0,  0,5,0,  0,1,0},

       //    {9,0,0,  8,0,5,  0,0,6},
       //    {0,0,2,  0,3,0,  9,0,0},
       //    {5,0,0,  6,0,1,  0,0,3},

       //    {0,6,0,  0,1,0,  0,3,0},
       //    {0,5,9,  0,0,0,  8,6,0},
       //    {0,0,0,  9,0,6,  0,0,0}
       //};




        /// <summary>
        /// 数据构造类.
        /// </summary>
        ItemMasterCreater9x9 itemMasterCreater = new ItemMasterCreater9x9();

        /// <summary>
        /// 主数据.
        /// </summary>
        ItemMaster itemMaster = null;



        /// <summary>
        /// 主画面初始化.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form9x9_Load(object sender, EventArgs e)
        {
            // 初始化 9x9 的输入框表格.
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {

                    displayDataArray[i, j] = new TextBox()
                    {
                        Dock = DockStyle.Fill,
                        Anchor = AnchorStyles.None,
                        TextAlign = HorizontalAlignment.Center 
                    };

                    this.tlpMain.Controls.Add(displayDataArray[i, j]);
                }
            }

        }





        /// <summary>
        /// 初始化.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInit_Click(object sender, EventArgs e)
        {


            // 读取用户输入.
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Int32.TryParse(displayDataArray[i, j].Text, out inputDataArray[i, j]);
                }
            }

            // 初始化.
            itemMaster = itemMasterCreater.CreateItemMaster(inputDataArray);


            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    AbstractItem item = itemMaster[i, j];

                    if (item is DynamicsItem)
                    {
                        displayDataArray[i, j].Text = ((DynamicsItem)item).GetDefaultUsableValu();
                        displayDataArray[i, j].ForeColor = Color.Red;
                    }
                    else
                    {
                        displayDataArray[i, j].ReadOnly = true;
                    }                    
                }
            }

        }


        /// <summary>
        /// 数据处理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            itemMaster.ResetAllData();
            itemMaster.DoProcess();


            // 画面显示
            for (int j = 0; j < 9; j++)
            {
                for (int i = 0; i < 9; i++)
                {
                    displayDataArray[i, j].Text = itemMaster[i, j].ResultValue().ToString();
                }
            }


            MessageBox.Show("OK!");
        }




    }
}
