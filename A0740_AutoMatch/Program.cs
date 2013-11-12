using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0740_AutoMatch.Sample;
using A0740_AutoMatch.Test;

namespace A0740_AutoMatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("本项目是一个 Nunit 的单元测试，请通过 Nunit 来运行本程序！");


            //// 可兑换礼品列表.
            //List<IAutoMatchAble> baseDataList = new List<IAutoMatchAble>()
            //{
            //    new AutoMatchAbleTest("A", 300),
            //    new AutoMatchAbleTest("C", 500),
            //    new AutoMatchAbleTest("B", 400),
            //};


            //// 构造处理类.
            //IAutoMatchProcesser autoMatchProcesser = new MinRemainderAutoMatchProcesser()
            //{
            //    BaseDataList = baseDataList,
            //};


            //// 处理结果变量定义.
            //List<AutoMatchResult> actual = null;


            //actual = autoMatchProcesser.DoAutoMatchProcess(200);

            Console.ReadLine();
        }
    }
}
