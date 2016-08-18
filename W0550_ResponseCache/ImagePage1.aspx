<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImagePage1.aspx.cs" Inherits="W0550_ResponseCache.ImagePage1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> 测试需要长时间加载的页面 </title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <p> 包含大量图片的页面 </p>


        <img src="Image/Chrysanthemum.jpg" />
        <hr />

        <img src="Image/Desert.jpg" />
        <hr />


        <img src="Image/Hydrangeas.jpg" />
        <hr />

        <img src="Image/Jellyfish.jpg" />
        <hr />

        <img src="Image/Koala.jpg" />
        <hr />

        <img src="Image/Lighthouse.jpg" />
        <hr />

        <img src="Image/Penguins.jpg" />
        <hr />

        <img src="Image/Tulips.jpg" />
        

    </div>
    </form>
</body>
</html>
