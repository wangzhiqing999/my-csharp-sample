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
    /// 麦道公司 飞机.
    /// </summary>
    public class MD : AirplaneMaker
    {
        public override string GetName()
        {
            return "麦道";
        }

        public override string GetEngine()
        {
            return "麦道的发动机";
        }

        public override string GetLandingGear()
        {
            return "麦道的起落架";
        }
    }
}
