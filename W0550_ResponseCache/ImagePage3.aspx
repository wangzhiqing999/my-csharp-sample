<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImagePage3.aspx.cs" Inherits="W0550_ResponseCache.ImagePage3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title> 测试需要长时间加载的页面 </title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <p> 包含大量图片的页面 </p>


        <h4> CSS + png 背景 （无缓存）  </h4>
        <div style="background:url(/Image9/Hydrangeas.png) center no-repeat; width:1150px; height:507px; margin:0 auto;">
        </div>

        <hr />


        <h4> CSS + jpg 背景   IIS   caching  缓存  </h4>
        <div style="background:url(/Image/Chrysanthemum.jpg) center no-repeat; width:1150px; height:507px; margin:0 auto;">
        </div>

        <hr />


        <h4> CSS + gif 背景  IIS   staticContent 缓存  </h4>
        <div style="background:url(/Image2/Desert.gif) center no-repeat; width:1150px; height:507px; margin:0 auto;">
        </div>
        <hr />


        

    </div>
    </form>
</body>
</html>