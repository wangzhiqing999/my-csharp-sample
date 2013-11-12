using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0033_MulDelegate.Sample;

namespace A0033_MulDelegate
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("多重委派的实现");

            // 实现委派的类，需要初始化.
            AccountHandler handle = new AccountHandler();
            AccountHandler2 handle2 = new AccountHandler2();
            
            // 初始化 需要委派实现的类
            AccountService service = new AccountService();


            // 创建委派.
            // 和创建一个普通的类对象差别不大
            // 要求是 构造函数中， 要指定 一个 方法
            // 这个方法的定义，需要与 委派的方法  参数、返回值 一致。
            AccountService.AddAccountCashDelegate add =
                new AccountService.AddAccountCashDelegate(handle.AddCash);
            // 同上
            AccountService.SubAccountCashDelegate sub =
                new AccountService.SubAccountCashDelegate(handle.SubCash);

            // 同上
            AccountService.AddAccountCashDelegate add2 =
                            new AccountService.AddAccountCashDelegate(handle2.AddCash);
            // 同上
            AccountService.SubAccountCashDelegate sub2 =
                new AccountService.SubAccountCashDelegate(handle2.SubCash);

            // 设置处理器.
            service.add = (AccountService.AddAccountCashDelegate)Delegate.Combine(add, add2);
            service.sub = (AccountService.SubAccountCashDelegate)Delegate.Combine(sub, sub2);



            // 使用委派 ： 执行操作.
            // 由于设置了2个委派， 应该有2种执行方式！
            service.DemoAdd(1000.20);

            service.DemoSub(0.20);


            Console.ReadLine();

        }
    }
}
