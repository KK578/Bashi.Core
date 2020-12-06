using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Bashi.Core.Extensions
{
    public static class EnumerableExtensions
    {
        private static readonly Random Random = new();

        /// <summary>
        /// Returns the <paramref name="source"/> enumerable as a <see cref="IReadOnlyList{T}"/>.
        /// If it is already an instance of an <see cref="IReadOnlyList{T}"/>, then it will be returned as is.
        /// Otherwise it will be materialized to a new <see cref="IReadOnlyList{T}"/>.
        /// </summary>
        /// <param name="source">The enumerable to be turned into a <see cref="IReadOnlyList{T}"/>.</param>
        /// <typeparam name="T">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <returns>The <paramref name="source"/> enumerable if already readonly, otherwise it will be wrapped as read-only.</returns>
        public static IReadOnlyList<T> AsReadOnlyList<T>(this IEnumerable<T> source)
        {
            return source switch
            {
                IList<T> { IsReadOnly: false } list => new ReadOnlyCollection<T>(list),
                IReadOnlyList<T> readOnlyList => readOnlyList,
                _ => source.ToList().AsReadOnly()
            };
        }

        /// <summary>
        /// Returns the <paramref name="source"/> enumerable unchanged or an empty enumerable if <paramref name="source"/> is null.
        /// </summary>
        /// <param name="source">The enumerable to be null-checked.</param>
        /// <typeparam name="T">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <returns>The <paramref name="source"/> enumerable if present, else a new empty enumerable.</returns>
        public static IEnumerable<T> NullToEmpty<T>(this IEnumerable<T>? source)
        {
            return source ?? Enumerable.Empty<T>();
        }

        /// <summary>
        /// Returns a random entry from the <paramref name="source"/> enumerable.
        /// </summary>
        /// <param name="source">The enumerable to select from.</param>
        /// <typeparam name="T">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <returns>An instance of <typeparamref name="T"/> from the <paramref name="source"/> enumerable.</returns>
        public static T? FirstRandom<T>(this IEnumerable<T> source)
        {
            var list = source.ToList();
            return list.Count == 0 ? default : list[EnumerableExtensions.Random.Next(0, list.Count)];
        }
    }
}
