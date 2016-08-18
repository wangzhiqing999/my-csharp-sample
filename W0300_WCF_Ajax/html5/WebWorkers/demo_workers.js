
// 用于测试 HTML 5 Web Workers

// 定义给外部的变量
var i = 0;



function timedCount() {

    // 模拟的业务逻辑
    // 简单数据递增.
    i = i + 1;

    //  postMessage() 方法 - 它用于向 HTML 页面传回一段消息。
    postMessage(i);

    // 在 500 毫秒以后， 再次执行 timedCount() 方法.
    setTimeout("timedCount()", 500);
}


// 本 Web Workers 首次执行的代码.
timedCount();
