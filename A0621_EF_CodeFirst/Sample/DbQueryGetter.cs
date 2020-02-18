using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;


namespace A0621_EF_CodeFirst.Sample
{
    /// <summary>
    /// 获取 DbQuery 对象的元素.
    /// 
    /// 已有的系统中， 存在有， 随时间增长， 数据量越来越大的表.
    /// 
    /// 数据库层级上，可以通过 数据库作业， 定期，将 过早时间的数据， 移动到历史表中。
    /// 
    /// 例如：
    /// 原始数据表， 是： sms_log
    /// 当前表最多只存贮当月数据.
    /// 其他的数据，将被存储到历史数据表中。
    /// sms_log_201910
    /// sms_log_201911
    /// sms_log_201912
    /// sms_log_202001
    /// 
    /// 现有的查询数据的代码， 是 EF Code First 的写法.
    /// 也就是 
    /// var query = 
    ///     from data in db.SmsLogs 
    ///     select data;
    /// var dataList = query.ToList() 
    /// 只去查询 sms_log 表。
    /// 
    /// 
    /// 如果在特殊情况下， 管理页面， 需要去查询很早之前的历史数据时。 另外再从零开始，手写代码的成本略高。
    /// 这个类，用于从 已有的 query 中，  获取到 SQL 语句， 以及查询的参数.
    /// 
    /// 最终，外部可以 db.Database.SqlQuery<SmsLog>(sql, param).ToList()
    /// 来执行查询。
    /// 
    /// 那么， 当需要执行历史表的查询时。替换一下表名称即可.
    /// sql = sql.Replace("sms_log", "sms_log_202001");
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DbQueryGetter<T>
    {

        public static DbQueryResult GetDbQueryResult(dynamic dbQuery)
        {
            DbQuery<T> query = dbQuery;
            DbQueryResult result = new DbQueryResult()
            {
                Sql = query.Sql,
                ParameterList = new List<SqlParameter>()
            };

            // 获取查询的类型.
            Type queryType = query.GetType();


            int fromIndex = result.Sql.IndexOf("FROM");
            string selectSql = result.Sql.Substring(0, fromIndex);
            string fromWhereSql = result.Sql.Substring(fromIndex);

            // 表的类型.
            Type masterType = queryType.GenericTypeArguments[0];
            foreach (var member in masterType.GetProperties())
            {
                foreach (var attr in member.CustomAttributes)
                {
                    if (attr.AttributeType.Name == "ColumnAttribute")
                    {
                        string columnName = attr.ConstructorArguments[0].Value.ToString();
                        selectSql = selectSql.Replace($".[{columnName}] AS [{columnName}]", $".[{columnName}] AS [{member.Name}]");
                        break;
                    }
                }
            }
            result.Sql = $"{selectSql} {fromWhereSql}";


            // 查询的属性列表.
            PropertyInfo[] queryPropArray = queryType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (PropertyInfo prop in queryPropArray)
            {
                if (prop.Name == "InternalQuery")
                {
                    object internalQuery = prop.GetValue(query);
                    Type internalQueryType = internalQuery.GetType();
                    PropertyInfo objectQueryProp = internalQueryType.GetProperty("ObjectQuery");
                    ObjectQuery<T> objectQuery = objectQueryProp.GetValue(internalQuery) as ObjectQuery<T>;
                    if (objectQuery.Parameters.Count > 0)
                    {
                        foreach (var param in objectQuery.Parameters)
                        {
                            SqlParameter sqlParam = new SqlParameter($"@{param.Name}", System.Data.SqlDbType.VarChar);
                            sqlParam.Value = param.Value;
                            result.ParameterList.Add(sqlParam);
                        }
                    }
                }
            }
            return result;
        }
    }


    public class DbQueryResult
    {

        /// <summary>
        /// SQL 语句.
        /// </summary>
        public string Sql { set; get; }


        /// <summary>
        /// 参数列表.
        /// </summary>
        public List<SqlParameter> ParameterList { set; get; }

    }
}
