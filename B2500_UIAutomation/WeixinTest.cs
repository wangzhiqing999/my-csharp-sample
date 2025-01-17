using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace B2500_UIAutomation
{
    internal class WeixinTest
    {



        /// <summary>
        /// 测试获取会话列表
        /// </summary>
        public static void TestListFriends()
        {

            // 获取桌面的自动化元素
            AutomationElement root = AutomationElement.RootElement;

            // 查找微信窗口
            Condition condition = new PropertyCondition(AutomationElement.NameProperty, "微信");
            AutomationElement wechatWindow = root.FindFirst(TreeScope.Children, condition);

            if (wechatWindow == null)
            {
                Console.WriteLine("找不到微信窗口");
                return;
            }

            // 查找会话列表
            AutomationElement chatList = wechatWindow.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, "会话"));
            if (chatList == null)
            {
                Console.WriteLine("找不到会话列表");
                return;
            }

            foreach (AutomationElement child in chatList.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ListItem)))
            {
                Console.WriteLine(child.Current.Name);
            }

        }





        public static void Test(string userName = "wang")
        {

            // 获取桌面的自动化元素
            AutomationElement root = AutomationElement.RootElement;

            // 查找微信窗口
            Condition condition = new PropertyCondition(AutomationElement.NameProperty, "微信");
            AutomationElement wechatWindow = root.FindFirst(TreeScope.Children, condition);

            if (wechatWindow == null)
            {
                Console.WriteLine("找不到微信窗口");
                return;
            }


            // 查找会话列表
            AutomationElement chatList = wechatWindow.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, "会话"));
            if (chatList == null)
            {
                Console.WriteLine("找不到会话列表");
                return;
            }


            AutomationElement userListItem = chatList.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, userName));
            if (userListItem == null)
            {
                Console.WriteLine("找不到用户的列表项目");
                return;
            }


            // 尝试获取 “用户” 列表项目下的 窗格.
            AutomationElement userPane = userListItem.FindFirst(
                TreeScope.Children,
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Pane));

            if (userPane == null)
            {
                Console.WriteLine("找不到用户窗格");
                return;
            }


            object invokePattern;
            if (userPane.TryGetCurrentPattern(InvokePattern.Pattern, out invokePattern))
            {
                // 执行点击操作
                ((InvokePattern)invokePattern).Invoke();
                Console.WriteLine("用户的窗格已被点击  " + DateTime.Now);
            }
            else
            {
                Console.WriteLine("用户的窗格不支持 Invoke 模式，无法执行点击操作。");
            }

            if (userPane.TryGetCurrentPattern(SelectionItemPattern.Pattern, out invokePattern))
            {
                // 执行点击操作
                ((SelectionItemPattern)invokePattern).Select();
                Console.WriteLine("选择用户的窗格");
            }




            // 尝试获取“用户” 列表项目下的 窗格 下面的 按钮.
            AutomationElement userBtn = userPane.FindFirst(
                TreeScope.Children,
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button));

            if (userBtn == null)
            {
                Console.WriteLine("找不到用户按钮");
                return;
            }

            object sendPattern;
            if (userBtn.TryGetCurrentPattern(InvokePattern.Pattern, out sendPattern))
            {
                ((InvokePattern)sendPattern).Invoke();
                Console.WriteLine("用户的窗格下的按钮已被点击  " + DateTime.Now);
            }




            // 尝试获取 “用户” 列表项目下的 窗格 下面的 窗格.
            AutomationElement userSubPane = userPane.FindFirst(
                TreeScope.Children,
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Pane));

            if (userSubPane == null)
            {
                Console.WriteLine("找不到用户窗格下面的窗格");
                return;
            }


            if (userSubPane.TryGetCurrentPattern(InvokePattern.Pattern, out invokePattern))
            {
                // 执行点击操作
                ((InvokePattern)invokePattern).Invoke();
                Console.WriteLine("用户的窗格下面的窗格已被点击  " + DateTime.Now);
            }
            else
            {
                Console.WriteLine("用户的窗格下面的窗格 不支持 Invoke 模式，无法执行点击操作。");
            }


            // 尝试获取 “用户” 列表项目下的 窗格 下面的 窗格 下面的 窗格.
            AutomationElement userSub2Pane = userSubPane.FindFirst(
                TreeScope.Children,
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Pane));

            if (userSub2Pane == null)
            {
                Console.WriteLine("找不到用户窗格下面的窗格下面的窗格");
                return;
            }


            if (userSub2Pane.TryGetCurrentPattern(InvokePattern.Pattern, out invokePattern))
            {
                // 执行点击操作
                ((InvokePattern)invokePattern).Invoke();
                Console.WriteLine("用户的窗格下面的窗格下面的窗格已被点击  " + DateTime.Now);
            }
            else
            {
                Console.WriteLine("用户的窗格下面的窗格下面的窗格 不支持 Invoke 模式，无法执行点击操作。");
            }











            // 尝试获取用户名的 文本.
            AutomationElement userText =
                userListItem.FindFirst(
                    TreeScope.Descendants,
                    new PropertyCondition(AutomationElement.NameProperty, userName));
            if (userText == null)
            {
                Console.WriteLine("找不到用户文本");
                return;
            }


            if (userText.TryGetCurrentPattern(InvokePattern.Pattern, out sendPattern))
            {
                ((InvokePattern)sendPattern).Invoke();
                Console.WriteLine("用户的文本已被点击  " + DateTime.Now);
            }






            //// 获取按钮元素的InvokePattern
            //InvokePattern invokePattern = userBtn.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;

            //if (invokePattern != null)
            //{
            //    // 模拟按钮点击操作
            //    invokePattern.Invoke();
            //    Console.WriteLine("按钮已被点击  " + DateTime.Now);
            //}


        }






        /// <summary>
        /// 测试独立窗口.
        /// <br/>
        /// 结果是能定位到控件，但是修改内容无效，点击发送按钮也无效.
        /// </summary>
        public static void TestIndependentWindow(string userName = "wang")
        {

            // 获取桌面的自动化元素
            AutomationElement root = AutomationElement.RootElement;

            // 查找微信窗口
            Condition condition = new PropertyCondition(AutomationElement.NameProperty, userName);
            AutomationElement wechatWindow = root.FindFirst(TreeScope.Children, condition);

            if (wechatWindow == null)
            {
                Console.WriteLine($"找不到 {userName} 窗口");
                return;
            }



            // 查找输入控件.
            AutomationElement inputBox =
                wechatWindow.FindFirst(
                    TreeScope.Descendants,
                    new PropertyCondition(AutomationElement.NameProperty, "输入"));
            if (inputBox == null)
            {
                Console.WriteLine("找不到输入控件！");
                return;
            }


            // 查找发送按钮.
            AutomationElement sendBtn =
                wechatWindow.FindFirst(
                    TreeScope.Descendants,
                    new PropertyCondition(AutomationElement.NameProperty, "发送(S)"));
            if (sendBtn == null)
            {
                Console.WriteLine("找不到发送按钮！");
                return;
            }




            ValuePattern valuePattern = (ValuePattern)inputBox.GetCurrentPattern(ValuePattern.Pattern);
            if (valuePattern != null)
            {
                // 设置文本
                valuePattern.SetValue("这是修改后的文本");
            }

            InvokePattern invokePattern = sendBtn.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            if (invokePattern != null)
            {
                // 模拟按钮点击操作
                invokePattern.Invoke();
                Console.WriteLine("按钮已被点击  " + DateTime.Now);
            }


        }


    }
}
