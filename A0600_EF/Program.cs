using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Objects;

using A0600_EF.Sample;

namespace A0600_EF
{
	class Program
	{

		static void Main(string[] args)
		{
            // 基本功能测试
            BaseTest();

            // 事务处理的测试
            TransactionTest();


            // 动态查询的测试.
            IQueryableTest(null, null);
            IQueryableTest(1, null);
            IQueryableTest(null, "ONE");
            IQueryableTest(1, "ONE");



            // 应用对已分离对象的更改
            ApplyPropertyChangesTest();


            // ESQL 测试.
            EsqlTest();


            // 延迟加载/Include  测试.
            IncludeTest();

            Console.ReadLine();
        }



        /// <summary>
        /// 基本的 查询 / 插入 / 更新 / 删除 处理.
        /// </summary>
        private static void BaseTest()
        {
            TestEntities context = new TestEntities();
			// 单表查询
			var query =
				from testMain in context.test_main
				select testMain;
			foreach (test_main main in query)
			{
				Console.WriteLine("Main[{0}, {1}]", main.id, main.value);
			}

			// 关联查询
			var query2 =
				from testSub in context.test_sub
				where testSub.test_main.value == "ONE"
				select testSub;
			foreach (test_sub sub in query2)
			{
				Console.WriteLine("Sub[{0}, {1}]", sub.id, sub.value);
			}

			// 插入.
			test_main main3 = new test_main();
			main3.id = 3;
			main3.value = "Three";
			context.AddObject("test_main", main3);
			context.SaveChanges();

			Console.WriteLine("INSERT FINISH!");
			Console.ReadLine();

			// 更新.
			var newTestMain =
				(from testMain in context.test_main
				 where testMain.id == 3
				 select testMain).First();
			newTestMain.value = "Three3";
			context.SaveChanges();

			Console.WriteLine("UPDATE FINISH!");
			Console.ReadLine();

			// 单表查询 TOP 2
			var queryTop2 =
				(from testMain in context.test_main
				 orderby testMain.id descending
				 select testMain).Take(2);

			foreach (test_main main in queryTop2)
			{
				Console.WriteLine("Main[{0}, {1}]", main.id, main.value);
			}

			// 删除.
			context.DeleteObject(newTestMain);
			context.SaveChanges();

			Console.WriteLine("DELETE FINISH!");
			Console.ReadLine();
		}




