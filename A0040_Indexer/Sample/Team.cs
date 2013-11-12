using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0040_Indexer.Sample
{
    class Team
    {

        String[] memberArray;

        public Team()
        {
            memberArray = new String[4];
            memberArray[0] = "设计";
            memberArray[1] = "开发";
            memberArray[2] = "测试";
            memberArray[3] = "实施";
        }



        public int Count
        {
            get
            {
                return memberArray.Length;
            }
        }


        public String this[int index]
        {
            get
            {
                if (index >= 0 && index <= 3)
                {
                    return memberArray[index];
                }
                else
                {
                    return null;
                }
            }

            set
            {
                if (index >= 0 && index <= 3)
                {
                    memberArray[index] = value;
                }
            }
        }

    }
}
