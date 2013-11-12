using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;



namespace A0007_Reflection_ModelCopyer.Model
{



    /// <summary>
    /// 通用 对象复制的代码.
    /// 
    /// 
    /// </summary>
    public class CommonModelCopyer
    {


        /// <summary>
        /// Model 对象数据复制.
        /// </summary>
        /// <param name="fromData"> 源数据 </param>
        /// <param name="toData"> 目标数据 </param>
        public static void ModelCopy(Object fromData, Object toData)
        {
            // 源对象类型.
            Type fromType = fromData.GetType();
            // 源对象的所有属性.
            PropertyInfo[] fromPropArray = fromType.GetProperties();

            // 目标对象类型.
            Type toType = toData.GetType();
            // 目标对象的所有属性.
            PropertyInfo[] toPropArray = toType.GetProperties();


            // 遍历源对象所有的属性.
            foreach (PropertyInfo fromProp in fromPropArray)
            {
                // 仅仅 处理  源对象  可以读取的属性.
                if (fromProp.CanRead)
                {
                    // 去目标对象查找， 是否存在有 同名 / 同数据类型 的属性.
                    PropertyInfo toProp = toPropArray.FirstOrDefault(
                        p => p.Name == fromProp.Name
                            && p.PropertyType.FullName == fromProp.PropertyType.FullName);

                    if (toProp == null)
                    {
                        // 源对象有属性. 目标对象没有.
                        // 忽略.
                        continue;
                    }

                    // 仅仅处理  目标对象 可以写入的属性.
                    if (toProp.CanWrite)
                    {
                        // 从 源对象 获取属性值.
                        Object propVal = fromProp.GetValue(fromData, null);

                        // 为目标对象，设置属性值.
                        toProp.SetValue(toData, propVal, null);
                    }

                }
            }


        }


    }
}
