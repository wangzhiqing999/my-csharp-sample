<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginInfo.aspx.cs" Inherits="W0300_WCF_Ajax.Login.LoginInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> 登录状态 </title>
    <script src="../Scripts/jquery-1.8.2.js" type="text/javascript"></script>



<script type="text/javascript">
    $(document).ready(function () {
        $("#hlLogout").click(function () {
            DoLogout();
        });
    });

    function DoLogout() {
        $.ajax({
            url: '<%=Page.ResolveUrl("~")%>Login/CustomerLogoutHandler.ashx',
            type: "get",
            async: false,
            dataType: 'jsonp',
            jsonpCallback: "ShowLogoutResult",
            success: function (data) {
            },
            error: function (msg) {
                alert(msg.responseText);
            }
        });
        return false;
    }

    // 显示注销 结果.
    function ShowLogoutResult(pResult) {
        if (!pResult.Result) {
            // 登录失败.
            alert(pResult.ResultMessage);
            return;
        }
        // 注销成功.
        DoLogoutSuccess();
    }




    // 注销成功.
    function DoLogoutSuccess() {
        // 简单刷新当前页面
        window.location.reload();
    }

</script>



</head>
<body>
    <form id="form1" runat="server">
    <div>
    


<asp:Panel ID="pnlWithLogin" runat="server">
欢迎您 <%= userName%>  
&nbsp;
<a id="hlLogout" href="#"> 注销 </a>
</asp:Panel>




<asp:Panel ID="pnlWithoutLogin" runat="server">

<a id="hlLoginIn" href="Login.aspx"> 登录 </a>

&nbsp;&nbsp;&nbsp;

<a id="hlRegister" href="Register.aspx"> 注册 </a>

</asp:Panel>




    </div>
    </form>
</body>
</html>
