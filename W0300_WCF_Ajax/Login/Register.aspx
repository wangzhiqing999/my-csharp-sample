<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="W0300_WCF_Ajax.Login.Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> 注册 </title>

    <script src="../Scripts/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.cookie.js" type="text/javascript"></script>



<script type="text/javascript">

    $(document).ready(function () {

        $("#<%=btnRegister.ClientID %>").attr("disabled", "disabled");


        $("#<%=chkHadRead.ClientID %>").change(function () {
            if ($(this).attr("checked") == "checked") {
                $("#<%=btnRegister.ClientID %>").removeAttr("disabled");
            } else {
                $("#<%=btnRegister.ClientID %>").attr("disabled", "disabled");
            }
        });



        $("#<%=btnRegister.ClientID %>").click(function () {
            var vUserName = $("#<%=txtUserName.ClientID %>").val();
            if (vUserName == '') {
                alert("用户名必须要输入！");
                return false;
            }

            // 密码.
            var vPassword = $("#<%=txtPassword.ClientID %>").val();
            if (vPassword == '') {
                alert("密码必须要输入！");
                return false;
            }

            // 再次输入密码.
            var vRePassword = $("#<%=txtRePassword.ClientID %>").val();
            if (vRePassword == '') {
                alert("再次输入密码必须要输入！");
                return false;
            }

            if (vPassword != vRePassword) {
                alert("密码与再次输入密码不一致！");
                return false;
            }
        });




        $("#<%=txtUserName.ClientID %>").change(function () {
            DoCheckUserName();
        });



    });







    function DoCheckUserName() {
        var vUserName = $("#<%=txtUserName.ClientID %>").val();
        if (vUserName == '') {
            $("#checkUserNameResult").html("用户名必须要输入！");
            return false;
        }

        // 调用 ajax
        $.ajax({
            url: '<%=Page.ResolveUrl("~")%>Login/CustomerUserNameCheckHandler.ashx',
            type: "get",
            async: false,
            cache: false,
            dataType: 'jsonp',
            data: 'u=' + vUserName,
            jsonpCallback: "ShowCheckUserNameResult",
            success: function (data) {
            },
            error: function (msg) {
                alert(msg.responseText);
            }
        });
        return false;
    }

    function ShowCheckUserNameResult(pResult) {
        if (!pResult.Result) {
            // 失败.
            $("#checkUserNameResult").html(pResult.ResultMessage);
            return;
        }
        // 成功.
        $("#checkUserNameResult").html("有效");
    }

</script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    


      <table>
        <tr>
          <td> 用户名 
            <asp:TextBox ID="txtUserName" runat="server" MaxLength="32"></asp:TextBox>
            <span id="checkUserNameResult"></span>
          </td>
        </tr>

        <tr>
          <td> 输入密码 
              <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="32"></asp:TextBox>
          </td>
        </tr>

        <tr>
          <td> 再次输入密码 
                <asp:TextBox ID="txtRePassword" runat="server" TextMode="Password" MaxLength="32"></asp:TextBox>
          </td>
        </tr>

        <tr>
          <td>
              <asp:CheckBox ID="chkHadRead" runat="server" Text="我已阅读" />
              <a href="#" target="_blank">《网站服务用户协议》</a>
          </td>
        </tr>

        <tr>
          <td style="text-align: center">
              <asp:Button ID="btnRegister" runat="server" Text="注 册" 
                  onclick="btnRegister_Click" />
          </td>
        </tr>

      </table>





    </div>
    </form>
</body>
</html>
