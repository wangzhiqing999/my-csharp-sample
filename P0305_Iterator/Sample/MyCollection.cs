using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0305_Iterator.Sample
{
    /// <summary> 
    /// 集合类型,实现了可迭代接口  
    /// summary> 
    public class MyCollection : IEnumerable<int>
    {
        internal int[] items;

        public MyCollection()
        {
            items = new int[5] { 1, 2, 3, 4, 5 };
        }





        #region IEnumerable<int> 成员
        
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < items.Length; i++)
            {

                // yield（C# 参考） 　　
                // 在迭代器块中用于向枚举数对象提供值或发出迭代结束信号。
                // 它的形式为下列之一： 　　
                // yield return <expression>; 　　
                // yield break; 

                yield return items[i];
            }
        }

        #endregion





        #region IEnumerable 成员

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < items.Length; i++)
            {
                // yield（C# 参考） 　　
                // 在迭代器块中用于向枚举数对象提供值或发出迭代结束信号。
                // 它的形式为下列之一： 　　
                // yield return <expression>; 　　
                // yield break; 

                yield return items[i];
            }
        }

        #endregion
    } 
}
