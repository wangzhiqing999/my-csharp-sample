using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization.Formatters.Binary;

using A0101_Serializable.Model;
using A0101_Serializable.Service;


namespace A0101_Serializable.ServiceImpl
{

    public class BinaryDataObjectSerialization : AbstractDataObjectSerialization
    {


        public BinaryDataObjectSerialization()
        {
            base.fmt = new BinaryFormatter();
        }


 
    }

}
