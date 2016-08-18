<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LongTimePage2.aspx.cs" Inherits="W0550_ResponseCache.LongTimePage2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> 测试需要长时间加载的页面  </title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    测试需要长时间加载的页面


    <p>
    本页面设置缓存为5分钟，因此，首次访问速度会花费一定时间， 后续请求将直接使用缓存。
    </p>

    </div>
    </form>
</body>
</html>
