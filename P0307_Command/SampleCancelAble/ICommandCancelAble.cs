using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0307_Command.SampleCancelAble
{

    /// <summary>
    /// 命令（Command）角色
    ///     声明了一个给所有具体命令类的抽象接口。这是一个抽象角色。
    /// </summary>
    public interface ICommandCancelAble
    {

        /// <summary>
        /// 执行 项目.
        /// </summary>
        void Excute();


        /// <summary>
        /// 取消 项目.
        /// </summary>
        void Cancel();


    }

}