        /// <summary>
        /// 应用对已分离对象的更改
        /// </summary>
        private static void ApplyPropertyChangesTest()
        {

            Console.WriteLine("========== 应用对已分离对象的更改 ==========");

            TestEntities context = new TestEntities();

            // 单表查询
            test_main mainData = context.test_main.FirstOrDefault(p=>p.id == 2);
            Console.WriteLine("Init:  Main[{0}, {1}]", mainData.id, mainData.value);




            // 分离对象 
            // 在分离对象时，应考虑以下注意事项：
            // Detach 只影响传递给该方法的特定对象。如果要分离的对象在对象上下文中具有相关对象，则那些相关对象不会分离。
            // 不会为已分离的对象维护关系信息。
            // 分离对象后，不会维护对象状态信息。这包括所跟踪的更改和临时键值。
            // 分离对象不影响数据存储区中的数据。
            // 在分离操作过程中不会强制执行级联删除指令和引用约束。
            // 在考虑分离对象的优点时，应该注意执行该操作所需的处理。当用户数据的范围已经更改（例如，用一组不同的数据显示新窗体）时，应该考虑创建一个新的 ObjectContext 实例，而不只是从现有 ObjectContext 分离对象。

            context.Detach(mainData);


            // 上面的代码， 可以理解为：
            // 首先，从数据库检索出数据
            // 然后，分离对象
            // 分离后的对象， Context 不再管理了
            // 主要应用于 服务器端， 查询数据以后， 不维持数据的变更管理
            // 把数据 发送给客户端。

            
            // 而客户端 拿到的数据， 相当于是  与 数据库无关的
            // 因为对 “分离后的数据” 做任意修改
            // 简单调用  SaveChanges 将不会更新数据库表中的数据。

            // 分离对象的修改. 
            mainData.value = "TwoTwo";

            // 保持数据更改.
            context.SaveChanges();

            // 再次查询， 数据没有发生任何变化.
            test_main mainData2 = context.test_main.FirstOrDefault(p => p.id == 2);
            Console.WriteLine("Detach and Save Main[{0}, {1}]", mainData2.id, mainData2.value);
            context.Detach(mainData2);






            // 下面是模拟 服务器端， 接收到一个 客户端的 更新请求时， 如何处理的例子.

            // 主键
            EntityKey key;
            // 旧数据.
            object originalItem;

            using (TestEntities updateContext = new TestEntities())
            {
                try
                {
                    // 根据 修改后的数据， 获取其主键 （注意： 更新处理是只改数据，不修改主键的）
                    key = updateContext.CreateEntityKey("test_main", mainData);

                    // 尝试通过主键， 获取数据库中的数据.
                    if (updateContext.TryGetObjectByKey(key, out originalItem))
                    {
                        // 调用 ApplyPropertyChanges 方法，来更新数据.
                        updateContext.ApplyPropertyChanges(
                            key.EntitySetName, mainData);
                    }

                    updateContext.SaveChanges();
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }



            // 再次查询， 数据发生变化.
            mainData2 = context.test_main.FirstOrDefault(p => p.id == 2);
            Console.WriteLine("ApplyPropertyChanges and Save  Main[{0}, {1}]", mainData2.id, mainData2.value);

            // 最后改回原始情况
            mainData2.value = "TWO";
            context.SaveChanges();




        }



        /// <summary>
        /// 事务处理测试.
        /// 
        /// 当调用 SaveChanges 时，如果当前事务存在，则对象服务将此事务用于对数据源进行的操作。
        /// 否则，将为操作创建新事务。
        /// 
        /// 可以使用 EntityTransaction、Transaction 或 TransactionScope 来定义事务。
        /// </summary>
        private static void TransactionTest()
        {

            TestEntities context = new TestEntities();


            // 插入.
            test_main main3 = new test_main();
            main3.id = 3;
            main3.value = "Three";
            context.AddObject("test_main", main3);

            // 插入.
            test_main main4 = new test_main();
            main4.id = 3;
            main4.value = "Three 4";
            context.AddObject("test_main", main4);

            try
            {
                context.SaveChanges();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }

            // 单表查询
            var query =
                from testMain in context.test_main
                where testMain.id == 3
                select testMain;


            Console.WriteLine("TestMain 表中， id=3 的记录有{0}条 ", query.Count());


        }






        /// <summary>
        /// 用于 动态的查询处理.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="val"></param>
        private static void IQueryableTest(int? id, string val)
        {
            // 如果 用户只输入了 id， 那么 只 where id = ?
            // 如果 用户只输入了 val， 那么 只 where value = ?
            // 如果 用户 id 和 val 都输入了， 那么 where  id=? and value = ?
            // 如果 用户 id 和 val 都没输入， 那么 where 也不需要了.

            Console.WriteLine("传入的参数：id={0}, val={1}", id, val);


            TestEntities context = new TestEntities();


            IQueryable<test_main> result = context.test_main;

            if (id != null)
            {
                result = result.Where(c => c.id == id);
            }
            if (val != null)
            {
                result = result.Where(c => c.value == val);
            }

            foreach (test_main data in result)
            {
                Console.WriteLine("Main[{0}, {1}]", data.id, data.value);
            }
        }




        /// <summary>
        /// ESQL 测试.
        /// </summary>
        private static void EsqlTest()
        {

            Console.WriteLine("==========  ESQL 测试.  ==========");

            using (var edm = new TestEntities())
            {

                // 定义 ESQL 查询.
                string esql =
                    @"
select 
  value c 
from 
  TestEntities.test_main as c
where
  NOT EXISTS (
    SELECT 1
    FROM
      TestEntities.test_main as c2
    WHERE
      c.id < c2.id
  )
";

                // 执行查询.
                ObjectQuery<test_main> query = edm.CreateQuery<test_main>(esql);

                // 输出 实际执行的 SQL 语句.
                Console.WriteLine(query.ToTraceString());

                // 获取查询结果
                ObjectResult<test_main> results = query.Execute(MergeOption.NoTracking);

                // 注意： MergeOption 枚举的说明.
                // AppendOnly
                // 不会从数据源加载对象上下文中已存在的对象。这是查询或调用 EntityCollection<TEntity> 的 Load 方法时的默认行为。
                // OverwriteChanges
                // 对象始终从数据源进行加载。数据源值会重写在对象上下文中对对象所做的任何属性更改。
                // PreserveChanges
                // 当一个对象存在于对象上下文中时，不会从数据源加载该对象。保存在对象上下文中对对象所做的任何属性更改。
                // NoTracking
                // 对象保持为 Detached 状态，也不在 ObjectStateManager 中进行跟踪。

                foreach (test_main data in results)
                {
                    Console.WriteLine("Main[{0}, {1}]", data.id, data.value);
                }

            }

        }




        /// <summary>
        /// 延迟加载/Include  测试.
        /// </summary>
        private static void IncludeTest()
        {

            Console.WriteLine("========== 延迟加载/Include测试 (Default) ==========");

            using (var db = new TestEntities())
            {
                var tMain = db.test_main;
                foreach (var data in tMain)
                {
                    Console.WriteLine("Main[{0}, {1}]", data.id, data.value);

                    foreach (var sData in data.test_sub)
                        Console.WriteLine("  Sub[{0}, {1}]", sData.id, sData.value );
                }
            }


            Console.WriteLine("========== 延迟加载/Include测试 ( With Include)==========");

            using (var db2 = new TestEntities())
            {
                var tMain = db2.test_main.Include("test_sub");
                foreach (var data in tMain)
                {
                    Console.WriteLine("Main[{0}, {1}]", data.id, data.value);

                    foreach (var sData in data.test_sub)
                        Console.WriteLine("  Sub[{0}, {1}]", sData.id, sData.value);
                }
            }
        }



	}
}
