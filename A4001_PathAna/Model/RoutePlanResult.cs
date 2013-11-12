using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A4001_PathAna.Model
{


    /// <summary>
    /// 最短路径的结果.
    /// </summary>
    public class RoutePlanResult
    {


        public RoutePlanResult(Node[] passedNodes, double value)
        {
            m_resultNodes = passedNodes;
            m_value = value;
        }


        private Node[] m_resultNodes;


        /// <summary>
        /// 最短路径经过的节点
        /// </summary>
        public Node[] ResultNodes
        {
            get { return m_resultNodes; }
        }


        private double m_value;

        /// <summary>
        /// 最短路径的值
        /// </summary>
        private double Value
        {
            get { return m_value; }
        }




        public override string ToString()
        {
            StringBuilder buff = new StringBuilder();


            buff.Append(m_resultNodes[0].ID);


            for (int i = 1; i < m_resultNodes.Length; i++)
            {
                Node step = m_resultNodes[i];

                buff.Append("--->");
                buff.Append(step.ID);
            }

            return buff.ToString();
        }


    }


}
