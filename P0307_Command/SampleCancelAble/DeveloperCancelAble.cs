using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0307_Command.Sample;


namespace P0307_Command.SampleCancelAble
{
    /// <summary>
    /// 接收者（Receiver）角色：
    ///   负责具体实施和执行一个请求。任何一个类都可以成为接收者，实施和执行请求的方法叫做行动方法。 
    /// 
    /// 开发者
    /// </summary>
    public class DeveloperCancelAble
    {
        /// <summary>
        /// 开发者姓名.
        /// </summary>
        public string DeveloperName { set; get; }


        /// <summary>
        /// 开发项目
        /// </summary>
        /// <param name="project">项目</param>
        public void Coding(WebProject project)
        {
            Console.WriteLine("{0} 开发 [{1}] 项目",  DeveloperName,  project.ProjectName);
        }

        /// <summary>
        /// 运维项目
        /// </summary>
        /// <param name="project">项目</param>
        public void UpdateRoutine(WebProject project)
        {
            Console.WriteLine("{0} 维护 [{1}] 项目", DeveloperName, project.ProjectName);
        }




        /// <summary>
        /// 停止项目的工作
        /// </summary>
        /// <param name="project"></param>
        public void StopCoding(WebProject project)
        {
            Console.WriteLine("{0} 停止 [{1}] 项目", DeveloperName, project.ProjectName);
        }



    }

}
