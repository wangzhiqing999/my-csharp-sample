using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace MyWcfServiceLibrary
{




    [ServiceBehavior(
        ConcurrencyMode = ConcurrencyMode.Single, 
        InstanceContextMode = InstanceContextMode.PerCall,          
        TransactionTimeout = "00:30:00" )]
    public class Service1 : IService1
    {

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }




        /// <summary>
        /// 用于测试 事务处理的方法.
        /// 
        /// 下面的 
        /// TransactionScopeRequired = true 意味着， 这个方法需要一个事务。
        /// TransactionAutoComplete = true 意味着， 这个方法执行结束后，将提交事务 （如果执行没有抛出异常）。
        /// </summary>
        /// <param name="main_id"></param>
        /// <param name="main_val"></param>
        /// <param name="sub_id"></param>
        /// <param name="sub_value"></param>
        /// <returns></returns>
        [System.ServiceModel.OperationBehavior(
            TransactionScopeRequired = true, 
            TransactionAutoComplete = true)]
        public bool TestInsertData(int main_id, string main_val, int sub_id, string sub_value)
        {

            // 请注意： 
            // 是使用 WCF 来进行事务的管理.

            try
            {

                using (TestDataClassesDataContext context = new TestDataClassesDataContext())
                {

                    test_main mainData = new test_main()
                    {
                        id = main_id,
                        value = main_val
                    };


                    test_sub subData = new test_sub()
                    {
                        id = sub_id,
                        main_id = main_id,
                        value = sub_value
                    };


                    context.test_main.InsertOnSubmit(mainData);
                    context.test_sub.InsertOnSubmit(subData);

                    context.SubmitChanges();

                }



                return true;
            }
            catch (Exception ex)
            {
                // 由于是使用 WCF 来管理事务.
                // 因此，发生异常了， 就必须抛出异常
                // 不能自己 Catch 住了， 然后简单返回 false.

                // 如果自己 Catch 住了，简单返回 false 的话， WCF 认为你的程序执行正常，就你做的修改提交了，而不是回滚掉。
                throw new FaultException(ex.ToString(), new FaultCode(ex.Message));
            }
        }



        /// <summary>
        /// 用于删除记录的方法.
        /// </summary>
        /// <param name="main_id"></param>
        /// <returns></returns>
        [System.ServiceModel.OperationBehavior(
            TransactionScopeRequired = true,
            TransactionAutoComplete = true)]
        public bool TestDeleteData(int main_id)
        {

            try
            {

                using (TestDataClassesDataContext context = new TestDataClassesDataContext())
                {

                    var querySub =
                        from data in context.test_sub 
                        where data.main_id == main_id
                        select data;

                    foreach (test_sub subData in querySub)
                    {
                        context.test_sub.DeleteOnSubmit(subData);
                    }


                    var queryMain =
                        from data in context.test_main
                        where data.id == main_id
                        select data;

                    foreach (test_main mainData in queryMain)
                    {
                        context.test_main.DeleteOnSubmit(mainData);
                    }

                    context.SubmitChanges();
                }

            
                return true;
            }
            catch (Exception ex)
            {
                // 由于是使用 WCF 来管理事务.
                // 因此，发生异常了， 就必须抛出异常
                // 不能自己 Catch 住了， 然后简单返回 false.

                // 如果自己 Catch 住了，简单返回 false 的话， WCF 认为你的程序执行正常，就你做的修改提交了，而不是回滚掉。
                throw new FaultException(ex.ToString(), new FaultCode(ex.Message));
            }

        }









        #region 测试 WCF 调用 多个内部方法.


        /// <summary>
        /// 仅仅插入 主表.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        [System.ServiceModel.OperationBehavior(
            TransactionScopeRequired = true,
            TransactionAutoComplete = true)]
        public bool TestInsertMain(int id, string val)
        {
            // 请注意： 
            // 由于是使用 WCF 来进行事务的管理.
            try
            {

                using (TestDataClassesDataContext context = new TestDataClassesDataContext())
                {

                    test_main mainData = new test_main()
                    {
                        id = id,
                        value = val
                    };



                    context.test_main.InsertOnSubmit(mainData);


                    context.SubmitChanges();

                }



                return true;
            }
            catch (Exception ex)
            {
                // 由于是使用 WCF 来管理事务.
                // 因此，发生异常了， 就必须抛出异常
                // 不能自己 Catch 住了， 然后简单返回 false.

                // 如果自己 Catch 住了，简单返回 false 的话， WCF 认为你的程序执行正常，就你做的修改提交了，而不是回滚掉。
                throw new FaultException(ex.ToString(), new FaultCode(ex.Message));
            }
        }

        /// <summary>
        /// 仅仅插入 子表.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="main_id"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        [System.ServiceModel.OperationBehavior(
            TransactionScopeRequired = true,
            TransactionAutoComplete = true)]
        public bool TestInsertSub(int id, int main_id, string val)
        {

            // 请注意： 
            // 由于是使用 WCF 来进行事务的管理.
            try
            {

                using (TestDataClassesDataContext context = new TestDataClassesDataContext())
                {



                    test_sub subData = new test_sub()
                    {
                        id = id,
                        main_id = main_id,
                        value = val
                    };


                    context.test_sub.InsertOnSubmit(subData);

                    context.SubmitChanges();

                }



                return true;
            }
            catch (Exception ex)
            {
                // 由于是使用 WCF 来管理事务.
                // 因此，发生异常了， 就必须抛出异常
                // 不能自己 Catch 住了， 然后简单返回 false.

                // 如果自己 Catch 住了，简单返回 false 的话， WCF 认为你的程序执行正常，就你做的修改提交了，而不是回滚掉。
                throw new FaultException(ex.ToString(), new FaultCode(ex.Message));
            }
        }



        /// <summary>
        /// 调用 TestInsertMain 与 TestInsertSub
        /// 
        /// 分别插入 主表与子表.
        /// </summary>
        /// <param name="main_id"></param>
        /// <param name="main_val"></param>
        /// <param name="sub_id"></param>
        /// <param name="sub_value"></param>
        /// <returns></returns>
        [System.ServiceModel.OperationBehavior(
            TransactionScopeRequired = true,
            TransactionAutoComplete = true)]
        public bool TestInsertAll(int main_id, string main_val, int sub_id, string sub_value)
        {

            // 调用2个内部方法.

            // 测试的目的：
            // 这2个方法，在执行完毕后，都有  context.SubmitChanges(); 的处理。
            // 这里 预期是 
            //  第一个 方法执行成功后， context.SubmitChanges();
            //  第二个方法执行失败。
            //  需要确认 失败时，整个事物是否能够成功地回滚。

            TestInsertMain(main_id, main_val);
            TestInsertSub(sub_id, main_id, sub_value);

            return true;
        }


        #endregion  


    }
}
