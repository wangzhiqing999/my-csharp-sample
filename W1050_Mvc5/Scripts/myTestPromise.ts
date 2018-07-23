// 注意：为了让 TypeScript 编译通过
// 需要在  【项目】--【属性】--【TypeScript生成】 的地方
// ECMAScript版本(E):  设置为 ECMAScript6


/// <reference path="./typings/jquery/jquery.d.ts" /> 


// 模拟的异步处理.
function asyncFunction(id: number): Promise<string> {
    return new Promise(function (resolve, reject) {
        console.log("asyncFunction 处理开始", id);
        $.ajax({
            url: "/TestAsync/WithoutAsyncSub",
            type: 'GET',
            data: { id: id },
            cache: false,
            success: function (data) {
                resolve(data);
            }
        }).fail(function (xhr, textStatus, err) {
            reject(err);
        });  
    });
}


// 重置画面.
function resetUI() {
    $("#test1").html("");
    $("#test2").html("");
    $("#test3").html("");
}


// 测试 Promise.all
// Promise.all 意味着多个 Promise，全部执行完毕后，才执行 then 的操作.
function testAll() {

    // 先重置UI.
    resetUI();

    // Promise.all
    let allFunc = Promise.all([asyncFunction(1), asyncFunction(2), asyncFunction(3)]);
    allFunc.then(function (value) {
        for (let i = 0; i < value.length; i++) {
            let idx = i + 1;
            let data = value[i];
            $("#test" + idx).html(data.toString());
        }
    }).catch(function (error) {
        console.log(error);
    });
}


// 测试 Promise.race
// Promise.race 意味着多个 Promise， 任意一个执行完毕了， 就立即执行 then 的操作.
// 一个执行完毕就 then, 导致后续的操作，执行完毕的结果，将被忽略.
function testRace() {

    // 先重置UI.
    resetUI();

    // Promise.race
    let raceFunc = Promise.race([asyncFunction(1), asyncFunction(2), asyncFunction(3)]);
    raceFunc.then(function (value) {
        $("#test1").html(value.toString());
    }).catch(function (error) {
        console.log(error);
    });
}


// 测试依次处理.
// 基本上一起开始， 谁先完成，谁先处理。
function testEach() {

    // 先重置UI.
    resetUI();

    // 依次处理.
    for (let i = 1; i <= 3; i++) {
        let testFunc = asyncFunction(i);
        testFunc.then(function (value) {
            $("#test" + i).html(value.toString());
        }).catch(function (error) {
            console.log(error);
        });
    }
}


// 测试嵌套的处理.
// 第一个请求处理完毕了， 再处理第二个请求，第二个请求处理完了，再处理第三个。
// 一般应用于  第二个请求的参数， 依赖于第一个请求的结果的情况。
function testNesting () {

    // 先重置UI.
    resetUI();

    let testFunc1 = asyncFunction(1);
    

    // 第1次.
    testFunc1.then(function (value) {
        $("#test1").html(value.toString());
        // 第2次.
        let testFunc2 = asyncFunction(2);
        testFunc2.then(function (value) {
            $("#test2").html(value.toString());
            // 第3次.
            let testFunc3 = asyncFunction(3);
            testFunc3.then(function (value) {
                $("#test3").html(value.toString());
            }).catch(function (error) {
                console.log(error);
            });
        }).catch(function (error) {
            console.log(error);
        });
    }).catch(function (error) {
        console.log(error);
    });

}
