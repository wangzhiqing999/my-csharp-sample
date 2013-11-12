using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0309_State.Sample
{
    /// <summary>
    /// 维护一个ConcreteState子类的实例，这个实例定义当前的状态
    /// </summary>
    class Context
    {
        private State state;

        /// <summary>
        /// 定义context的初始状态
        /// </summary>
        /// <param name="state"></param>
        public Context(State state)
        {
            this.state = state;
            Console.WriteLine("初始状态是：" + state.GetType().Name);
        }


        /// <summary>
        /// 可读写的状态属性，用于读取当前状态和设置新状态
        /// </summary>
        public State State
        {
            get { return state; }
            set
            {
                state = value;
                Console.WriteLine("当前的状态：" + state.GetType().Name);
            }
        }
        /// <summary>
        /// 对请求作出处理，并设置下一状态
        /// </summary>
        public void Request()
        {
            state.Handle(this);
        }
    }
}
