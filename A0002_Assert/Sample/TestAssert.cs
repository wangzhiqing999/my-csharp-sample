using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Diagnostics;


namespace A0002_Assert.Sample
{
    
    /// <summary>
    /// 
    /// 
    /// 断言（或 Assert 语句）测试您作为 Assert 语句的参数指定的条件。
    /// 如果此条件计算为 true，不发生操作。如果此条件计算为 false，则断言失败。
    /// 如果正在调试版本中运行，则程序进入中断模式。
    /// 
    /// 
    /// 在 Visual Basic 和 Visual C# 中，可以从 Debug 或 Trace 中使用 Assert 方法，
    /// 这两种方法都在 System.Diagnostics 命名空间中。
    /// 由于 Debug 类方法未包含在程序的“发布”版本中，所以它们不会增加发布代码的大小或降低其速度。
    /// 
    /// 
    /// 
    /// 
    /// Assert 用于在开发阶段，屏蔽掉错误的参数信息。
    /// Assert(Boolean)  检查条件；如果条件为 false，则显示一个消息框，其中会显示调用堆栈。  
    /// Assert(Boolean, String)  检查条件；如果条件为 false，则输出指定消息，并显示一个消息框，其中会显示调用堆栈。  
    /// 
    /// 
    /// 一般的数据检查处理逻辑：
    /// 
    /// 
    /// UI [数据检查 ==> 检查失败 提示用户，不继续调用服务接口] 
    ///     --> 服务接口 [数据检查 ==> 检查失败 提示用户，不继续调用核心业务代码]  
    ///         --> 核心业务逻辑代码 [这里不写 数据检查的代码]
    /// 
    /// 
    /// Debug.Assert 用于在开发阶段， 核心业务逻辑代码部分。
    /// 代码部分不写检查逻辑 与 错误信息返回处理的。
    /// 这里相当于 限制了， 指定的核心代码， 仅仅处理某些特定情况下的分支数据。
    /// 对于非法的参数传入， 将忽略掉。
    /// 
    /// 
    /// 这样，在调试阶段
    /// 如果 画面UI 某些 检查代码没有写完善。 
    /// 或者 服务接口的  遗漏了某些条件的检查。
    /// 
    /// Debug.Assert 将提示出来，以通知开发者，当前的代码，存在有问题。
    /// 也就是 某些 “不应该发生的事情”， 发生了。
    /// 需要修改 前端的 数据检查代码，以确保 前端以后不会产生错误的数据返回.
    /// 
    /// </summary>
    public class TestAssert
    {


        /// <summary>
        /// 购买物品
        /// </summary>
        /// <param name="itemID"> 物品ID </param>
        /// <param name="count"> 数量 </param>
        public void BuyItem(int itemID, int count)
        {

            Debug.Assert(itemID > 0, "传入的参数可能无效，物品ID需要为大于零的数据！");

            Debug.Assert(count > 0, "传入的参数可能无效，物品数量需要为大于零的数据！");


            // 前面的基本参数检查以后，
            // 后面为 实际的执行业务逻辑的代码.


            Console.WriteLine("购买了{0}个{1}", count, itemID);

        }



    }


}
