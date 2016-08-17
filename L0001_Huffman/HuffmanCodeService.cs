using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace L0001_Huffman
{


    /// <summary>
    /// 哈夫曼编码处理服务.
    /// </summary>
    class HuffmanCodeService
    {


        /// <summary>
        /// 哈夫曼节点.
        /// </summary>
        public class HuffmanNode
        {

            /// <summary>
            /// 字符.
            /// </summary>
            public char CharValue { set; get; }

            public string DisplayValue
            {
                get
                {
                    if (this.CharValue != 0)
                    {
                        return this.CharValue.ToString();
                    }

                    return this.LeftChild.DisplayValue + this.RightChild.DisplayValue;
                }
            }


            /// <summary>
            /// 权重.
            /// </summary>
            public int Weight { set; get; }

            /// <summary>
            /// 父节点.
            /// </summary>
            public HuffmanNode Parent { set; get; }

            /// <summary>
            /// 左子节点.
            /// </summary>
            public HuffmanNode LeftChild { set; get; }

            /// <summary>
            /// 右子节点.
            /// </summary>
            public HuffmanNode RightChild { set; get; }



            public override string ToString()
            {
                return String.Format("字符：{0} ; 出现次数：{1};  父节点：{2};  子节点：{3}, {4}",
                    this.DisplayValue,
                    this.Weight,
                    this.Parent == null ? "N/A" : this.Parent.DisplayValue,
                    this.LeftChild == null ? "N/A" : this.LeftChild.DisplayValue,
                    this.RightChild == null ? "N/A" : this.RightChild.DisplayValue);
            }
        }



        /// <summary>
        /// 取得 字符串的中， 各个字符的 权重.
        /// </summary>
        /// <param name="sourceStr"></param>
        /// <returns></returns>
        public List<HuffmanNode> GetHuffmanCharWeight(string sourceStr)
        {
            // 预期结果.
            List<HuffmanNode> resultList = new List<HuffmanNode>();

            // 分组统计.
            var groupQuery =
                from oneChar in sourceStr
                group oneChar by oneChar;

            foreach (var oneGroup in groupQuery)
            {
                // 单个结果.
                HuffmanNode oneResult = new HuffmanNode()
                {
                    CharValue = oneGroup.Key,
                    Weight = oneGroup.Count(),
                };

                // 加入结果列表.
                resultList.Add(oneResult);
            }


            // 排序.
            resultList = resultList.OrderBy(p => p.Weight).ToList();


            // 输出调试.
            Console.WriteLine("----------");
            foreach (HuffmanNode node in resultList)
            {
                Console.WriteLine(node);
            }
            Console.WriteLine("----------");

            // 返回.
            return resultList;
        }



        /// <summary>
        /// 构造哈夫曼树
        /// </summary>
        /// <param name="huffmanNode"></param>
        /// <returns></returns>
        public void BuildHuffmanTree(List<HuffmanNode> huffmanNode)
        {
            while (huffmanNode.Where(p => p.Parent == null).Count() > 1)
            {

                // 取得2个最小的.
                List<HuffmanNode> mini2 = huffmanNode.Where(p => p.Parent == null).OrderBy(p => p.Weight).Take(2).ToList();


                HuffmanNode pNode = new HuffmanNode()
                {
                    // 权重相加.
                    Weight = mini2.Sum(p => p.Weight),

                    // 子节点. (左多 右少 的逻辑) (后面将是 左0 右1 的逻辑)
                    LeftChild = mini2[1],
                    RightChild = mini2[0],
                };

                // 父节点.
                mini2[0].Parent = pNode;
                mini2[1].Parent = pNode;


                // 新节点加入列表.
                huffmanNode.Add(pNode);

                // 输出调试.
                Console.WriteLine("----------");
                foreach (HuffmanNode node in huffmanNode.Where(p => p.Parent == null).OrderBy(p => p.Weight))
                {
                    Console.WriteLine(node);
                }
                Console.WriteLine("----------");
            }


        }




        /// <summary>
        /// 获取哈夫曼字符编码对照表.
        /// </summary>
        /// <param name="huffmanNode"></param>
        /// <returns></returns>
        public Dictionary<char, BitArray> GetHuffmanCode(List<HuffmanNode> huffmanNode)
        {
            Dictionary<char, BitArray> huffmanCode = new Dictionary<char, BitArray>();


            foreach (HuffmanNode oneNode in huffmanNode.Where(p => p.CharValue != 0))
            {
                List<bool> values = new List<bool>();

                HuffmanNode currentNode = oneNode;

                while (currentNode.Parent != null)
                {
                    if (currentNode.Parent.LeftChild == currentNode)
                    {
                        values.Add(false);
                    }
                    else//1 
                    {
                        values.Add(true);
                    }

                    currentNode = currentNode.Parent;
                }

                values.Reverse();
                huffmanCode.Add(oneNode.CharValue, new BitArray(values.ToArray()));
            }


            foreach (char key in huffmanCode.Keys)
            {
                Console.Write("{0} : ", key);
                foreach (bool bit in huffmanCode[key])
                {
                    Console.Write(bit ? '1' : '0');
                }
                Console.WriteLine();
            }

            return huffmanCode;
        }





        /// <summary>
        /// 字符串编码为 Bit 数组.
        /// </summary>
        /// <param name="huffmanCode"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public BitArray Encode(Dictionary<char, BitArray> huffmanCode, string input)
        {
            if (string.IsNullOrEmpty(input))
                return null;

            List<bool> list = new List<bool>();

            // 依次从 哈夫曼编码 表中，找到对应的 Bit 数组信息.
            foreach (char ch in input)
            {
                BitArray ba = huffmanCode[ch];
                foreach (bool b in ba)
                {
                    list.Add(b);
                }
            }

            return new BitArray(list.ToArray());
        }


        /// <summary>
        /// Bit 数组 解码为 字符串.
        /// </summary>
        /// <param name="huffmanNode"></param>
        /// <param name="bitArray"></param>
        /// <returns></returns>
        public string Decode(List<HuffmanNode> huffmanNode, BitArray bitArray)
        {
            if (bitArray == null)
                return null;

            StringBuilder buff = new StringBuilder();

            // 根节点.
            int ic = huffmanNode.Count - 1;

            HuffmanNode current = huffmanNode[ic];


            int i = 0;

            // 按位扫描.
            while (i <= bitArray.Length - 1)
            {
                while (current.LeftChild != null && current.RightChild != null)
                {
                    current = bitArray[i++] ? current.RightChild : current.LeftChild;
                }

                // 检测到字符.
                buff.Append(current.CharValue);

                // 重置根节点.
                current = huffmanNode[ic];
            }

            return buff.ToString();
        }


    }
}
