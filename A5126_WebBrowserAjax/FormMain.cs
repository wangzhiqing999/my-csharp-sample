using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;


namespace A5126_WebBrowserAjax
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            pnlFoot.Visible = false;
        }



        private void btnGo_Click(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate(this.txtUrl.Text);
        }


        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            lblStatus.Text = "DocumentCompleted";
            pnlFoot.Visible = true;

            
        }


        /// <summary>
        /// 显示 HTML.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowHtml_Click(object sender, EventArgs e)
        {
            MessageBox.Show(webBrowser1.DocumentText);
        }


        /// <summary>
        /// 调用脚本1. (无参数)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCallScript1_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.InvokeScript("PageScript1"); 
        }

        /// <summary>
        /// 调用脚本2. (有参数)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCallScript2_Click(object sender, EventArgs e)
        {
            object[] scriptParams = new object[1];
            scriptParams[0] = this.txtParamValue.Text;
            webBrowser1.Document.InvokeScript("PageScript2", scriptParams); 
        }


        /// <summary>
        /// 调用脚本3. (无参数, 有返回值)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCallScript3_Click(object sender, EventArgs e)
        {
            object result = webBrowser1.Document.InvokeScript("PageScript3");
            MessageBox.Show("调用 js 后， 从 js 获取的返回值：" + result);
        }


        /// <summary>
        /// 调用脚本4. (有参数, 有返回值)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCallScript4_Click(object sender, EventArgs e)
        {
            object[] scriptParams = new object[1];
            scriptParams[0] = this.txtParamValue.Text;

            object result = webBrowser1.Document.InvokeScript("PageScript4", scriptParams);
            MessageBox.Show("调用 js 后， 从 js 获取的返回值：" + result);
        }




        /// <summary>
        /// 注入脚本， 并执行.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAppendScript1_Click(object sender, EventArgs e)
        {
            // 定义脚本.
            HtmlElement ele = webBrowser1.Document.CreateElement("script");
            ele.SetAttribute("type", "text/javascript") ;
            ele.SetAttribute("text", @"
function sayHelloWorld(){
    alert('Hello World !');
}");

            // 注入.
            webBrowser1.Document.Body.AppendChild(ele);

            // 调用.
            webBrowser1.Document.InvokeScript("sayHelloWorld");
        }



        /// <summary>
        /// 注入脚本， 并执行.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAppendScript2_Click(object sender, EventArgs e)
        {

            // 定义脚本.
            HtmlElement ele = webBrowser1.Document.CreateElement("script");
            ele.SetAttribute("type", "text/javascript");
            ele.SetAttribute("text", @"
        function GetPictureData() {                                   
            var vResult = new Array();

            // 取得表格.
            var vTable = $('#ResultTable');

            // 取得处理结果行.
            var vResultTr = vTable.find('tr').first();
            // 取得处理结果描述行.
            var vResultMessageTr = vResultTr.next();
            // 取得用户代码行
            var vUserCode = vResultMessageTr.next();
            // 取得用户姓名行.
            var vUserName = vUserCode.next();

            // 取得卡片标题行.
            var vCardTitle = vUserName.next();


            vResult['Result'] = vResultTr.children('td').last().html();
            vResult['ResultMessage'] = vResultMessageTr.children('td').last().html();
            vResult['UserCode'] = vUserCode.children('td').last().html();
            vResult['UserName'] = vUserName.children('td').last().html();


            var vCardIndex = 0;

            vCardTitle.nextAll().each(function () {
                vResult['Card' + (vCardIndex++).toString()] = $(this).children('td').last().html();
            });

            vResult['CardCount'] = vCardIndex;

            return vResult;
        }");


            // 注入.
            webBrowser1.Document.Body.AppendChild(ele);

            object result = webBrowser1.Document.InvokeScript("GetPictureData");
            MessageBox.Show("调用 js 后， 从 js 获取的返回值：" + result);


            StringBuilder buff = new StringBuilder();
            buff.AppendFormat("处理结果:{0};", GetJScriptArrayItem(result, "Result"));
            buff.AppendLine();
            buff.AppendFormat("处理结果描述:{0};", GetJScriptArrayItem(result, "ResultMessage"));
            buff.AppendLine();
            buff.AppendFormat("用户代码:{0};", GetJScriptArrayItem(result, "UserCode"));
            buff.AppendLine();
            buff.AppendFormat("用户姓名:{0};", GetJScriptArrayItem(result, "UserName"));
            buff.AppendLine();

            int cardCount = Convert.ToInt32(GetJScriptArrayItem(result, "CardCount"));

            buff.AppendFormat("卡片数:{0};", cardCount);
            buff.AppendLine();

            for (int i = 0; i < cardCount; i++)
            {
                buff.AppendFormat("卡片{0}: {1}", i + 1, GetJScriptArrayItem(result, "Card" + i));
                buff.AppendLine();
            }


            MessageBox.Show(buff.ToString());

        }







        /// <summary>
        /// 从 js 返回的数组对象中，获取相应的数据.
        /// 
        /// 从 http://bbs.csdn.net/topics/80061970 获取的代码.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private object GetJScriptArrayItem(object arr, string key)
        {
            Guid arr_gid = new Guid("{3EEF9758-35FC-11D1-8CE4-00C04FC2B092}");
            Type JScriptArray = Type.GetTypeFromCLSID(arr_gid);
            object p;
            try
            {
                p = JScriptArray.InvokeMember(key, BindingFlags.GetProperty, null, arr, null);
            }
            catch (Exception) { return null; }
            return p;
        }

 

    }
}
