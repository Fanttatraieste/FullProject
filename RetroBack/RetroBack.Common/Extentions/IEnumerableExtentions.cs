using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroBack.Common.Extentions
{
    public static class IEnumerableExtensions
    {
        public static bool IsNullOrEmpty(this IEnumerable enumerable) => enumerable == null || !enumerable.GetEnumerator().MoveNext();

        /// <summary>
        /// Will return the elements which exists in source (reference from source collection), which do not exist in destination, based on the key selector
        /// </summary>
        public static IEnumerable<TCollection> NotIn<TCollection, TKey>(this IEnumerable<TCollection> source,
            IEnumerable<TCollection> destination, Func<TCollection, TKey> keySelector) where TCollection : class
        {
            IEnumerable<TCollection> notIn = from s in source
                                             join d in destination
                                                 on keySelector(s) equals keySelector(d) into g
                                             from element in g.DefaultIfEmpty()
                                             where element == null
                                             select s;

            return notIn;
        }

        /// <summary>
        /// Will return the elements which exists in source (reference from source collection), which also exist in destination, based on the key selector
        /// </summary>
        public static IEnumerable<TCollection> In<TCollection, TKey>(this IEnumerable<TCollection> source,
            IEnumerable<TCollection> destination, Func<TCollection, TKey> keySelector) where TCollection : class
        {
            IEnumerable<TCollection> inDestination = from s in source
                                                     join d in destination
                                                         on keySelector(s) equals keySelector(d)
                                                     select s;

            return inDestination;
        }
    }
}
