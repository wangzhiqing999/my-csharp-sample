<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="W0300_WCF_Ajax.Login.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> 登录 </title>

    <script src="../Scripts/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.cookie.js" type="text/javascript"></script>




<script type="text/javascript">

    $(document).ready(function () {

        // 默认情况下，验证码不显示.
        $("#CheckCodeLine").hide();

        // 刷新验证嘛.
        $("#btnGetCheckCode").click(function () {
            GetNewCheckCode();
        });

        // 记住密码.
        $("#chkRemember").change(function () {
            if ($(this).attr("checked") == "checked") {
                $("#chkAutoLogin").removeAttr("disabled");
            } else {
                $("#chkAutoLogin").removeAttr("checked");
                $("#chkAutoLogin").attr("disabled", "disabled");
            }
        });

        // 我已阅读
        $("#chkHadRead").change(function () {
            if ($(this).attr("checked") == "checked") {
                $("#btnLogin").removeAttr("disabled");
            } else {
                $("#btnLogin").attr("disabled", "disabled");
            }
        });
        
        $("#btnLogin").click(function () {
            DoLogin();
        });

        ReadUserInfo();
    })


    // 取得新的验证码.
    function GetNewCheckCode() {
        var img = $("#imgCheckCode");
        img.attr("src", '<%=Page.ResolveUrl("~")%>Login/MyCheckCode.aspx?id=' + Math.random());
    }


    // 保存 Cookie 信息.
    function SaveUserInfo() {
        if ($("#chkRemember").attr("checked") == "checked") {
            var userName = $("#txtUserName").val();
            var passWord = $("#txtPassword").val();

            $.cookie("RM", "true", { expires: 7 });
            $.cookie("UN", userName, { expires: 7 });
            $.cookie("PW", passWord, { expires: 7 });
            if ($("#chkAutoLogin").attr("checked") == "checked") {
                $.cookie("AL", "true", { expires: 7 });
            }
        } else {
            $.cookie("RM", "false", { expires: -1 });
            $.cookie("UN", "", { expires: -1 });
            $.cookie("PW", "", { expires: -1 });
            $.cookie("AL", "false", { expires: -1 });
        }
    }

    // 读取 Cookie 信息.
    function ReadUserInfo() {
        var vRM = $.cookie("RM");
        if (vRM == "true") {
            $("#chkRemember").attr("checked", "checked");
            $("#chkAutoLogin").removeAttr("disabled");
            $("#txtUserName").val($.cookie("UN"));
            $("#txtPassword").val($.cookie("PW"));
            if ($.cookie("AL") == "true") {
                $("#chkAutoLogin").attr("checked", "checked");

                // 1.5秒钟以后， 再去自动登录
                setTimeout("DoLogin()", 1500);
            }
        }
    }



    // 登录处理.
    function DoLogin() {
        // 用户名.
        var vLoginName = $("#txtUserName").val();
        if (vLoginName == '') {
            alert("用户名必须要输入！");
            return false;
        }
        // 密码.
        var vPassword = $("#txtPassword").val();
        if (vPassword == '') {
            alert("密码必须要输入！");
            return false;
        }
        // 验证码.
        var vCheckCode = $("#txtCheckCode").val();
        // 调用 ajax
        $.ajax({
            url: '<%=Page.ResolveUrl("~")%>Login/CustomerLoginHandler.ashx',
            type: "get",
            async: false,
            dataType: 'jsonp',
            data: 'u=' + vLoginName + '&p=' + vPassword + '&c=' + vCheckCode,
            jsonpCallback: "ShowLoginResult",
            success: function (data) {
            },
            error: function (msg) {
                alert(msg.responseText);
            }
        });
        return false;
    }

    // 显示登录结果.
    function ShowLoginResult(pResult) {
        if (!pResult.Result) {
            // 登录失败.
            alert(pResult.ResultMessage);

            // 刷新验证码.
            GetNewCheckCode();

            $("#CheckCodeLine").show();
            return;
        }
        // 保存信息.
        SaveUserInfo();
        // 登录成功.
        DoLoginSuccess();
    }




    // 登录成功.
    function DoLoginSuccess() {
        // 简单返回上一个页面.
        window.location.href = "<%=HttpContext.Current.Request.UrlReferrer %>";
    }

</script>

</head>



<body>
    <form id="form1" runat="server">
    <div>
    


      <table>
        <tr>
          <td> 账号 <input id="txtUserName" type="text" maxlength="32" value="" />  </td>
        </tr>

        <tr>
          <td> 密码 <input id="txtPassword" type="password" maxlength="32"  value="" />   <a href="#"> 忘记密码 </a>  </td>
        </tr>

        <tr id="CheckCodeLine">
          <td> 验证码  <input id="txtCheckCode" type="text" maxlength="8" value="" />
                <img id="imgCheckCode" alt="验证码" src="" />
                <a href="#" id="btnGetCheckCode"> 看不清楚 </a> 
          </td>
        </tr>


        <tr>
          <td>
            <input id="chkRemember" type="checkbox" />记住密码
            &nbsp;
            <input id="chkAutoLogin" type="checkbox" disabled="disabled" />自动登录
          </td>
        </tr>

        <tr>
          <td>
            <input id="chkHadRead" type="checkbox" /> 我已阅读 <a href="#" target="_blank">《网站服务用户协议》</a>
          </td>
        </tr>

        <tr>
          <td style="text-align: center">
              <input id="btnLogin" type="button" disabled="disabled" value="登 录" />
          </td>
        </tr>

      </table>



    </div>
    </form>
</body>
</html>
