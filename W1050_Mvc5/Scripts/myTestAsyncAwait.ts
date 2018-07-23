// 注意：为了让 TypeScript 编译通过
// 需要在  【项目】--【属性】--【TypeScript生成】 的地方
// ECMAScript版本(E):  设置为 ECMAScript6


/// <reference path="./typings/jquery/jquery.d.ts" /> 


async function testRun() {

    for (let i = 1; i <= 3; i++) {

        console.info('start', i);

        await asyncFunction(i).then(function (value) {
            $("#test" + i).html(value.toString());
        }).catch(function (error) {
            console.log(error);
        });


        // 注意：这里的代码，是要等待上面的处理执行完毕后，才会执行.
        // 实际业务中，上面的操作，可能是远程获取数据。
        // 下面是 数据获取到之后， 额外设置一些样式，或者执行一些脚本的操作。
        // 而不必统统放到那个  then 里面去处理。

        console.info('finish', i);


    }
}


