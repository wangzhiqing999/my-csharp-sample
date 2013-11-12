using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0311_Interpreter.SampleLogic
{

    public class Context
    {

        private Dictionary<Variable, bool> map = new Dictionary<Variable, bool>();


        public void assign(Variable var, bool value)
        {
            map.Add(var, value);
        }


        public bool lookup(Variable var) 
        {
            if (!map.ContainsKey(var))
            {
                throw new ArgumentException();
            }
            
            return map[var];
        }

    }

}
