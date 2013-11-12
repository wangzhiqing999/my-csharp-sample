using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0207_Facade.Sample
{

    /// <summary>
    /// 顾客类.
    /// </summary>
    public  class Customer
    {

        /// <summary>
        /// 姓名.
        /// </summary>
        private string _name;


        public Customer(string name)
        {
            this._name = name;
        }

        /// <summary>
        /// 姓名属性.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }
    }
}
