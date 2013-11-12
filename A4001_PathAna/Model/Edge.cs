using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A4001_PathAna.Model
{

    /// <summary>
    /// 路径信息.
    /// </summary>
    public class Edge
    {
        /// <summary>
        /// 起始节点ID.
        /// </summary>
        public string StartNodeID { set; get; }

        /// <summary>
        /// 目标节点ID.
        /// </summary>
        public string EndNodeID { set; get; }


        /// <summary>
        /// 权值，代价    
        /// </summary>
        public double Weight { set; get; }
    }

}
