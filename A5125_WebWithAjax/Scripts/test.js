$(document).ready(function () {

    // 调用 ajax
    $.ajax({
        url: '/handler/TestHandler.ashx',
        type: "get",
        dataType: 'jsonp',
        jsonpCallback: "ShowTestResult",
        success: function (data) {
            // ShowTestResult(data);
        },
        error: function (msg) {
            alert(msg);
        }
    });

});



function ShowTestResult(pData) {

    var vHtml = "<tr><td>处理结果</td><td>" + pData.Result + "</td></tr>";

    vHtml = vHtml + "<tr><td>结果描述</td><td>" + pData.ResultMessage + "</td></tr>";

    vHtml = vHtml + "<tr><td>用户代码</td><td>" + pData.UserCode + "</td></tr>";
    vHtml = vHtml + "<tr><td>用户姓名</td><td>" + pData.UserName + "</td></tr>";

    vHtml = vHtml + "<tr><td colspan='2'>卡片列表</td></tr>";
    for (var i = 0; i < pData.CardList.length; i++) {
        vHtml = vHtml + "<tr><td colspan='2'>" + pData.CardList[i] + "</td></tr>";
    }

    $("#ResultTable").html(vHtml);


    //GetPictureData();
}




// 给外部调用的 js 脚本. 
// 无返回值， 无参数.
function PageScript1() {
    alert("页面脚本1");
}


// 给外部调用的 js 脚本. 
// 无返回值， 有参数.
function PageScript2(pParamValue) {
    $("#ResultTable").append("<tr><td colspan='2'> <b>页面脚本2 </b>：" + pParamValue + " </td></tr>");
}


// 给外部调用的 js 脚本. 
// 有返回值， 无参数.
function PageScript3() {
    alert("页面脚本3");
    return "[js返回：页面脚本3]";
}


// 给外部调用的 js 脚本. 
// 有返回值， 有参数.
function PageScript4(pParamValue) {
    $("#ResultTable").append("<tr><td colspan='2'> <b>页面脚本4 </b>：" + pParamValue + " </td></tr>");
    return "[js返回：页面脚本4 :" + pParamValue + "]";
}