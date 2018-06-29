
// 简单测试 TypeScript 脚本， 在 ASP.NET MVC5 中， 能否正常调用.
class Greeter {
    element: HTMLElement;
    span: HTMLElement;
    timerToken: number;

    // 构造函数.
    constructor(element: HTMLElement) {
        this.element = element;
        this.element.innerHTML += "The time is: ";
        this.span = document.createElement('span');
        this.element.appendChild(this.span);
        this.span.innerText = new Date().toUTCString();
    }


    // 开始处理.
    start() {
        this.timerToken = setInterval(() => this.span.innerHTML = new Date().toUTCString(), 500);
    }

    // 结束处理.
    stop() {
        clearTimeout(this.timerToken);
    }

}

window.onload = () => {
    var el = document.getElementById('content');
    var greeter = new Greeter(el);
    greeter.start();
};