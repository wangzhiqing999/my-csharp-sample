using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace A5121_WebBrowserHtmlText
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }



        private void btnTest_Click(object sender, EventArgs e)
        {

            this.webBrowser1.DocumentText = this.txtHtml.Text;
 
        }



        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.txtText.Text = "";

            foreach (HtmlElement item in this.webBrowser1.Document.All)
            {
                if (!String.IsNullOrEmpty(item.InnerHtml))
                {
                    this.txtText.AppendText(item.InnerText);
                }

            }
        }





    }
}
