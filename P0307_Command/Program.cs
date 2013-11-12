using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using P0307_Command.Sample;
using P0307_Command.SampleCancelAble;


namespace P0307_Command
{
    class Program
    {
        static void Main(string[] args)
        {

            // 表示一个具体的项目名字叫：项目A
            WebProject wpA = new WebProject() { ProjectName = "项目A" };
            // 表示一个具体的项目名字叫：项目B
            WebProject wpB = new WebProject() { ProjectName = "项目B" };
            // 开发者
            Developer developer = new Developer() { DeveloperName = "张三" };

            // 开发者所需要接收的命令
            ICommand codeCmd = new CodingCommand() { project = wpA, dp = developer };
            ICommand UpdateCmd = new UpdateRoutineCommand() { project = wpB, dp = developer };

            //项目经理
            ProjectManager pm = new ProjectManager();
            //设置命令
            pm.SetCommand(codeCmd);
            pm.SetCommand(UpdateCmd);
            //发起命令让开发者去完成
            pm.ExcuteCommand();


            
            Console.WriteLine("========== 可取消 ==========");


            // 开发者
            DeveloperCancelAble developer2 = new DeveloperCancelAble() { DeveloperName = "李四" };

            //开发者所需要接收的命令
            ICommandCancelAble codeCmd2 = new CodingCommandCancelAble() { project = wpA, dp = developer2 };
            ICommandCancelAble UpdateCmd2 = new UpdateRoutineCommandCancelAble() { project = wpB, dp = developer2 };

            //项目经理
            ProjectManagerCancelAble pm2 = new ProjectManagerCancelAble();
            //设置命令
            pm2.SetCommand(codeCmd2);
            pm2.SetCommand(UpdateCmd2);
            //发起命令让开发者去完成
            pm2.ExcuteCommand();
            //撤销UpdateCmd命令
            pm2.CancelExectueCommand(UpdateCmd2);



            Console.ReadLine();
        }
    }
}
