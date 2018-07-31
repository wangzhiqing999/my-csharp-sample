/// <reference path="./typings/jquery/jquery.d.ts" /> 
/// <reference path="./myTestNameSpace.ts" />



// 测试工作接口.
interface ITestWorkingService {
    // 定义接口的方法.
    doWork(id: number): myTestNameSpace.CommonServiceResult<number>;
}

// 服务器实现接口.
class ServerTestWorkingService implements ITestWorkingService {

    doWork(id: number): myTestNameSpace.CommonServiceResult<number> {
        console.log("ServerTestWorkingService.doWork Start.", id);

        let result: myTestNameSpace.CommonServiceResult<number> = null;

        $.ajax({
            url: "/TestTypeScript/TestCommonService",
            type: 'POST',
            async: false,
            data: { id: id },
            cache: false,
            success: function (data) {
                console.log("/TestTypeScript/TestCommonService Result = ", data);
                result = data;
            }
        }).fail(function (xhr, textStatus, err) {
            result = myTestNameSpace.GetSystemErrorResult<number>(err);
        });

        return result;
    }
}


// 本地实现接口.
class LocalTestWorkingService implements ITestWorkingService {
    doWork(id: number): myTestNameSpace.CommonServiceResult<number> {
        console.log("LocalTestWorkingService.doWork Start.", id);
        if (id <= 0) {
            return myTestNameSpace.GetDataNotFoundResult<number>();
        }
        return myTestNameSpace.GetDefaultSuccessResult<number>(id);
    }
}







// 测试接口调用.
class MyTestInterface {


    // 用于显示处理结果的元素.
    element: JQuery;


    // 构造函数.
    constructor(element: JQuery) {
        this.element = element;
    }


    // 调用 Ajax.
    testAjaxFunc(id: number) {
        let self: MyTestInterface = this;
        $.ajax({
            url: "/TestTypeScript/TestCommonService",
            type: 'POST',
            data: { id: id },
            success: function (data) {
                // 这里做一下结果的 数据类型定义.
                let resultData: myTestNameSpace.CommonServiceResult<number> = data;
                // 显示处理结果.
                self.showResultData(resultData);
            }
        }).fail(function (xhr, textStatus, err) {
            console.log(err);
        }); 
    }


    // 本地处理逻辑.
    testLocalFunc(id: number) : myTestNameSpace.CommonServiceResult<number> {
        if (id <= 0) {
            return myTestNameSpace.GetDataNotFoundResult<number>();
        }
        return myTestNameSpace.GetDefaultSuccessResult<number>(id);
    }


    // 显示处理结果.
    showResultData(resultData: myTestNameSpace.CommonServiceResult<number>) {
        console.log("resultData = ", resultData);
        if (!resultData.IsSuccess) {
            this.element.html("处理发生异常！错误代码：" + resultData.ResultCode + "；错误描述：" + resultData.ResultMessage);
        } else {
            this.element.html("处理成功！返回数据：" + resultData.ResultData);
        }
    }

}






