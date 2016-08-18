<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error404.aspx.cs" Inherits="W0300_WCF_Ajax.Error.Error404" %>

<%
    Response.StatusCode = 404;
    Response.Status = "404 Not Found";
    Response.TrySkipIisCustomErrors = false;
%>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> 404  </title>

	<style type="text/css">
		html
		{
			background: #f7f7f7;
		}
		body
		{
			background: #fff;
			color: #333;
			font-family: "MicrosoftYaHei" , "微软雅黑" ,Verdana,Arial;
			margin: 2em auto 0 auto;
			width: 700px;
			padding: 1em 2em;
			-moz-border-radius: 11px;
			-khtml-border-radius: 11px;
			-webkit-border-radius: 11px;
			border-radius: 11px;
			border: 1px solid #dfdfdf;
		}
		a
		{
			color: #2583ad;
			text-decoration: none;
		}
		a:hover
		{
			color: #d54e21;
		}
		h1
		{
			border-bottom: 1px solid #dadada;
			clear: both;
			color: #666;
			margin: 5px 0 5px 0;
			padding: 0;
			padding-bottom: 1px;
		}
		h2
		{
			text-align:center;
			font-size:30px;
			}
		p
		{
			text-align: center;
			font-size:18px;
		}
		div{margin-bottom:80px;}
		ul
		{
			width:400px;
			margin:0 auto;
			}
	</style>


	<script type="text/javascript">
	    function gid(id) { return document.getElementById ? document.getElementById(id) : null; }
	    function timeDesc() {
	        if (all <= 0) {
	            self.location = "http://localhost:56762/index.htm";
	        }
	        var obj = gid("tS");
	        if (obj) obj.innerHTML = all + " 秒后";
	        all--;
	    }
	    var all = 8;
	    if (all > 0) window.setInterval("timeDesc();", 1000);
	</script>

</head>


<body>
    <form id="form1" runat="server">
    <div>
      
	<h1 id="logo" style="text-align: center">
    错误
	</h1>

	<h2><img src="err404.jpg" /> 404 </h2>

	<p>抱歉，你输入的网址 <%= Request["aspxerrorpath"] %> 可能不正确，或者该网页不存在。</p>

	<div><ul><li><a href="http://localhost:56762/index.htm"><span id="tS">3 秒后</span>返回首页</a></li></ul></div>


    </div>
    </form>
</body>
</html>
