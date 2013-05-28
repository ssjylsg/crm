using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Model;

namespace WebCrm.Dao
{
    internal static class DaoHelper
    {
        public static NHibernate.IQuery StringEqual(this NHibernate.IQuery query, string key, object value)
        {
            if (value == null)
            {
                return query;
            }
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return query;
            }
            return query.SetString(key.Replace(".", string.Empty), value.ToString());
        }
        public static NHibernate.IQuery StringLike(this NHibernate.IQuery query, string key, object value)
        {
            if (value == null)
            {
                return query;
            }
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return query;
            }
            return query.SetString(key.Replace(".", string.Empty), string.Format("%{0}%", value.ToString()));
        }
        public static NHibernate.IQuery IntEqual(this NHibernate.IQuery query, string key, object value)
        {
            if (((value ?? string.Empty).ToString()).IsInt())
            {
                return query.SetInt32(key.Replace(".", string.Empty), int.Parse(value.ToString()));
            }
            return query;
        }
        public static string AppendHsql(this string sql, string key, object value)
        {
            if (value == null)
            {
                return sql;
            }
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return sql;
            }
            return string.Format(" {0} And {1} = {2} ", sql, key, key.Replace(".", string.Empty));
        }
        public static StringBuilder IntAppendHsql(this StringBuilder sql, string key, object value)
        {
            if (value == null)
            {
                return sql;
            }
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return sql;
            }
            return sql.AppendFormat("   And ({1} = :{2}) ", sql, key, key.Replace(".", string.Empty)).AppendLine();
        }
        public static StringBuilder StringLikeAppendHsql(this StringBuilder sql, string key, object value)
        {
            if (value == null)
            {
                return sql;
            }
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return sql;
            }
            return sql.AppendFormat("   And ({1} Like :{2}) ", sql, key, key.Replace(".", string.Empty)).AppendLine();
        }
        /// <summary>
        /// 填充查询值
        /// </summary>
        /// <param name="query"></param>
        /// <param name="dictionary"></param>
        /// <param name="likeKey">需要执行的Like 的键值</param>
        /// <returns></returns>
        public static NHibernate.IQuery SetValue(this NHibernate.IQuery query, IDictionary<string, object> dictionary, params string[] likeKey)
        {
            foreach (KeyValuePair<string, object> keyValuePair in dictionary)
            {
                if (likeKey != null && likeKey.Length >= 0)
                {
                    if (likeKey.Contains(keyValuePair.Key))
                    {
                        query.StringLike(keyValuePair.Key, keyValuePair.Value);
                    }
                    else
                    {
                        query.StringEqual(keyValuePair.Key, keyValuePair.Value);
                    }
                }
                else
                {
                    query.StringEqual(keyValuePair.Key, keyValuePair.Value);
                }

            }
            return query;
        }
        /// <summary>
        /// 设置分页信息
        /// </summary>
        /// <param name="query"></param>
        /// <param name="pagerInfo"></param>
        /// <returns></returns>
        public static NHibernate.IQuery SetPagerInfo(this NHibernate.IQuery query, Pager pagerInfo)
        {
            return query.SetFirstResult(pagerInfo.PageSize * (pagerInfo.CurrentPageIndex - 1))
                .SetMaxResults(pagerInfo.PageSize);
        }
        public static int ObjectToInt(this object o)
        {
            if (o == null)
            {
                return 0;
            }
            if (!o.ToString().IsInt())
            {
                return 0;
            }
            return int.Parse(o.ToString());
        }
    }
}
