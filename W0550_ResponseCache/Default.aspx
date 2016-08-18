<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="W0550_ResponseCache.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> 测试 缓存页面 </title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    

    <ul>
    
      <li>
        <a href="LongTimePage1.aspx"> 长时间加载的页面（未设置缓存） </a>
      </li>

      <li>
        <a href="LongTimePage2.aspx"> 长时间加载的页面（以编程方式设置页的可缓存性） </a>
      </li>
    
      <li>
        <a href="LongTimePage3.aspx"> 长时间加载的页面（以声明方式设置页的可缓存性） </a>
      </li>
    
      <li>
        <a href="LongTimePage4.aspx"> 长时间加载的页面（以编程方式 ） </a>
      </li>





      <li>
        <a href="ImagePage.aspx"> 包含大量图片的页面（ .png  文件, 未设置缓存！）  </a>
      </li>
      <li>
        <a href="ImagePage1.aspx"> 包含大量图片的页面（ 通过 IIS   caching  缓存  .jpg  文件） </a>
      </li>
      <li>
        <a href="ImagePage2.aspx"> 包含大量图片的页面（ 通过 IIS   staticContent 缓存 ~/Image2 目录下的静态内容） （建议使用此方式） </a>
      </li>


      <li>
        <a href="ImagePage3.aspx"> 图片是 CSS 的 background 方式加载的 </a>
      </li>

    </ul>


<h3> 测试方式 </h3>

<p>
使用 Google 浏览器， 按 F12,  选择  Network 选项. 观察 访问的时间，以及 Cache 的情况。
<br />
使用 IE 浏览器， 按 F12, 也可以， 就是看不到是否 Cache 的字样.
</p>


<p>
通过 IIS 缓存图片的机制,  某些是通过 服务器返回 状态 304 来实现的。  某些是直接 本地 Cache 来实现的。
</p>





<p>
具体信息， 参考：
http://msdn.microsoft.com/zh-cn/library/System.Web.HttpCachePolicy(v=vs.100).aspx
</p>

    </div>
    </form>
</body>
</html>
