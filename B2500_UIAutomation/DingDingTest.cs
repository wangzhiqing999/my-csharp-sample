using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;



namespace B2500_UIAutomation
{
    internal class DingDingTest
    {


        /// <summary>
        /// 测试获取会话列表
        /// </summary>
        public static void Test()
        {

            // 获取桌面的自动化元素
            AutomationElement root = AutomationElement.RootElement;

            // 查找微信窗口
            Condition condition = new PropertyCondition(AutomationElement.NameProperty, "钉钉");
            AutomationElement dingdingWindow = root.FindFirst(TreeScope.Children, condition);

            if (dingdingWindow == null)
            {
                Console.WriteLine("找不到钉钉窗口");
                return;
            }




        }

    }
}
