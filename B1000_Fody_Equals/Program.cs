using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace B1000_Fody_Equals
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("测试 Equals.Fody。    自动生成 Equals 方法.");


            Point p111 = new Point()
            {
                X = 1,
                Y = 1,
                Z = 1
            };

            Point p112 = new Point()
            {
                X = 1,
                Y = 1,
                Z = 2
            };

            Point p121 = new Point()
            {
                X = 1,
                Y = 2,
                Z = 1
            };


            Console.WriteLine("111 Equals 112 = {0}", p111.Equals(p112));
            Console.WriteLine("111 Equals 121 = {0}", p111.Equals(p121));
            Console.WriteLine("112 Equals 121 = {0}", p112.Equals(p121));


            Console.ReadKey();

        }
    }








    /// <summary>
    /// 用于测试 自动生成 Equals 方法的类.
    /// </summary>
    [Equals]
    public class Point
    {
        public int X { get; set; }

        public int Y { get; set; }



        /// <summary>
        /// IgnoreDuringEquals  意味着 比较的时候， 忽略该属性.
        /// </summary>
        [IgnoreDuringEquals]
        public int Z { get; set; }

    }


}
