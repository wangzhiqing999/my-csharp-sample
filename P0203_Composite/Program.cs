using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0203_Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("演示 安全式的合成模式 ");
            TestSafe();


            Console.WriteLine();
            Console.WriteLine("演示 透明式的合成模式 ");
            TestTransparent();

            Console.ReadLine();
        }



        /// <summary>
        /// 安全式的 测试.
        /// </summary>
        private static void TestSafe()
        {
            

            // Create a tree structure
            Safe.Composite root = new Safe.Composite("我是根结点（树枝结点）");
            root.Add(new Safe.Leaf("我是叶子结点 A"));
            root.Add(new Safe.Leaf("我是叶子结点 B"));
            Safe.Composite comp = new Safe.Composite("我是树枝结点 X");

            comp.Add(new Safe.Leaf("我是叶子结点 XA"));
            comp.Add(new Safe.Leaf("我是叶子结点 XB"));
            root.Add(comp);

            root.Add(new Safe.Leaf("我是叶子结点 C"));

            // Add and remove a leaf
            Safe.Leaf l = new Safe.Leaf("我是叶子结点 D");
            root.Add(l);
            root.Remove(l);

            // Recursively display nodes
            root.Display(1);

        }


        /// <summary>
        /// 透明式的 测试.
        /// </summary>
        private static void TestTransparent()
        {
            // Create a tree structure
            Transparent.Composite root = new Transparent.Composite("我是根结点（树枝结点）");
            root.Add(new Transparent.Leaf("我是叶子结点 A"));
            root.Add(new Transparent.Leaf("我是叶子结点 B"));
            Transparent.Composite comp = new Transparent.Composite("我是树枝结点 X");

            comp.Add(new Transparent.Leaf("我是叶子结点 XA"));
            comp.Add(new Transparent.Leaf("我是叶子结点 XB"));
            root.Add(comp);

            root.Add(new Transparent.Leaf("我是叶子结点 C"));

            // Add and remove a leaf
            Transparent.Leaf l = new Transparent.Leaf("我是叶子结点 D");
            root.Add(l);
            root.Remove(l);

            // 叶子结点不能增加 / 删除的
            l.Add(root);
            l.Remove(root);


            // Recursively display nodes
            root.Display(1);
        }


    }
}
