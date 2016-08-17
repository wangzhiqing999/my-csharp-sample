<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IIS0010_URLrewriting.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

<style>
.Desc 
{
    color:Blue;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <p>
    本项目用于测试 IIS 的 URL Rewrite module.
    </p>


    <p>
    URL Rewrite module 需要额外下载安装程序进行安装 
    </p>

    <p>
    参考页面: http://www.iis.net/learn/extensions/url-rewrite-module/using-the-url-rewrite-module
    </p>

    <p>
    配置参考： http://www.iis.net/learn/extensions/url-rewrite-module/url-rewrite-module-configuration-reference
    </p>


    <p>
    安装完毕后， 在 IIS 中， 选择网站以后， 会看到  URL Rewrite 的图标.
    </p>
    


    <p>
    本页面配置 IE 可以访问，  FireFox 与 Safari 不能访问.
    如果要调换， 那么去 Web.xml 里面去修改.
    </p>


    <p>
     http://localhost/... 与  http://127.0.0.1/...  开头的地址可以访问
     其他 指定 ip 开头的地址拒绝访问
    </p>



    <h3> 测试 action type="Rewrite" </h3>

    <table>
        <tr>
            <th> 浏览器中输入 </th>
            <th> 将重定向为 </th>

            <th> Asp.Net 中 this.Context.Request.RawUrl 的结果 </th>
        </tr>


        <tr>
            <td> <a href="/test/1.html">/test/1.html</a> </td>
            <td> <a href="/Test.aspx?id=1">/Test.aspx?id=1</a> </td>

            <td> /test/1.html </td>
        </tr>


        <tr>
            <td> <a href="/TestPath/about:blank">/TestPath/about:blank</a> </td>
            <td> <a href="/TestPath/">/TestPath/</a> </td>

            <td> /TestPath/about:blank </td>
        </tr>
    </table>


    <p class="Desc">
    Rewrite 能够正确的返回相关页面， 但是 没有改变 this.Context.Request.RawUrl 。
    也就是 如果在 MVC 里面， 有相关安全检测的， 可能还是会导致 后台抛异常。
    </p>






    <h3> 测试 action type="Redirect"  </h3>

    <table>

        <tr>
            <th> 浏览器中输入 </th>
            <th> 将重定向为 </th>

            <th> Asp.Net 中 this.Context.Request.RawUrl 的结果 </th>
        </tr>



        <tr>
            <td> <a href="/OldPage.html">/OldPage.html</a> </td>
            <td> <a href="/Test.aspx?id=256">/Test.aspx?id=256</a> </td>

            <td> /Test.aspx?id=256 </td>
        </tr>

        <tr>
            <td> <a href="/OldPage.asp">/OldPage.asp</a> </td>
            <td> <a href="/Test.aspx?id=1024">/Test.aspx?id=1024</a> </td>
            <td> /Test.aspx?id=1024 </td>
        </tr>


        <tr>
            <td> <a href="/Exp/TYYGW2014120001/'http:/localhost:8001/Images/smile.png'">/Exp/TYYGW2014120001/'http:/localhost:8001/Images/smile.png'</a> </td>
            <td> http:/localhost:8001/Images/smile.png </td>
            <td>  </td>
        </tr>

    </table>


    <p class="Desc">
    Redirect 能够正确的返回相关页面， 并且彻底修改了用户浏览器上面访问的地址 。
    </p>




    <h3> 测试 action type="AbortRequest"  </h3>

    <table>

        <tr>
            <th> 浏览器中输入 </th>
            <th> 将重定向为 </th>

            <th> Asp.Net 中 this.Context.Request.RawUrl 的结果 </th>
        </tr>


        <tr>
            <td> <a target="_blank" href="/c/show.m?gid=6326585&nid=1006326585&st=527&ps=5000&esid=DOtq2_figDaIw0L5pgn6Og&gst=527&cu=http%3A%2F%2Fwww.173wx.com%2Fxiaoshuo%2F26%2F26523%2F12069528.html&fr=3.3.3.3">/c/show.m?gid=xxxxxx</a>  </td>
            <td> 拒绝访问  </td>
        </tr>

        <tr>
            <td> <a target="_blank" href="/_vti_bin/owssvr.dll?UL=1&ACT=4&BUILD=6551&STRMVER=4&CAPREQ=0">/_vti_bin/owssvr.dll?UL=1&ACT=4&BUILD=6551&STRMVER=4&CAPREQ=0</a>  </td>
            <td> 拒绝访问   </td>
        </tr>

        <tr>
            <td> <a target="_blank" href="/MSOffice/cltreq.asp"> /MSOffice/cltreq.asp </a>  </td>
            <td> 拒绝访问   </td>
        </tr>

        <tr>
            <td> <a target="_blank" href="/manager/html"> /manager/html </a>  </td>
            <td> 拒绝访问   </td>
        </tr>

        <tr>
            <td> <a target="_blank" href="manager.aspx"> manager.aspx </a>  </td>
            <td> 拒绝访问   </td>
        </tr>

    </table>


    <p class="Desc">
    AbortRequest 的，  IIS 直接 拒绝掉了， 不会触发 ASP.NET 的 Application_BeginRequest 事件了.
    </p>



    </div>
    </form>
</body>
</html>
