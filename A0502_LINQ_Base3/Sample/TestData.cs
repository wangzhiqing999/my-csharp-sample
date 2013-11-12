using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;



namespace A0502_LINQ_Base3.Sample
{

	/// <summary>
	/// 测试数据.
	/// </summary>
	public class TestData
	{
		/// <summary>
		/// 编号.
		/// </summary>
		public int ID { set; get; }

		/// <summary>
		/// 姓名.
		/// </summary>
		public string Name { set; get; }

		/// <summary>
		/// 年龄.
		/// </summary>
		public int Age { set; get; }


		/// <summary>
		/// 性别.
		/// </summary>
		public string Sex { set; get; }


		/// <summary>
		/// 电话列表.
		/// </summary>
		public List<string> PhoneList { set; get; }
	}





	[TestFixture]
	public class MyLinqTest
	{
		/// <summary>
		/// 数据列表.
		/// </summary>
		private List<TestData> dataList;

		/// <summary>
		/// 初始化测试数据
		/// </summary>
		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			dataList = new List<TestData>();
			// 追加测试数据.

			dataList.Add(
				new TestData()
				{
					ID = 4,
					Name = "张三",
					Age = 30,
					Sex = "男",
					PhoneList = new List<string> { "13000000001", "13000000002", "13000000003" }
				});

			dataList.Add(
				new TestData()
				{
					ID = 3,
					Name = "李四",
					Age = 40,
					Sex = "女",
					PhoneList = new List<string> { "14000000001", "14000000002", "14000000003" }
				});

			dataList.Add(
				new TestData()
				{
					ID = 2,
					Name = "王五",
					Age = 50,
					Sex = "男",
					PhoneList = new List<string> { "15000000001", "15000000002", "15000000003" }
				});

			dataList.Add(
				new TestData()
				{
					ID = 1,
					Name = "赵六",
					Age = 60,
					Sex = "女",
					PhoneList = new List<string> { "16000000001", "16000000002", "16000000003" }
				});
		}

		/// <summary>
		/// All
		/// Returns true if all the items in the source data match the predicate
		/// </summary>
		[Test]
		public void TestAll()
		{
			// 所有的 用户 年龄 大于 0 . 预期结果为  true.
			Assert.True(dataList.All(p => p.Age > 0));

			// 所有的 用户 年龄 大于 40.  预期结果为  false.
			Assert.False(dataList.All(p => p.Age > 40));

			// 所有的 用户 年龄 大于 100.  预期结果为  false.
			Assert.False(dataList.All(p => p.Age > 100));
		}


		/// <summary>
		/// Any
		/// Returns true if at least one of the items in the source data matches the predicate
		/// </summary>
		[Test]
		public void TestAny()
		{
			// 任意一个 用户 年龄 大于 0 . 预期结果为  true.
			Assert.True(dataList.Any(p => p.Age > 0));

			// 任意一个 用户 年龄 大于 40.  预期结果为  true.
			Assert.True(dataList.Any(p => p.Age > 40));

			// 任意一个 用户 年龄 大于 100.  预期结果为  false.
			Assert.False(dataList.Any(p => p.Age > 100));
		}



		/// <summary>
		/// Count
		/// Returns the number of items in the data source
		/// </summary>
		[Test]
		public void TestCount()
		{
			// 用户 年龄 大于 0  的 用户数 . 预期结果为  4.
			Assert.AreEqual(4, dataList.Count(p => p.Age > 0));

			// 用户 年龄 大于 40 的 用户数 . 预期结果为  2.
			Assert.AreEqual(2, dataList.Count(p => p.Age > 40));

			// 用户 年龄 大于 100 的 用户数.  预期结果为  0.
			Assert.AreEqual(0, dataList.Count(p => p.Age > 100));
		}


		/// <summary>
		/// First
		/// Returns the first item from the data source
		/// </summary>
		[Test]
		public void TestFirst()
		{
			// 无任何条件的情况下，第一行记录，应该为  张三.
			Assert.AreEqual("张三", dataList.First().Name);

			// 大于 40岁的，第一行记录，应该为 王五
			Assert.AreEqual("王五", dataList.First(p => p.Age > 40).Name);
		}


