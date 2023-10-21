using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RetroBack.Common.Extentions
{
    public static class IQueryableExtensions
    {
        private const string Descending = "desc";
        private const string OrderDescending = "OrderByDescending";
        private const string OrderAscending = "OrderBy";
        private const string ThenByDescending = "ThenByDescending";
        private const string ThenByAscending = "ThenBy";

        public static IQueryable<T> OrderByField<T>(this IQueryable<T> query, string fieldName, string orderDirection)
        {
            if (!string.IsNullOrEmpty(fieldName))
            {
                string method =
                    !string.IsNullOrWhiteSpace(orderDirection) && orderDirection.ToLower().Trim().Equals(Descending)
                        ? OrderDescending
                        : OrderAscending;

                return ApplyOrder<T>(query, fieldName, method);
            }

            return query;
        }

        public static IQueryable<T> ThenByField<T>(this IQueryable<T> query, string fieldName, string orderDirection)
        {
            if (!string.IsNullOrEmpty(fieldName))
            {
                string method =
                !string.IsNullOrWhiteSpace(orderDirection) && orderDirection.ToLower().Trim().Equals(Descending)
                    ? ThenByDescending
                    : ThenByAscending;

                return ApplyOrder<T>(query, fieldName, method);
            }

            return query;
        }

        public static bool ContainsLowered(this IEnumerable<string> texts, string filter) => texts.Any(t => t.ContainsLowered(filter));

        public static bool ContainsLowered(this string text, string filter) => text.Trim().ToLower().Contains(filter.Trim().ToLower());

        public static IQueryable<TData> OrderBySpec<TData>(this IQueryable<TData> query, string fieldName,
            string orderDirection)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(TData), "x");
            //uppercase first letter
            string newName = fieldName[0].ToString().ToUpper() + fieldName[1..];
            MemberExpression body = Expression.Property(parameter, newName);
            Expression<Func<TData, object>> orderByExpression =
                Expression.Lambda<Func<TData, object>>(Expression.Convert(body, typeof(object)),
                    parameter); //convert required for nullable columns

            return orderDirection != Descending ? query.OrderBy(orderByExpression) : (IQueryable<TData>)query.OrderByDescending(orderByExpression);
        }

        private static IOrderedQueryable<T> ApplyOrder<T>(IQueryable<T> source, string property, string methodName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(property))
                {
                    return source.OrderBy(e => e.GetType().GetProperties().FirstOrDefault());
                }

                string[] props = property.Split('.');
                Type type = typeof(T);
                ParameterExpression arg = Expression.Parameter(type, "x");
                Expression expr = arg;

                foreach (string prop in props)
                {
                    // use reflection (not ComponentModel) to mirror LINQ
                    PropertyInfo pi = type.GetProperty(prop,
                        BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                    if (pi == null)
                    {
                        pi = type.GetProperties().First();
                        expr = Expression.Property(expr, pi);
                        break;
                    }

                    expr = Expression.Property(expr, pi);
                    type = pi.PropertyType;
                }

                Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
                LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);

                object result = typeof(Queryable).GetMethods().Single(
                        method => method.Name == methodName
                                  && method.IsGenericMethodDefinition
                                  && method.GetGenericArguments().Length == 2
                                  && method.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), type)
                    .Invoke(null, new object[] { source, lambda });

                return (IOrderedQueryable<T>)result;
            }
            catch
            {
                return (IOrderedQueryable<T>)source;
            }
        }

        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> array, int batch = 500)
        {
            int skippedValues = 0;
            while (skippedValues < array.Count())
            {
                yield return array.Skip(skippedValues).Take(batch).ToArray();
                skippedValues += batch;
            }
        }

        public static IEnumerable<string> FilterString(this IEnumerable<string> enumerable, string filter) => string.IsNullOrWhiteSpace(filter) ? enumerable : enumerable.Where(el => el.ToLower().Contains(filter.ToLower()));
    }
}
