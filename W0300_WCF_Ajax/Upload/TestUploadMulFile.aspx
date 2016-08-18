<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestUploadMulFile.aspx.cs" Inherits="W0300_WCF_Ajax.Upload.TestUploadMulFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> 一次上传多个文件 </title>



<script type="text/javascript">
    var i = 1
    function addFile() {

        if (i < 8) {
            var str = '<BR> <input type="file" name="File" runat="server" style="width: 200px"/>描述：<input name="text" type="text" style="width: 150px" maxlength="20" />'
            document.getElementById('MyFile').insertAdjacentHTML("beforeEnd", str)

        }
        else {
            alert("您一次最多只能上传8张图片！")
        }
        i++
    }
</script>


</head>




<body>
    <form id="form1" runat="server">
    <div>
    
      <p style="white-space: pre-wrap;">
      这个是直接从网上复制下来的。
      <br />
      处理逻辑是， 使用 js 动态生成  input type="file" 然后依次选择文件， 最后统一上传.
      </p>



        <table id="Table1" align="center" border="0" cellpadding="1" cellspacing="1" class="table">

            <tr>
                <td align="center">
                    <font color="#0000ff" face="宋体" size="3"><strong>上传图片</strong></font></td>
            </tr>
            <tr>
                <td align="center" style="width: 734px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" style="width: 734px">
                    <asp:Panel ID="Panel5" runat="server">
                        &nbsp; &nbsp;<table width="100%">
                            <tr>
                                <td align="right" style="width: 100px">
                                </td>
                                <td align="left" style="width: 500px">
                                    说明：点增加图片按钮可一次上传多张图片，可为每张图片写上一句不超过20个字的描述。单张图片大小不大于1024k</td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 100px">
                                    请选择图片：<br />
                                </td>
                                <td align="left" style="width: 500px"><p id="MyFile"><input onclick="addFile()" type="button" value="增加图片(Add)"></p><br />
                                    <input id="File1" type="file" name="File" runat="server" style="width: 245px"/>
                                    描述：<input name="text" type="text" style="width: 150px" maxlength="20" />
                                </td>
                            </tr>

                            <tr>
                                <td align="right" style="width: 100px">
                                </td>
                                <td align="left" style="width: 500px">
                                    <asp:Button ID="btnUpload" runat="server" Text="开始上传" OnClick="btnUpload_Click"  />
                                    </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 100px">
                                </td>
                                <td align="left" style="width: 500px">
                                    <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
                            </tr>
                        </table>
                    </asp:Panel>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" style="width: 734px">
                    <font face="宋体"></font><font face="宋体">&nbsp;</font>
                </td>
            </tr>
        </table>


    </div>
    </form>
</body>
</html>
