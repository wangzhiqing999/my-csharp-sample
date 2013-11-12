using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0031_delegate.Sample;

namespace A0031_delegate
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("委派的实现");

            // 实现委派的类，需要初始化.
            AccountHandler handle = new AccountHandler();
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



            // 使用委派 ： 将方法 作为 参数，执行操作.
            service.DemoAdd(add, 1000.20);

            service.DemoSub(sub, 0.20);


            Console.ReadLine();

        }
    }
}
