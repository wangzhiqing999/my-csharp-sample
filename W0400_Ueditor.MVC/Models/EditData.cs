using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;



namespace W0400_Ueditor.MVC.Models
{
    public class EditData
    {

        /// <summary>
        /// 文章内容.
        /// </summary>
        [Display(Name = "文章内容")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Html)]
        public string editor { set; get; }









        public static string LINE_KEYWORD = "_ueditor_page_break_tag_";



        /// <summary>
        /// 完整文档内容.
        /// </summary>
        [DataType(System.ComponentModel.DataAnnotations.DataType.Html)]
        public string FullText
        {
            get
            {
                // 简单移除  文档换行关键字
                string result = this.editor.Replace(LINE_KEYWORD, "");
                return result;
            }
        }


        /// <summary>
        /// 用于演示的部分文档内容.
        /// </summary>
        [DataType(System.ComponentModel.DataAnnotations.DataType.Html)]
        public string DemoText
        {
            get
            {
                // 获取  文档换行关键字 的标志.
                int place = this.editor.IndexOf(LINE_KEYWORD);
                if (place < 0)
                {
                    // 文章中不包含  文档换行关键字.
                    // 完整返回.
                    return this.editor;
                }

                // 仅仅返回  文档换行关键字之前的文章部分
                string result = this.editor.Substring(0, place);


                if (String.IsNullOrEmpty(AskLoginHtmlInfo))
                {

                    result = result + "<p class='AskLogin'> 请<a href='#'>登录</a>后查看完整文档内容 </p>";
                }
                else
                {
                    result = result + AskLoginHtmlInfo;
                }

                return result;
            }
        }




        /// <summary>
        /// 要求登录的文字信息.
        /// (因为  请登录那段信息的 html， 写在代码里面，不是很合适的，需要允许外部设置这个内容。)
        /// </summary>
        public string AskLoginHtmlInfo { set; get; }




    }


}