using System;
using System.Collections.Generic;
using System.Linq;

namespace Bashi.Core.Enums
{
    /// <summary>
    /// Provides various static utility methods to be used on <see cref="System.Enum"/> values.
    /// </summary>
    public static class EnumUtil
    {
        /// <summary>
        /// Retrieves a strongly-typed read-only list of the values of the constants in the specified enumeration <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">Enum type to get the values of.</typeparam>
        /// <returns>All values in the specified enum.</returns>
        public static IReadOnlyList<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList().AsReadOnly();
        }
    }
}
