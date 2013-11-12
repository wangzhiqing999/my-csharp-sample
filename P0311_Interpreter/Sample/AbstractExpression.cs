using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0311_Interpreter.Sample
{

    /// <summary>
    /// 声明一个抽象的解释操作，这个接口为抽象语树中所有节点共享
    /// </summary>
    abstract class AbstractExpression
    {
        public abstract void Interpret(Context context);
    }

}
