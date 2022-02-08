using System;
using System.Collections.Generic;

namespace MusicPrefApp.Application.Helpers
{
    //https://stackoverflow.com/questions/489258/linqs-distinct-on-a-particular-property
    public static class IEnumerableExtensions
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var seenKeys = new HashSet<TKey>();
            foreach (var element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
}
