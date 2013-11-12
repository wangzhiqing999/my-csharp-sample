using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A4001_PathAna.Model;

namespace A4001_PathAna.Service
{


    /// <summary>
    /// RoutePlanner 提供图算法中常用的路径规划功能。
    /// 2005.09.06
    /// </summary>
    public class RoutePlanner
    {


        public RoutePlanner()
        {
        }




        #region Paln



        /// <summary>
        /// 获取权值最小的路径
        /// </summary>
        /// <param name="nodeList"></param>
        /// <param name="originID"></param>
        /// <param name="destID"></param>
        /// <returns></returns>
        public RoutePlanResult Paln(List<Node> nodeList, string originID, string destID)
        {
            //初始化起始节点到其他节点的路径表(权值，经过的节点，是否被处理）
            //同时初始化其他节点的路径表
            PlanCourse planCourse = new PlanCourse(nodeList, originID);

            Node curNode = this.GetMinWeightRudeNode(planCourse, nodeList, originID);


            #region 计算过程

            while (curNode != null)
            {
                PassedPath curPath = planCourse[curNode.ID];
                foreach (Edge edge in curNode.EdgeList)
                {
                    PassedPath targetPath = planCourse[edge.EndNodeID];
                    double tempWeight = curPath.Weight + edge.Weight;

                    if (tempWeight < targetPath.Weight)
                    {
                        targetPath.Weight = tempWeight;
                        targetPath.PassedNodeList.Clear();

                        for (int i = 0; i < curPath.PassedNodeList.Count; i++)
                        {
                            targetPath.PassedNodeList.Add(curPath.PassedNodeList[i]);
                        }

                        targetPath.PassedNodeList.Add(curNode);
                    }
                }

                //标志为已处理
                planCourse[curNode.ID].BeProcessed = true;
                //获取下一个未处理节点
                curNode = this.GetMinWeightRudeNode(planCourse, nodeList, originID);
            }

            #endregion

            //表示规划结束
            return this.GetResult(planCourse, destID);
        }

        #endregion






        #region private method



        #region GetResult


        /// <summary>
        /// 从PlanCourse表中取出目标节点的PassedPath，这个PassedPath即是规划结果
        /// </summary>
        /// <returns></returns>
        private RoutePlanResult GetResult(PlanCourse planCourse, string destID)
        {
            PassedPath pPath = planCourse[destID];

            if (pPath.Weight == int.MaxValue)
            {
                RoutePlanResult result1 = new RoutePlanResult(null, int.MaxValue);
                return result1;
            }


            Node[] passedNodeIDs = new Node[pPath.PassedNodeList.Count];

            for (int i = 0; i < passedNodeIDs.Length; i++)
            {
                passedNodeIDs[i] = pPath.PassedNodeList[i];
            }

            RoutePlanResult result = new RoutePlanResult(passedNodeIDs, pPath.Weight);

            return result;
        }

        #endregion




        #region GetMinWeightRudeNode

        /// <summary>
        /// 从PlanCourse取出一个当前累积权值最小，并且没有被处理过的节点
        /// </summary>
        /// <returns></returns>
        private Node GetMinWeightRudeNode(PlanCourse planCourse, List<Node> nodeList, string originID)
        {
            double weight = double.MaxValue;
            Node destNode = null;

            foreach (Node node in nodeList)
            {
                if (node.ID == originID)
                {
                    continue;
                }

                PassedPath pPath = planCourse[node.ID];
                if (pPath.BeProcessed)
                {
                    continue;
                }

                if (pPath.Weight < weight)
                {
                    weight = pPath.Weight;
                    destNode = node;
                }
            }

            return destNode;
        }

        #endregion



        #endregion
    }



}
