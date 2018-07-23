/// <reference path="./typings/jquery/jquery.d.ts" /> 

// 简单测试 TypeScript 脚本， 在 ASP.NET MVC5 中， 能否正常调用.
// 本例子与 myHelloWorld.ts 的区别在于， 本例子， 还引用了jquery.
class GreeterUseJquery {
    element: JQuery;
    span: JQuery;
    timerToken: number;

    // 构造函数.
    constructor(element: JQuery) {
        this.element = element;
        this.element.html("The time is: <span id='dateSpan'></span> !!!");
        this.span = $('#dateSpan');
    }


    // 开始处理.
    start() {
        this.timerToken = setInterval(() => this.span.html(new Date().toUTCString()), 500);
    }

    // 结束处理.
    stop() {
        clearTimeout(this.timerToken);
    }

}

window.onload = () => {
    var el = $('#content');
    var greeter = new GreeterUseJquery(el);
    greeter.start();
};