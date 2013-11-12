using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A4001_PathAna.Model
{

    /// <summary>
    /// PassedPath 用于缓存计算过程中的到达某个节点的权值最小的路径
    /// </summary>
    public class PassedPath
    {

        /// <summary>
        /// 当前节点ID.
        /// </summary>
        public Node CurNode { set; get; }

        /// <summary>
        /// 是否已被处理.
        /// </summary>
        public bool BeProcessed { set; get; }

        /// <summary>
        /// 累积的权值.
        /// </summary>
        public double Weight { set; get; }

        /// <summary>
        /// 路径.
        /// </summary>
        public List<Node> PassedNodeList { set; get; }



        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="ID"></param>
        public PassedPath(Node node)
        {
            this.CurNode = node;
            this.Weight = double.MaxValue;
            this.PassedNodeList = new List<Node>();
            this.BeProcessed = false;
        }



    }



}
