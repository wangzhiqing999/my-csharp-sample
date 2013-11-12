using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using A0610_EF.Sample;


namespace A0610_EF
{
    class Program
    {

        /// <summary>
        /// SQL Server 的数据库连接字符串.
        /// </summary>
        private const String connString =
            @"metadata=.\Sample\Test.csdl|.\Sample\Test.ssdl|.\Sample\Test.msl;
provider=System.Data.SqlClient;
provider connection string='Data Source=localhost\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True'";


        static void Main(string[] args)
        {
            TestContext context = new TestContext(connString);

            goods_type myType = new goods_type();
            myType.type_code = "T001";
            myType.type_name = "测试类型1";
            context.AddTogoods_type(myType);



            goods myGoods = new goods();
            myGoods.goodsid = "G001";
            myGoods.name = "测试货物1";
            myGoods.goods_type = myType;
            context.AddTogoods(myGoods);



            store myStore = new store();
            myStore.store_code = "S001";
            myStore.store_name = "测试仓库1";
            context.AddTostore(myStore);


            onhand myOnhand = new onhand();
            myOnhand.goods = myGoods;
            myOnhand.store = myStore;
            myOnhand.onhand1 = 100;

            context.AddToonhand(myOnhand);


          

            context.SaveChanges();
        }
    }
}
