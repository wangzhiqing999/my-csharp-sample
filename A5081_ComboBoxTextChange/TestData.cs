using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A5081_ComboBoxTextChange
{


    /// <summary>
    /// 用于 模拟， 从数据库中 读取出来的数据.
    /// </summary>
    public class TestData
    {

        /// <summary>
        /// 代码.
        /// </summary>
        public string Code { set; get; }

        /// <summary>
        /// 数据库中的 全称.
        /// </summary>
        public string Name { set; get; }


        /// <summary>
        /// 缩写
        /// </summary>
        public string DisplayName
        {
            get
            {
                int place = this.Name.IndexOf("*");
                if (place == -1)
                {
                    return this.Name;
                }

                return this.Name.Substring(0, place - 1);
            }
        }




        /// <summary>
        /// 获取用于演示的  测试数据.
        /// </summary>
        /// <returns></returns>
        public static List<TestData> GetDemoTestDataList()
        {
            List<TestData>  resultList = new List<TestData>();

            resultList.Add(new TestData() { Code = "001", Name = "鼠糖*100ml" });
            resultList.Add(new TestData() { Code = "002", Name = "牛糖*200ml" });
            resultList.Add(new TestData() { Code = "003", Name = "兔糖*300ml" });
            resultList.Add(new TestData() { Code = "004", Name = "虎糖*400ml" });            
            resultList.Add(new TestData() { Code = "005", Name = "龙糖*500ml" });
            resultList.Add(new TestData() { Code = "006", Name = "蛇糖*600ml" });

            resultList.Add(new TestData() { Code = "007", Name = "马糖*100ml" });
            resultList.Add(new TestData() { Code = "008", Name = "羊糖*200ml" });
            resultList.Add(new TestData() { Code = "009", Name = "猴糖*300ml" });
            resultList.Add(new TestData() { Code = "010", Name = "鸡糖*400ml" });
            resultList.Add(new TestData() { Code = "011", Name = "狗糖*500ml" });
            resultList.Add(new TestData() { Code = "012", Name = "猪糖*600ml" });

            return resultList;
        }

    }


}
