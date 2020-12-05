using System;
using System.Collections.Generic;
using System.Linq;
using Bashi.Core.Extensions;

namespace Bashi.Core.Utils
{
    /// <summary>
    /// Provides various static utility methods to be used on <see cref="System.Enum"/> values.
    /// </summary>
    public static class EnumUtil
    {
        /// <summary>
        /// Retrieves a strongly-typed enumerable of the values of the constants in the specified enumeration <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">Enum type to get the values of.</typeparam>
        /// <returns>All values in the specified enum.</returns>
        public static IEnumerable<T> GetValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList().AsReadOnly();
        }

        /// <summary>
        /// Gets the enum value corresponding to the given string description value.
        /// If an enum member is not found with the provided description, this method will fallback
        /// to <see cref="Enum.Parse{TEnum}(string)"/>.
        /// </summary>
        /// <param name="description">Description or String value of <typeparamref name="T"/> member.</param>
        /// <param name="comparer">Optional string comparer - defaults to <see cref="StringComparer.OrdinalIgnoreCase"/></param>
        /// <typeparam name="T">Enum type to be parsed to.</typeparam>
        /// <returns>Enum member value with the given description</returns>
        public static T ParseWithDescription<T>(string description, StringComparer? comparer = null)
            where T : struct, Enum
        {
            comparer ??= StringComparer.OrdinalIgnoreCase;
            var descriptions = EnumUtil.GetValues<T>().ToDictionary(x => x.GetDescription(), comparer);
            return descriptions.ContainsKey(description) ? descriptions[description] : Enum.Parse<T>(description);
        }
    }
}
