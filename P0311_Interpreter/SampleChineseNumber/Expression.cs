using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0311_Interpreter.SampleChineseNumber
{
    /// <summary>
    /// 抽象表达式角色
    /// </summary>
    public abstract class Expression
    {
        /// <summary>
        /// 汉字数字与阿拉伯数字数字的对应字典
        /// </summary>
        protected Dictionary<string, int> table = new Dictionary<string, int>(9);
        public Expression()
        {
            table.Add("壹", 1);
            table.Add("贰", 2);
            table.Add("参", 3);
            table.Add("肆", 4);
            table.Add("伍", 5);
            table.Add("陆", 6);
            table.Add("柒", 7);
            table.Add("捌", 8);
            table.Add("玖", 9);
        }


        /// <summary>
        /// 所有的具体表达式角色都需要实现的抽象方法
        /// 这个方法为虚方法,并非抽象方法,为了代码复用
        /// </summary>
        /// <param name="context">环境角色</param>
        public virtual void Interpret(ContextcnNum context)
        {
            //如果要处理的字符串长度为0则返回
            if (context.statement.Length == 0)
            {
                return;
            }
            foreach (string key in table.Keys)
            {
                int value = table[key];
                if (context.statement.EndsWith(key + GetPostifix()))
                {
                    context.data += value * Multiplier();
                    context.statement = context.statement.Substring(0, context.statement.Length - this.GetLength());
                    break;
                }

                if (context.statement.EndsWith("零"))
                {
                    context.statement = context.statement.Substring(0, context.statement.Length - 1);
                    break;
                }
                if (context.statement.Length == 0)
                {
                    return;
                }
            }
        }


        /// <summary>
        /// 取汉字数字单位
        /// 个位数为空
        /// 十位数为十
        /// 百位数为百
        /// 千位数为千
        /// </summary>
        /// <returns></returns>
        public abstract string GetPostifix();


        /// <summary>
        /// 例如:个位上数字为2,则最后为2*1
        /// 例如:百位上数字为3,则表示3*10
        /// </summary>
        /// <returns></returns>
        public abstract int Multiplier();


        /// <summary>
        /// 例如:个位的长度为一位
        /// 例如数字三十,表示两位
        /// 例如四百,表示两位
        /// </summary>
        /// <returns></returns>
        public virtual int GetLength()
        {
            return this.GetPostifix().Length + 1;
        }
    }

}
