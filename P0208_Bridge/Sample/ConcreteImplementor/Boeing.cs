using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0208_Bridge.Sample
{


    /// <summary>
    /// 桥梁模式（Bridge） 中的 具体实现化（Concrete Implementor）角色：
    /// 这个角色给出实现化角色接口的具体实现。
    /// 
    /// 波音公司 飞机.
    /// </summary>
    public class Boeing : AirplaneMaker
    {
        public override string GetName()
        {
            return "波音";
        }

        public override string GetEngine()
        {
            return "波音的发动机";
        }

        public override string GetLandingGear()
        {
            return "波音的起落架";
        }
    }
}
