<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Editor.aspx.cs" Inherits="MyUeditorTest.Editor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8"/>

    <script src="/ueditor.config.js" type="text/javascript"></script>

    <script src="/ueditor.all.min.js" type="text/javascript"></script>

    <script src="/lang/zh-cn/zh-cn.js" type="text/javascript"></script>


    <script src="/third-party/jquery-1.10.2.min.js" type="text/javascript"></script>

    <style type="text/css">
        div{
            width:100%;
        }
    </style>
</head>



<body>
    
    
    <form id="form1" runat="server">
    <div>
    

    <script id="editor" type="text/plain" style="width:1024px;height:400px;"></script>



    <hr />


    <asp:HiddenField ID="hfResultData" runat="server" />


    <asp:Button ID="btnUpdate" runat="server" Text="修改并更新" OnClientClick="getContent()" onclick="btnUpdate_Click" />

    <asp:Button ID="Button1" runat="server" Text="加载数据" OnClientClick="insertHtml(); return false;"   />



    </div>
    
    </form>



<script type="text/javascript">


    //实例化编辑器
    //建议使用工厂方法getEditor创建和引用编辑器实例，如果在某个闭包下引用该编辑器，直接调用UE.getEditor('editor')就能拿到相关的实例
    var ue = UE.getEditor('editor');


    $(document).ready(function () {
        // insertHtml();
    });



    function getContent() {
        var vResltData = UE.getEditor('editor').getContent();
        $("#hfResultData").val(vResltData);
    }


    function insertHtml() {

        UE.getEditor('editor').setContent('', false);

        var vResultData = $("#hfResultData").val();
        UE.getEditor('editor').execCommand('insertHtml', vResultData);
    }


</script>


</body>
</html>
