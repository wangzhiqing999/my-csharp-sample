using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A4001_PathAna.Model
{


    /// <summary>
    /// PlanCourse 缓存从源节点到其它任一节点的最小权值路径（路径表）
    /// </summary>
    public class PlanCourse
    {


        private Dictionary<string, PassedPath> htPassedPath;


        #region ctor


        public PlanCourse(List<Node> nodeList, string originID)
        {

            this.htPassedPath = new Dictionary<string, PassedPath>();

            Node originNode = null;

            foreach (Node node in nodeList)
            {
                if (node.ID == originID)
                {
                    originNode = node;
                }
                else
                {
                    PassedPath pPath = new PassedPath(node);

                    this.htPassedPath.Add(node.ID, pPath);
                }
            }

            if (originNode == null)
            {
                throw new Exception("The origin node is not exist !");
            }

            this.InitializeWeight(originNode);
        }


        /// <summary>
        /// 通过指定节点的边的权值初始化路径表
        /// </summary>
        /// <param name="originNode"></param>
        private void InitializeWeight(Node originNode)
        {
            if ((originNode.EdgeList == null) || (originNode.EdgeList.Count == 0))
            {
                return;
            }

            foreach (Edge edge in originNode.EdgeList)
            {
                PassedPath pPath = this[edge.EndNodeID];
                if (pPath == null)
                {
                    continue;
                }

                pPath.PassedNodeList.Add(originNode);
                pPath.Weight = edge.Weight;
            }
        }

        #endregion



        /// <summary>
        /// 获取指定点的路径表
        /// </summary>
        /// <param name="nodeID"></param>
        /// <returns></returns>
        public PassedPath this[string nodeID]
        {
            get
            {
                return this.htPassedPath[nodeID];
            }
        }

    }

}
