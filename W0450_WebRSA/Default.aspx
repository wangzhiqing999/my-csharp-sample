<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RSALoginTest._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> RSA 数据加密测试 </title>
    <script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="Scripts/jQuery.md5.js" type="text/javascript" ></script>
    <script src="Scripts/BigInt.js" type="text/javascript"></script>
    <script src="Scripts/RSA.js" type="text/javascript"></script>
    <script src="Scripts/Barrett.js" type="text/javascript"></script>



    <script type="text/javascript">

        function cmdEncrypt() {
            setMaxDigits(129);

            // 初始化加密的公钥.
            var key = new RSAKeyPair("<%=strPublicKeyExponent%>", "", "<%=strPublicKeyModulus%>");


            // 取得用户输入的信息.
            var vUserInputData = $("#txtPassword").val();

            // 加密处理.
            var pwdRtn = encryptedString(key, vUserInputData);

            // 设置加密后的数据，返回给后台.
            $("#encrypted_pwd").attr("value", pwdRtn);

            // 清空用户输入的数据，不传递到后台.
            $("#txtPassword").val('');

            // 提交.
            $("#formLogin").submit();
            return;
        }
    </script>

</head>



<body>


    <form action="Default.aspx" id="formLogin" method="post">
    <div>
        <div>
            传输过程中，不加密的数据:
        </div>
        <div>
            <input id="txtUserName" name="txtUserName" value="<%=postbackUserName%>" type="text" maxlength="64" />
        </div>


        <div>
            传输过程中，加密的数据: (中文汉字的不能支持！)
        </div>
        <div>
            <input id="txtPassword" type="text" maxlength="64" />
        </div>

        <div>
            用于加密的公钥 （正式系统中， 这个不显示在画面上）
        </div>
        <div>
            <%=strPublicKeyExponent%>
            <br />
            <%=strPublicKeyModulus%>
        </div>





        <div>
            <input id="btnLogin" type="button" value="提交" onclick="return cmdEncrypt()" />
        </div>
    </div>


    <div>
        <input type="hidden" name="encrypted_pwd" id="encrypted_pwd" />
    </div>


    </form>
    <div>
        <%=LoginResult%>
    </div>
</body>
</html>
