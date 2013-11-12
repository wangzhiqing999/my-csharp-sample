using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


// 参考 http://code.google.com/p/moq/wiki/QuickStart
namespace B0040_MOQ.Sample
{

    /// <summary>
    /// 测试  MOQ 用的 接口.
    /// 
    /// </summary>
    public interface IHelloWorld
    {

        /// <summary>
        /// 无参数、 Bool 返回值。
        /// </summary>
        /// <returns></returns>
        bool IsHelloWorld();


        /// <summary>
        /// 有参数、 Bool 返回值。
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        bool IsIncludeHelloWorld(string param);



        /// <summary>
        /// 测试  out 参数的.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="hw"></param>
        /// <returns></returns>
        bool TryHelloWorld(string name,  out string hw);



        /// <summary>
        /// 测试  ref 参数的.
        /// </summary>
        /// <param name="hw"></param>
        /// <returns></returns>
        bool BuildHelloWorld(ref string hw);








        #region 用于测试 Matching Arguments 的 接口.


        /// <summary>
        /// 是否是 可用的ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool IsUsableID(int id);


        /// <summary>
        /// 是否是 偶数
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        bool IsEven(int val);


        /// <summary>
        /// 加入列表.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        bool Add(int val);


        /// <summary>
        /// 是否存在.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        bool Exists(string val);




        
        #endregion



    }

}
