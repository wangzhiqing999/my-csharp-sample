<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestUploadBigFile.aspx.cs" Inherits="W0300_WCF_Ajax.Upload.TestUploadBigFile" %>

<html lang="zh-CN">

<head runat="server">
    <meta charset="utf-8">
    <title>测试上传大文件</title>


    <link href="/Content/bootstrap.css" rel="stylesheet" type="text/css" />


    <script src="/Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    
    

    <script src="/bootstrap-progressbar/bootstrap-progressbar.js" type="text/javascript"></script>


    <script type="text/javascript">


    // 上传的文件.
    var vUploadFile;
    
    // 分片大小 （2MB一个）.
    var vShardSize = 2 * 1024 * 1024;

    // 文件大小.
    var vFileSize = 0;

    // 总片数
    var vShardCount;

    // 成功数.
    var vSucceed = 0;



    // 上传文件.
    function UploadFile() {

        $("#upload").attr("disabled", "disabled");

        // 文件对象
        vUploadFile = $("#file")[0].files[0];

        // 成功数.
        vSucceed = 0;

        // 文件大小.
        vFileSize = vUploadFile.size;

        //总片数
        vShardCount = Math.ceil(vFileSize / vShardSize);  


        $('.progress .progress-bar').attr('data-transitiongoal', 0).progressbar({ display_text: 'fill' });

        // 上传第一部分.
        UploadFilePart(0);
        
    }


    // 分片上传文件数据.
    function UploadFilePart(fileIndex) {

        // 文件名
        var name = vUploadFile.name;


        // 计算每一片的起始与结束位置
        var start = fileIndex * vShardSize;
        var end = Math.min(vFileSize, start + vShardSize);

        // 构造一个表单，FormData是HTML5新增的
        var form = new FormData();            
        // slice方法用于切出文件的一部分.
        form.append("data", vUploadFile.slice(start, end));
        form.append("name", name);
        // 总片数.
        form.append("total", vShardCount);
        // 当前是第几片.
        form.append("index", fileIndex + 1);


        // Ajax提交
        $.ajax({
            url: "/Upload/BigFileUploadHandler.ashx",
            type: "POST",
            data: form,
            async: true,         // 异步，否则画面卡死.
            processData: false,  // 很重要，告诉jquery不要对form进行处理
            contentType: false,  // 很重要，指定为false才能形成正确的Content-Type
            success: function (uploadResult) {


                if (uploadResult != null && uploadResult != undefined && uploadResult.Result == 1) {
                    // 当前片上传成功.
                    vSucceed = vSucceed + 1;

                    $("#output").html("上传进度：" + vSucceed + " / " + vShardCount);

                    var percent = ((vSucceed / vShardCount).toFixed(2)) * 100;

                    updateProgress(percent);

                    if (vSucceed >= vShardCount) {
                        $("#upload").removeAttr("disabled");
                    } else {
                        // 继续上传下一个.
                        UploadFilePart(uploadResult.Index);
                    }
                } else if (uploadResult != null && uploadResult != undefined) {
                    // 当前片上传失败. 尝试重现上传.
                    UploadFilePart(uploadResult.Index - 1);
                }
            }
        });
    }

    function progress(percent, $element) {
        var progressBarWidth = percent * $element.width() / 100;
        $element.find('div').animate({ width: progressBarWidth }, 500).html(percent + "% ");
    }


    function updateProgress(percentage) {
        $('.progress .progress-bar').attr('data-transitiongoal', percentage).progressbar({ display_text: 'fill' });
    }
    </script>


</head>


<body>
    <form id="form1" runat="server">
    <div>
    

    <input type="file" id="file" />

    <button id="upload" onclick="UploadFile();">上传</button>

    <span id="output" style="font-size: 12px">等待</span>
    <div class="progress">
        <div id="progressBar" class="progress-bar" role="progressbar" data-transitiongoal=""></div>
    </div>


    </div>
    </form>
</body>
</html>
