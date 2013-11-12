using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyWcfServiceLibrary
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“TestService”。
    public class TestService : ITestService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }






        public List<test_main> GetTestMain()
        {
            using (TestEntities context = new TestEntities())
            {
                // 返回 主数据列表.
                return context.test_main.ToList();
            }
        }


        public List<test_sub> GetTestSub(test_main testMain)
        {
            using (TestEntities context = new TestEntities())
            {
                // 返回 子数据列表.
                return context.test_sub.Where(p => p.main_id == testMain.id).ToList();
            }
        }

    }
}
