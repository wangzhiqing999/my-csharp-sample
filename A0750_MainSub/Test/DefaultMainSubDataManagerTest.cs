using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using A0750_MainSub.Sample;

namespace A0750_MainSub.Test
{
     [TestFixture]
    public class DefaultMainSubDataManagerTest
    {

         [Test]
         public void Test1500()
         {
             // 拆分单位 = 1500 没单位.
             DefaultMainSubDataManager manager = new DefaultMainSubDataManager()
             {
                  MaxSubValue = 1500
             };


             // 初始金额= 8K.
             MainData mainData = new MainData()
             {
                 MainInitValue = 8000
             };

             // 拆分.
             manager.InsertNewMainData(mainData);


             // 拆分后子数据列表不为 NULL
             Assert.IsNotNull(mainData.SubDataList);

             // 子数据列表长度应为 6个  其中， 前5个是满的 1500， 最后一个是 500
             Assert.AreEqual(6, mainData.SubDataList.Count);

             for (int i = 0; i < 5; i++)
             {
                 Assert.AreEqual(1500, mainData.SubDataList[i].SubInitValue);
                 Assert.AreEqual(1500, mainData.SubDataList[i].SubBalanceValue);
             }
             Assert.AreEqual(500, mainData.SubDataList[5].SubInitValue);
             Assert.AreEqual(500, mainData.SubDataList[5].SubBalanceValue);



             // 测试消耗一次.
             bool updateResult = manager.UpdateMainData(mainData, -500);
             // 成功.
             Assert.IsTrue(updateResult);

             // 首行消耗 500， 其它保持不变.
             Assert.AreEqual(1000, mainData.SubDataList[0].SubBalanceValue);
             for (int i = 1; i < 5; i++)
             {
                 Assert.AreEqual(1500, mainData.SubDataList[i].SubBalanceValue);
             }
             Assert.AreEqual(500, mainData.SubDataList[5].SubBalanceValue);




             updateResult = manager.UpdateMainData(mainData, -3000);
             // 成功.
             Assert.IsTrue(updateResult);

             // 前2行余额0， 第3行消耗 500， 其它保持不变.
             for (int i = 0; i < 2; i++)
             {
                 Assert.AreEqual(0, mainData.SubDataList[i].SubBalanceValue);
             }

             Assert.AreEqual(1000, mainData.SubDataList[2].SubBalanceValue);

             for (int i = 3; i < 5; i++)
             {
                 Assert.AreEqual(1500, mainData.SubDataList[i].SubBalanceValue);
             }
             Assert.AreEqual(500, mainData.SubDataList[5].SubBalanceValue);





             updateResult = manager.UpdateMainData(mainData, -1500);
             // 成功.
             Assert.IsTrue(updateResult);


             // 前3行余额0， 第4行消耗 500， 其它保持不变.
             for (int i = 0; i < 3; i++)
             {
                 Assert.AreEqual(0, mainData.SubDataList[i].SubBalanceValue);
             }

             Assert.AreEqual(1000, mainData.SubDataList[3].SubBalanceValue);

             for (int i = 4; i < 5; i++)
             {
                 Assert.AreEqual(1500, mainData.SubDataList[i].SubBalanceValue);
             }
             Assert.AreEqual(500, mainData.SubDataList[5].SubBalanceValue);







             updateResult = manager.UpdateMainData(mainData, 3000);
             // 成功.
             Assert.IsTrue(updateResult);

             // 前1行余额0， 第2行消耗 500， 其它保持不变.
             for (int i = 0; i < 1; i++)
             {
                 Assert.AreEqual(0, mainData.SubDataList[i].SubBalanceValue);
             }

             Assert.AreEqual(1000, mainData.SubDataList[1].SubBalanceValue);

             for (int i = 2; i < 5; i++)
             {
                 Assert.AreEqual(1500, mainData.SubDataList[i].SubBalanceValue);
             }
             Assert.AreEqual(500, mainData.SubDataList[5].SubBalanceValue);



         }


    }


}
