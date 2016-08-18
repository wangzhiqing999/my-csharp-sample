using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;


namespace W0300_WCF_Ajax.Upload
{
    public partial class TestUploadMulFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }




        protected void btnUpload_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            lblMessage.Visible = false;
            System.Web.HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            System.Text.StringBuilder strmsg = new System.Text.StringBuilder("");

            //获得图片描述的文本框字符串数组，为对应的图片的描述
            string[] rd = Request.Form[1].Split(',');

            //string albumid=ddlAlbum.SelectedValue.Trim();
            int ifile;
            for (ifile = 0; ifile < files.Count; ifile++)
            {
                if (files[ifile].FileName.Length > 0)
                {
                    System.Web.HttpPostedFile postedfile = files[ifile];
                    if (postedfile.ContentLength / 1024 > 1024)//单个文件不能大于1024k
                    {
                        strmsg.Append(Path.GetFileName(postedfile.FileName) + "---不能大于1024k<br>");
                        break;
                    }
                    string fex = Path.GetExtension(postedfile.FileName);
                    if (fex != ".jpg" && fex != ".JPG" && fex != ".gif" && fex != ".GIF")
                    {
                        strmsg.Append(Path.GetFileName(postedfile.FileName) + "---图片格式不对，只能是jpg或gif<br>");
                        break;
                    }
                }
            }


            // 说明图片大小和格式都没问题
            if (strmsg.Length <= 0)
            {
                //以下为创建图库目录
                string dirpath = Server.MapPath("~/UploadImages");

                if (Directory.Exists(dirpath) == false)
                {
                    Directory.CreateDirectory(dirpath);
                }
                Random ro = new Random();
                int name = 1;
                for (int i = 0; i < files.Count; i++)
                {
                    System.Web.HttpPostedFile myFile = files[i];
                    string FileName = "";
                    string FileExtention = "";
                    FileName = System.IO.Path.GetFileName(myFile.FileName);
                    string stro = ro.Next(100, 100000000).ToString() + name.ToString();//产生一个随机数用于新命名的图片
                    string NewName = DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + stro;
                    if (FileName.Length > 0)//有文件才执行上传操作再保存到数据库
                    {
                        FileExtention = System.IO.Path.GetExtension(myFile.FileName);

                        string ppath = dirpath + @"\" + NewName + FileExtention;
                        myFile.SaveAs(ppath);

                    }

                    name = name + 1;//用来重命名规则的变量

                }

                Response.Write("<script>alert('恭喜，图片上传成功！')</script>");
            }
            else
            {
                lblMessage.Text = strmsg.ToString();
                lblMessage.Visible = true;
            }
        }


    }
}