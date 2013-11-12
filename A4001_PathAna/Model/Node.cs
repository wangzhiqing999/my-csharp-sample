using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A4001_PathAna.Model
{


    /// <summary>
    /// 节点信息.
    /// </summary>
    public class Node
    {

        /// <summary>
        /// 节点ID.
        /// </summary>
        private string id;

        /// <summary>
        /// Edge的集合－－出边表
        /// </summary>
        private List<Edge> edgeList;


        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="nodeID"></param>
        public Node(string nodeID)
        {
            this.id = nodeID;
            this.edgeList = new List<Edge>();
        }







        #region property


        /// <summary>
        /// 节点ID.
        /// </summary>
        public string ID
        {
            get
            {
                return this.id;
            }
        }


        /// <summary>
        /// 节点向外的路径列表.
        /// </summary>
        public List<Edge> EdgeList
        {
            get
            {
                return this.edgeList;
            }
        }


        #endregion


    }


}
