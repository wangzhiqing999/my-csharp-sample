<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadPreview.aspx.cs" Inherits="W0300_WCF_Ajax.Upload.UploadPreview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title> 图片上传预览 </title>

    <script src="../Scripts/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.form.js" type="text/javascript"></script>


<script type="text/javascript">


    var ajaxOptionsUpload = {
        beforeSubmit: function () {
            // alert("OK0");
        },
        success: function (responseText) {
            // alert("OK!");
            // 增加 预览项目.
            $("#picPreviewTr").append('<td class="preview_td"><img class="preview_image" alt="" src="' + responseText + '" /></td>');

            // 暂存文件.
            var vFileName = $("#<%=hfPicFileList.ClientID %>").val();
            if (vFileName == "") {
                $("#<%=hfPicFileList.ClientID %>").val(responseText);
            } else {
                $("#<%=hfPicFileList.ClientID %>").val(vFileName + ";" + responseText);
            }
        },
        url: "/Upload/ImgUploadHandler.ashx",
        error: function (response) {
            alert('操作失败！');
        }
    };


    $(document).ready(function () {

        // 图片选择发生变化.
        $("#pic").change(function () {

            if ($(this).val() == "") {
                return;
            }

            $("#submitform").ajaxSubmit(ajaxOptionsUpload);
            
        });

    });
</script>





<style type="text/css">

.preview_td
{
    width:100px;
    height:100px;
}

.preview_image
{
    z-index:10;
    width:100px;
    height:100px;
    max-width : 100px; 
    max-height : 100px;
}

</style>



</head>
<body>

<form id="submitform" method="post" action="/Upload/ImgUploadHandler.ashx" enctype="multipart/form-data">    
    <input type="file" id="pic" name="pic" />
</form>




处理机制： 选择文件后，自动后台上传，并返回服务器路径，然后画面上面显示从服务器上下载的图片.

<form id="form1" runat="server">



<!-- 图片预览部分 -->
<table id="picPreviewTab" border="1">
  <tr id="picPreviewTr">
  </tr>
</table>




<asp:Button ID="btnFinish" runat="server" Text="确定" onclick="btnFinish_Click" />


<asp:HiddenField ID="hfPicFileList" runat="server" />

<asp:Label ID="lblUploadFileName" runat="server" Text="-"></asp:Label>


</form>





</body>
</html>
