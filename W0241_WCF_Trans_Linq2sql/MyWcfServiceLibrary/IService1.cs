using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyWcfServiceLibrary
{

    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);




        /// <summary>
        /// 测试 事务处理.
        /// </summary>
        /// <param name="main_id"> 主表ID </param>
        /// <param name="main_val">  主表数值  </param>
        /// <param name="sub_id"> 子表ID </param>
        /// <param name="sub_value"> 子表数值 </param>
        /// <returns> 基本只能返回 true , 失败一般就抛异常了，不会返回 false 的。  </returns>
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [OperationContract]
        bool TestInsertData(int main_id, string main_val, int sub_id, string sub_value);



        /// <summary>
        /// 用于删除数据。
        /// </summary>
        /// <param name="main_id"></param>
        /// <returns></returns>
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [OperationContract]
        bool TestDeleteData(int main_id);






        #region 测试 WCF 调用 多个内部方法.


        /// <summary>
        /// 仅仅插入 主表.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [OperationContract]
        bool TestInsertMain(int id, string val);

        /// <summary>
        /// 仅仅插入 子表.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="main_id"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [OperationContract]        
        bool TestInsertSub(int id, int main_id, string val);


        /// <summary>
        /// 调用 TestInsertMain 与 TestInsertSub
        /// 
        /// 分别插入 主表与子表.
        /// </summary>
        /// <param name="main_id"></param>
        /// <param name="main_val"></param>
        /// <param name="sub_id"></param>
        /// <param name="sub_value"></param>
        /// <returns></returns>
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [OperationContract]        
        bool TestInsertAll(int main_id, string main_val, int sub_id, string sub_value);


        #endregion  



    }


}
