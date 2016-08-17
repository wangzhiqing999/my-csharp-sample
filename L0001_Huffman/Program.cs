using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L0001_Huffman
{
    class Program
    {
        static void Main(string[] args)
        {


            
            string source = "1111111111111111111122222222222222222223333333333333333334444444444444444455555555555555566666666667";



            HuffmanCodeService builder = new HuffmanCodeService();

            // 计算权重.
            List<HuffmanCodeService.HuffmanNode> huffmanNode = builder.GetHuffmanCharWeight(source);
            //构造树.
            builder.BuildHuffmanTree(huffmanNode);

            // 计算各个字符的编码序列 
            Dictionary<char, BitArray> huffmanCode = builder.GetHuffmanCode(huffmanNode);




            // 编码.
            BitArray code = builder.Encode(huffmanCode, source);
            foreach (bool bit in code)
            {
                Console.Write(bit ? '1' : '0');
            }
            Console.WriteLine();


            // 解码.
            string result = builder.Decode(huffmanNode, code);
            Console.WriteLine(result);




            Console.ReadKey();


        }
    }
}
