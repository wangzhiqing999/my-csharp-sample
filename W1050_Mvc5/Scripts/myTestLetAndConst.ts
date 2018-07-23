


// 结果并不是期望的0， 1， 2， 3...，跑出来的结果全是10，这是因为var出来的i的作用域是整个函数。
for (var i = 0; i < 10; i++) {
    setTimeout(function () { console.info("use var!", i); }, 100);
}


// let的作用域是块级作用域，比如上面的循环，用let声明i的话, 得到的结果就是0, 1, 2....9。
for (let i = 0; i < 10; i++) {
    setTimeout(function () { console.info("use let!", i); }, 100);
}



// 常量的测试.
const str = 'string';

// 下面的注释去除掉，将编译不了.
// str = 'new string'; 

