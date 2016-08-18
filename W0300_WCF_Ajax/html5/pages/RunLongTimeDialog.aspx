<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RunLongTimeDialog.aspx.cs" Inherits="W0300_WCF_Ajax.html5.pages.RunLongTimeDialog" %>

<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>  模拟一个长时间的对话框处理 </title>

    <link href="../../Content/jquery.mobile-1.2.0.min.css" rel="stylesheet" type="text/css" />
        
    <script src="../../Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.mobile-1.2.0.min.js" type="text/javascript"></script>  

</head>


<body>





<!-- data-role = page  用于定义  一个页面.  -->
<div data-role="page">


    <!--  data-role = header  用于定义一个 顶部标题.  -->
    <div data-role="header">
	    <h1> 长时间的对话框处理  </h1>
    </div>  <!-- /header -->



    <!--  data-role = content  用于定义一个 中间内容区域.  -->
    <div data-role="content">
        <p>
          本画面用于测试  Ajax  的画面迁移处理

          
          对于 使用 Ajax 的画面迁移， 是源画面显示一个进度， 后台加载画面， 画面加载完毕后， 切换显示。

          不使用 Ajax 的画面迁移， 则是简单画面迁移并刷新。

          本画面没有任何逻辑， 仅仅是 Page_Load 的时候， 休眠 3秒钟.


          
        </p>

        
        <a href="#" data-role="button" data-theme="b" data-rel="back" data-inline="true">返回</a>

    </div> <!-- /content -->


    <!--  data-role = footer  用于定义一个 底部标题.  -->
    <div data-role="footer">
        <h3>
            Footer
        </h3>
    </div>  <!-- /footer -->


</div><!-- /page -->


</body>
</html>
