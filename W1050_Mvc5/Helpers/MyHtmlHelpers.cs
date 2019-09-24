using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;


namespace W1050_Mvc5.Helpers
{
    public static class MvcHtmlHelpers
    {
        /// <summary>
        /// 获取 属性的 描述字符串.
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="self"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static string DescriptionFor<TModel, TValue>(this HtmlHelper<TModel> self, Expression<Func<TModel, TValue>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, self.ViewData);
            var description = metadata.Description;

            return string.IsNullOrWhiteSpace(description) ? "" : description;
        }


        /// <summary>
        /// 获取 属性的 是否必需标签
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="self"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static MvcHtmlString IsRequiredFor<TModel, TValue>(this HtmlHelper<TModel> self, Expression<Func<TModel, TValue>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, self.ViewData);
            bool isRequired = metadata.IsRequired;

            // 这里是简单的，把 * ，作为一个 必须要输入的符号。
            // 如果需要替换字符，或者 加粗，红色 等设置， 修改下面的 样式即可.
            return MvcHtmlString.Create(string.Format(@"<span>{0}</span>", isRequired ? "*" : ""));
        }
    }
}