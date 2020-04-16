using System;
using System.Collections.Generic;

namespace SST.Application.Common.Extensions
{
    public static class SortedListExtensions
    {
        public static SortedList<TKey, TValue> ToSortedList<TSource, TKey, TValue>(
            this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TValue> valueSelector)
        {
            var ret = new SortedList<TKey, TValue>();
            foreach (var element in source)
            {
                ret.Add(keySelector(element), valueSelector(element));
            }

            return ret;
        }
    }
}