		/// <summary>
		/// First
		/// Returns the first item from the data source
		/// </summary>
		[Test]
		[ExpectedException(typeof(System.InvalidOperationException))]
		public void TestFirst2()
		{
			// 列表中没有 大于 100 岁的用户.
			// First 将抛出异常!
			Assert.IsNull(dataList.First(p => p.Age > 100));

			// 由于上面的代码发生了异常，下面这句应该执行不到。
			Assert.Fail("本测试应该触发一个异常。");
		}



		/// <summary>
		/// FirstOrDefault
		/// Returns the first item from the data source or the default value if there are no items.
		/// </summary>
		[Test]
		public void TestFirstOrDefault()
		{
			// 无任何条件的情况下，第一行记录，应该为  张三.
			Assert.AreEqual("张三", dataList.FirstOrDefault().Name);

			// 大于 40岁的，第一行记录，应该为 王五
			Assert.AreEqual("王五", dataList.FirstOrDefault(p => p.Age > 40).Name);

			// 列表中没有 大于 100 岁的用户.
			Assert.IsNull(dataList.FirstOrDefault(p => p.Age > 100));
		}




		/// <summary>
		/// Last
		/// Returns the last item in the data source
		/// </summary>
		[Test]
		public void TestLast()
		{
			// 无任何条件的情况下，最后一行记录，应该为  赵六.
			Assert.AreEqual("赵六", dataList.Last().Name);

			// 小于等于 50岁的，最后一行记录，应该为 王五
			Assert.AreEqual("王五", dataList.Last(p => p.Age <= 50).Name);
		}


		/// <summary>
		/// Last
		/// Returns the last item in the data source
		/// </summary>
		[Test]
		[ExpectedException(typeof(System.InvalidOperationException))]
		public void TestLast2()
		{
			// 列表中没有 大于 100 岁的用户.
			// Last 将抛出异常!
			Assert.IsNull(dataList.Last(p => p.Age > 100));

			// 由于上面的代码发生了异常，下面这句应该执行不到。
			Assert.Fail("本测试应该触发一个异常。");
		}


		/// <summary>
		/// LastOrDefault
		///
		/// Returns the last item in the data source or the default value if there are no items
		/// </summary>
		[Test]
		public void TestLastOrDefault()
		{
			// 无任何条件的情况下，最后一行记录，应该为  赵六.
			Assert.AreEqual("赵六", dataList.LastOrDefault().Name);

			// 小于等于 50岁的，最后一行记录，应该为 王五
			Assert.AreEqual("王五", dataList.LastOrDefault(p => p.Age <= 50).Name);

			// 列表中没有 大于 100 岁的用户.
			Assert.IsNull(dataList.LastOrDefault(p => p.Age > 100));
		}



		/// <summary>
		/// Max
		/// Min
		/// Returns the largest or smallest value specified by a lambda expression
		/// </summary>
		[Test]
		public void TestMaxMin()
		{
			// 列表中，年龄最小的是 30.
			Assert.AreEqual(30, dataList.Min(p => p.Age));

			// 列表中，年龄最大的是 60.
			Assert.AreEqual(60, dataList.Max(p=>p.Age));


			// 列表中，ID 最小是 1.
			Assert.AreEqual(1, dataList.Min(p => p.ID));

			// 列表中，ID 最大是 4.
			Assert.AreEqual(4, dataList.Max(p => p.ID));
		}



		/// <summary>
		/// OrderBy
		/// OrderByDescending
		///
		/// Sorts the source data based on the value returned by the lambda expression
		/// </summary>
		[Test]
		public void TestOrderBy()
		{
			// 按照 ID 排序.
			List<TestData> afterSortList = dataList.OrderBy(p => p.ID).ToList();

			Assert.AreEqual(1, afterSortList[0].ID);
			Assert.AreEqual(2, afterSortList[1].ID);
			Assert.AreEqual(3, afterSortList[2].ID);
			Assert.AreEqual(4, afterSortList[3].ID);


			// 按照 年龄  排序 （降序）.
			List<TestData> afterSortList2 = dataList.OrderByDescending(p => p.Age).ToList();
			Assert.AreEqual(60, afterSortList2[0].Age);
			Assert.AreEqual(50, afterSortList2[1].Age);
			Assert.AreEqual(40, afterSortList2[2].Age);
			Assert.AreEqual(30, afterSortList2[3].Age);
		}


