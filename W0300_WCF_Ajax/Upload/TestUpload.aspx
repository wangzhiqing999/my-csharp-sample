<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestUpload.aspx.cs" Inherits="W0300_WCF_Ajax.Upload.TestUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> 测试上传文件 </title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    

<table style="width:80%">

  <tr>
    <td> 需要上传的文件: </td>
    <td> <asp:FileUpload ID="FileUpload1" runat="server" /> </td>
  </tr>

  <tr>
    <td colspan="2" style="text-align: center">
        <asp:Button ID="btnUpload" runat="server" Text="上传文件" 
            onclick="btnUpload_Click" />               
    </td>      
  </tr>


  <tr>
    <td > 上传结果. </td>
    <td >  
        <asp:Label ID="lblResult" runat="server" Text="-"></asp:Label>
    </td>    
  </tr>


  <tr>
    <td > 客户端文件名. </td>
    <td >  
        <asp:Label ID="lblClientFileName" runat="server" Text="-"></asp:Label>
    </td>    
  </tr>


  <tr>
    <td > 服务器文件名. </td>
    <td >  
        <asp:Label ID="lblServerFileNam" runat="server" Text="-"></asp:Label>
    </td>    
  </tr>



  

</table>





    </div>
    </form>
</body>
</html>
