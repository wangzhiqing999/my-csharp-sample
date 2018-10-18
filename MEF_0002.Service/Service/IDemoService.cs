using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEF_0002.Service
{

    /// <summary>
    /// 演示服务.
    /// 
    /// 这个项目，仅仅定义基本的接口，没有任何的实现。
    /// </summary>
    public interface IDemoService
    {

        /// <summary>
        /// 保存数据.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        void SaveData(string text);

    }
}
