using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace DOAN_CHuyenNGanh.Extentions
{
    public static class Extentions
    {
        public static string FormatWith(this string value, params object[] args)
        {
            return String.Format(value, args);
        }
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> query, string memberName, bool asc = true)
        {
            ParameterExpression[] typeParams = new ParameterExpression[] { Expression.Parameter(typeof(T), "") };
            System.Reflection.PropertyInfo pi = typeof(T).GetProperty(memberName);
            return (IOrderedQueryable<T>)query.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable),
                    asc ? "OrderBy" : "OrderByDescending",
                    new Type[] { typeof(T), pi.PropertyType },
                    query.Expression,
                    Expression.Lambda(Expression.Property(typeParams[0], pi), typeParams))
                );
        }
    }
}