		/// <summary>
		/// Reverse
		///
		/// Reverses the order of the items in the data source
		/// </summary>
		[Test]
		public void TestReverse()
		{
			// 暂时 复制 数据列表.
			List<TestData> tempList = new List<TestData>();
			foreach (TestData data in dataList)
			{
				tempList.Add(data);
			}


			// 反转前
			Assert.AreEqual(4, tempList[0].ID);
			Assert.AreEqual(3, tempList[1].ID);
			Assert.AreEqual(2, tempList[2].ID);
			Assert.AreEqual(1, tempList[3].ID);


			// 反转.
			tempList.Reverse();

			// 反转后.
			Assert.AreEqual(1, tempList[0].ID);
			Assert.AreEqual(2, tempList[1].ID);
			Assert.AreEqual(3, tempList[2].ID);
			Assert.AreEqual(4, tempList[3].ID);
		}



		/// <summary>
		/// Select
		/// Projects a result from a query
		/// </summary>
		[Test]
		public void TestSelect()
		{
			List<string> tmpList =
				dataList.Select(p =>
					p.Name.Substring(0,1)
					+ (p.Sex == "男"?"先生":"小姐") ).ToList();

			Assert.AreEqual("张先生", tmpList[0]);
			Assert.AreEqual("李小姐", tmpList[1]);
			Assert.AreEqual("王先生", tmpList[2]);
			Assert.AreEqual("赵小姐", tmpList[3]);
		}



		/// <summary>
		/// SelectMany
		/// Projects each data item into a sequence of items and then concatenates
		/// all of those resulting sequences into a single sequence
		/// </summary>
		[Test]
		public void TestSelectMany()
		{
			// 获取 用户列表中 的 电话号码列表.
			List<string> tmpList =
				dataList.SelectMany(p =>p.PhoneList).ToList();

			// 4个用户， 每人3个号码。
			// 最后合计应该为  12 个号码.
			Assert.AreEqual(12, tmpList.Count);
		}



		/// <summary>
		/// Single
		/// Returns the first item from the data source or throws an exception
		/// if there are multiple matches
		/// </summary>
		[Test]
		public void TestSingle()
		{
			// 年龄等于 50岁的，应该为 王五
			Assert.AreEqual("王五", dataList.Single(p => p.Age == 50).Name);
		}


		[Test]
		[ExpectedException(typeof(System.InvalidOperationException))]
		public void TestSingle2()
		{
			// 年龄大于等于 50岁的，应该有2行记录.
			dataList.Single(p => p.Age >= 50);

			// 由于上面的代码发生了异常，下面这句应该执行不到。
			Assert.Fail("本测试应该触发一个异常。");
		}


		[Test]
		[ExpectedException(typeof(System.InvalidOperationException))]
		public void TestSingle3()
		{
			// 年龄大于等于 100岁的，应该没有记录.
			dataList.Single(p => p.Age >= 100);

			// 由于上面的代码发生了异常，下面这句应该执行不到。
			Assert.Fail("本测试应该触发一个异常。");
		}




		/// <summary>
		/// SingleOrDefault
		/// Returns the first item from the data source
		/// or the default value if there are no items,
		/// or throws an exception if there are multiple matches
		/// </summary>
		[Test]
		public void TestSingleOrDefault()
		{
			// 年龄等于 50岁的，应该为 王五
			Assert.AreEqual("王五", dataList.SingleOrDefault(p => p.Age == 50).Name);

			// 年龄大于等于 100岁的，应该没有记录.
			Assert.IsNull(dataList.SingleOrDefault(p => p.Age >= 100));
		}


