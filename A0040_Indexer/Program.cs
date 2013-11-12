using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0040_Indexer.Sample;


namespace A0040_Indexer
{
    class Program
    {

        static void Main(string[] args)
        {
            Team team = new Team();

            Console.WriteLine("索引器测试！");

            for (int i = 0; i < team.Count; i++)
            {
                Console.WriteLine("team[{0}]={1}", i, team[i]);
            }

            Console.ReadLine();
        }
    }
}
