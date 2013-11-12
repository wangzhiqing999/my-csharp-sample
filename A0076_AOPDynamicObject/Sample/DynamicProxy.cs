using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Dynamic;
using System.Reflection;


namespace A0076_AOPDynamicObject.Sample
{


    /// <summary>
    /// 动态代理类.
    /// 
    /// DynamicObject 为 .NET 4.0  新特性.
    /// </summary>
    public class DynamicProxy : DynamicObject
    {

        /// <summary>
        /// 实际的真实地对象
        /// （被代理对象）
        /// </summary>
        private Object realObject;


        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="obj"></param>
        public DynamicProxy(Object obj)
        {
            realObject = obj;
        }




        /// <summary>
        /// 实现 代理类的 设置属性的处理.
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            realObject.GetType().GetProperty(binder.Name).SetValue(realObject, value, null);
            return true;
        }


        /// <summary>
        /// 实现 代理类的 读取属性的处理.
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = realObject.GetType().GetProperty(binder.Name).GetValue(realObject, null);
            return true;
        }


        /// <summary>
        /// 实现 代理类的 调用方法的处理.
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="args"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override bool TryInvokeMember(
            InvokeMemberBinder binder, object[] args, out object result)
        {

            try
            {

                Console.WriteLine("### 调用{0}方法开始！", binder.Name);


                result = realObject.GetType().InvokeMember(
                    binder.Name,
                    BindingFlags.InvokeMethod,
                    null,
                    realObject,
                    args);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());                
                Console.WriteLine("### 调用{0}方法过程中发生了异常！", binder.Name);

                throw;
            }
            finally
            {
                Console.WriteLine("### 调用{0}方法结束！", binder.Name);
            }
        }



    }


}
