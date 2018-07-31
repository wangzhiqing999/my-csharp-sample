
// 用于测试的命名空间.
namespace myTestNameSpace {

    // 通用服务结果的接口.
    export interface CommonServiceResult<T> {

        // 结果码.
        ResultCode: string;

        // 结果消息.
        ResultMessage: string;

        // 结果数据
        ResultData: T;

        // 是否执行成功
        IsSuccess: boolean;
    }

    // 获取默认的 成功的返回结果.
    export function GetDefaultSuccessResult<T>(data: T): CommonServiceResult<T> {
        let result: CommonServiceResult<T> = {
            ResultCode: "0",
            ResultMessage: "success",
            ResultData: data,
            IsSuccess: true
        };
        return result;
    }

    // 获取数据不存在的返回结果.
    export function GetDataNotFoundResult<T>(): CommonServiceResult<T> {
        let result: CommonServiceResult<T> = {
            ResultCode: "COMMON_DATA_NOT_FOUND",
            ResultMessage: "数据不存在！",
            ResultData: null,
            IsSuccess: false
        };
        return result;
    }

    // 获取系统异常的返回结果.
    export function GetSystemErrorResult<T>(error: Error): CommonServiceResult<T> {
        let result: CommonServiceResult<T> = {
            ResultCode: "SYSTEM_ERROR",
            ResultMessage: error.message,
            ResultData: null,
            IsSuccess: false
        };
        return result;
    }

}