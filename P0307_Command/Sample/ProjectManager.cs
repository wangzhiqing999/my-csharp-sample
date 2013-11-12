using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0307_Command.Sample
{

    /// <summary>
    /// 请求者（Invoker）角色：
    ///    负责调用命令对象执行请求，相关的方法叫做行动方法。
    /// 
    /// 项目经理类
    /// </summary>
    public class ProjectManager
    {
        List<ICommand> cmdList = new List<ICommand>();

        /// <summary>
        /// 设置命令
        /// </summary>
        /// <param name="cmd"></param>
        public void SetCommand(ICommand cmd)
        {
            cmdList.Add(cmd);
        }

        /// <summary>
        /// 发起命令
        /// </summary>
        public void ExcuteCommand()
        {
            cmdList.ForEach(p => p.Excute());
        }




    }

}