		[Test]
		[ExpectedException(typeof(System.InvalidOperationException))]
		public void TestSingleOrDefault2()
		{
			// 年龄大于等于 50岁的，应该有2行记录.
			dataList.SingleOrDefault(p => p.Age >= 50);

			// 由于上面的代码发生了异常，下面这句应该执行不到。
			Assert.Fail("本测试应该触发一个异常。");
		}



		/// <summary>
		/// Skip
		/// SkipWhile
		/// Skips over a specified number of elements, or skips while the predicate matches
		/// </summary>
		[Test]
		public void TestSkipSkipWhile()
		{
			// 默认 第一行是 张三.
			Assert.AreEqual("张三", dataList.FirstOrDefault().Name);

			// 跳过一行， 是李四.
			Assert.AreEqual("李四", dataList.Skip(1).FirstOrDefault().Name);

			// 跳过二行， 是王五.
			Assert.AreEqual("王五", dataList.Skip(2).FirstOrDefault().Name);

			// 跳过三行， 是赵六.
			Assert.AreEqual("赵六", dataList.Skip(3).FirstOrDefault().Name);

			// 跳过四行，就没数据了.
			Assert.IsNull(dataList.Skip(4).FirstOrDefault());


			// 遇到年龄 小于 50 的， 跳过！
			Assert.AreEqual("王五", dataList.SkipWhile(p=>p.Age < 50).FirstOrDefault().Name);

			// 遇到 年龄 小于 100 的 跳过！ (这里是全部跳到底)。
			Assert.IsNull(dataList.SkipWhile(p=>p.Age < 100).FirstOrDefault());
		}




		/// <summary>
		/// Sum
		/// Totals the values selected by the predicate
		/// </summary>
		[Test]
		public void TestSum()
		{
			// ID 为 4,3,2,1 合计后 = 10
			Assert.AreEqual(10, dataList.Sum(p=>p.ID));

			// Age 为 30 40 50 60
			// 合计后为 180
			Assert.AreEqual(180, dataList.Sum(p => p.Age));


			// ID > 5 的数据不存在.
			// 测试 空白列表， 合计是否能正确的表示为 零。
			Assert.AreEqual(0, dataList.Where(p => p.ID > 5).Sum(p => p.ID));
		}



		/// <summary>
		/// Take
		/// TakeWhile
		///
		/// Selects a specified number of elements from the start of the data source
		/// or selects items while the predicate matches
		/// </summary>
		[Test]
		public void TestTakeTakeWhile()
		{
			// 获取列表的 “前2行”
			List<TestData> tmpList = dataList.Take(2).ToList(); ;

			// 能获取到2行.
			Assert.AreEqual(2, tmpList.Count());

			// 第1行是 id=4 的数据.
			Assert.AreEqual(4, tmpList[0].ID);
			// 第2行是 id=3 的数据.
			Assert.AreEqual(3, tmpList[1].ID);



			// 获取列表中  id < 3 的数据.
			tmpList = dataList.TakeWhile(p => p.ID < 3).ToList();

			// 因为 第一行的数据， ID = 4
			// 而条件为 ID < 3
			// 因此直接返回了.
			// 能获取到0行.
			Assert.AreEqual(0, tmpList.Count());



			// 获取列表中  id >= 3 的数据.
			tmpList = dataList.TakeWhile(p => p.ID >= 3).ToList();

			// 能获取到2行.
			Assert.AreEqual(2, tmpList.Count());

			// 第1行是 id=4 的数据.
			Assert.AreEqual(4, tmpList[0].ID);
			// 第2行是 id=3 的数据.
			Assert.AreEqual(3, tmpList[1].ID);
		}





		/// <summary>
		/// Where
		///
		/// Filters items from the data source that do not match the predicate
		///
		/// </summary>
		[Test]
		public void TestWhere()
		{
			// 获取列表的 “ID >= 3”的数据.
			List<TestData> tmpList = dataList.Where(p=>p.ID >=3).ToList();

			// 能获取到2行.
			Assert.AreEqual(2, tmpList.Count());

			// 第1行是 id=4 的数据.
			Assert.AreEqual(4, tmpList[0].ID);
			// 第2行是 id=3 的数据.
			Assert.AreEqual(3, tmpList[1].ID);
		}



	}

}
