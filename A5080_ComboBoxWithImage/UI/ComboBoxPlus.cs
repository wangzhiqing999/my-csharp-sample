using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;



namespace A5080_ComboBoxWithImage.UI
{
    public partial class ComboBoxPlus : ComboBox
    {
        public ComboBoxPlus()
        {
            InitializeComponent();

            // 不允许用户直接输入信息.
            this.DropDownStyle = ComboBoxStyle.DropDownList;

            // 只有设置这个属性为OwnerDrawFixed才可能让重画起作用
            this.DrawMode = DrawMode.OwnerDrawFixed;
        }

        /// <summary>
        /// 图片对应的属性名称.
        /// </summary>
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        [Description("指示要为控件中指示的图片的属性"), Category("数据"), Browsable(true)]
        public string ImageMember { set; get; }


        /// <summary>
        /// 在 this.DropDownStyle = ComboBoxStyle.DropDownList 模式下
        /// 手动绘制 选项数据.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            if (e.Index == -1)
            {
                // 避免设计环境下出错.
                return;
            }
            // 绘制背景
            e.DrawBackground();
            // 文字颜色.
            Brush myBrush = Brushes.Black;
            if (e.ForeColor.Name == "HighlightText")
            {
                // 没有 Color 转换为 Brush 的处理啊， 这里只好硬编码了.
                myBrush = Brushes.White;
            }

            // 用于暂存 列表的文本信息.
            string displayText = "";
            // 用于暂存 列表的 图片文件名信息.
            string displayImageFileName = "";

            // 判断下拉列表中元素的数据类型.
            if (this.Items[e.Index] is DataRowView)
            {
                // 每一行数据是一个 DataRow 
                // 通过 DataRow 的 DisplayMember 字段来获取.
                displayText = (this.Items[e.Index] as DataRowView)[this.DisplayMember].ToString();
                displayImageFileName = (this.Items[e.Index] as DataRowView)[this.ImageMember].ToString();
            }
            else
            {
                if (!String.IsNullOrEmpty(this.DisplayMember)
                    && this.DisplayMember != this.ValueMember)
                {
                    // 不是  DataRow 的， 但是是通过 数据绑定 DisplayMember 的
                    // 通过反射 获取 具体数据.
                    Type t = this.Items[e.Index].GetType();
                    PropertyInfo propInfo = t.GetProperty(this.DisplayMember);
                    displayText = propInfo.GetValue(this.Items[e.Index], null).ToString();
                }
                else
                {
                    // 不是 DataRow 的, 也没有设置 DisplayMember 的
                    // 简单获取 ToString() 方法.
                    displayText = this.Items[e.Index].ToString();
                }


                if (!String.IsNullOrEmpty(this.ImageMember))
                {
                    Type t = this.Items[e.Index].GetType();
                    PropertyInfo propInfo = t.GetProperty(this.ImageMember);
                    displayImageFileName = propInfo.GetValue(this.Items[e.Index], null).ToString();
                }
            }


            if (!String.IsNullOrEmpty(displayImageFileName))
            {
                // 加载图片信息.
                Bitmap myImage = new Bitmap(displayImageFileName);

                // 调用缩略图方法所需要的一个委托.
                Image.GetThumbnailImageAbort myCallback =
                    new Image.GetThumbnailImageAbort(ThumbnailCallback);

                // 缩略图 （大小为控件大小  正方形）
                Image resizeImage = myImage.GetThumbnailImage(
                    e.Bounds.Height - 2, e.Bounds.Height - 2, myCallback, IntPtr.Zero);

                // 有图片， 先画图.
                e.Graphics.DrawImage(resizeImage, e.Bounds.Left + 1, e.Bounds.Top + 1);
            }

            // 输出文字.
            e.Graphics.DrawString(displayText,
                e.Font, myBrush, e.Bounds.Left + this.Height + 2, e.Bounds.Top, StringFormat.GenericDefault);

            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }


        public bool ThumbnailCallback()
        {
            return false;
        }

    }
}
