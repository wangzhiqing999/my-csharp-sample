using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace G0061_Pic_Mov
{
    public partial class UserControlPic2Mov : UserControl
    {
        public UserControlPic2Mov()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 图片列表.
        /// </summary>
        private List<Image> picList;

        /// <summary>
        /// 图片索引.
        /// </summary>
        private int picIndex = 0;

        


        /// <summary>
        /// 基础图片对象.
        /// </summary>
        private Bitmap basicImage;

        /// <summary>
        /// 基础图片.
        /// </summary>
        public Bitmap BasicImage {
            set
            {
                basicImage = value;
                LoadDesignImage();
            }
            get 
            { 
                return basicImage; 
            }
        }




        /// <summary>
        /// 基础图片中，包含几列.
        /// </summary>
        private int colCount = 8;

        /// <summary>
        /// 基础图片中，包含几列.
        /// </summary>
        public int ColCount {
            set
            {
                colCount = value;

                if (colCount <= 0)
                {
                    // "列数必须要大于零！"
                    rowCount = 1;
                }
                
                LoadDesignImage();
            }
            get
            {
                return colCount;
            }
        }




        /// <summary>
        /// 基础图片中，包含几行.
        /// </summary>
        private int rowCount = 1;

        /// <summary>
        /// 基础图片中，包含几行.
        /// </summary>
        public int RowCount {
            set
            {
                rowCount = value;

                if (rowCount <= 0)
                {
                    // "行数必须要大于零！"
                    rowCount = 1;
                }

                
                if (rowIndex >= rowCount)
                {
                    rowIndex = 0;
                }

                LoadDesignImage();
            }
            get
            {
                return rowCount;
            }
        }



        /// <summary>
        /// 当画面包含多组画面时， 显示第几行的画面.
        /// </summary>
        private int rowIndex;


        /// <summary>
        /// 当画面包含多组画面时， 显示第几行的画面. (从0开始)
        /// </summary>
        public int RowIndex {
            set
            {
                rowIndex = value;

                if (rowIndex < 0)
                {
                    // 行数必须要大于零！
                    rowIndex = 0;
                }
                if (rowIndex >= RowCount)
                {
                    // 行数不能大于初始图片总行数！
                    rowIndex = 0;
                }                
                LoadDesignImage();
            }
            get
            {
                return rowIndex;
            }
        }




        /// <summary>
        /// 设置时间.
        /// </summary>
        public int Interval
        {
            set
            {
                this.timerMov.Interval = value;
            }
            get
            {
                return this.timerMov.Interval;
            }            
        }


        /// <summary>
        /// 初始化.
        /// </summary>
        public void InitMov()
        {
            this.picList = GetSubList(BasicImage, RowIndex);
        }


        /// <summary>
        /// 开始动画.
        /// </summary>
        public void Start()
        {
            this.timerMov.Start();
        }

        /// <summary>
        /// 结束动画.
        /// </summary>
        public void Stop()
        {
            this.timerMov.Stop();
        }


        /// <summary>
        /// 动画处理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerMov_Tick(object sender, EventArgs e)
        {
            // 设置当前图片.
            this.picUser.Image = this.picList[picIndex];

            // 递增图片索引.
            picIndex++;
            if (picIndex >= this.picList.Count())
            {
                picIndex = 0;
            }
        }



        /// <summary>
        /// 加载设计模式下的图片.
        /// </summary>
        private void LoadDesignImage()
        {
            if (basicImage == null)
            {
                // 图片不存在.
                return;
            }

            


            if (this.DesignMode)
            {
                // 每个子画面的宽
                int everyWidth = basicImage.Width / this.ColCount;
                // 每个子画面的高.
                int everyHeight = basicImage.Height / this.RowCount;

                // 设置画面的图片.
                this.picUser.Image = CopyBitMap(basicImage,
                    0, this.RowIndex * everyHeight,
                    everyWidth, (this.RowIndex + 1) * everyHeight);
            }
        }



        /// <summary>
        /// 分割主画面.
        /// </summary>
        /// <param name="mainImg"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private List<Image> GetSubList(Bitmap mainImg, int index)
        {
            // 每个子画面的宽
            int everyWidth = mainImg.Width / this.ColCount ;
            // 每个子画面的高.
            int everyHeight = mainImg.Height / this.RowCount;

            List<Image> resultList = new List<Image>();
            for (int i = 0; i < this.ColCount; i++)
            {
                Image subBitMap =
                    CopyBitMap(
                        mainImg, i * everyWidth, index * everyHeight,
                                 (i + 1) * everyWidth, (index + 1) * everyHeight);
                resultList.Add(subBitMap);
            }
            return resultList;
        }


        /// <summary>
        /// 画面分割处理.
        /// </summary>
        /// <param name="sourceBitMap">源画面</param>
        /// <param name="x1">左上角 X坐标</param>
        /// <param name="y1">左上角 Y坐标</param>
        /// <param name="x2">右上角 X坐标</param>
        /// <param name="y2">右上角 Y坐标</param>
        /// <returns></returns>
        public static Image CopyBitMap(Bitmap sourceBitMap, int x1, int y1, int x2, int y2)
        {
            // 初始化画面.
            Bitmap result = new Bitmap(x2 - x1, y2 - y1);
            // 遍历坐标，设置像素的颜色.
            for (int i = x1; i < x2; i++)
            {
                for (int j = y1; j < y2; j++)
                {
                    result.SetPixel(i - x1, j - y1, sourceBitMap.GetPixel(i, j));
                }
            }
            // 返回结果.
            return result;
        }


    }
}
