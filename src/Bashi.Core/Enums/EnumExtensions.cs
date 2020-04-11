using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Bashi.Core.Enums
{
    /// <summary>
    /// Provides various extensions to be used on <see cref="System.Enum"/> values.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Provides an alternative implementation <see cref="System.Object.ToString"/> that uses <see cref="DescriptionAttribute"/> to provide a different value to the enum's name.
        /// If there is no <see cref="DescriptionAttribute"/> found on the enum member, it will default to the <see cref="System.Object.ToString"/> value.
        /// </summary>
        /// <param name="value">Enum member value to get the string description for.</param>
        /// <typeparam name="T">Enum type of the value.</typeparam>
        /// <returns>Description for <see cref="value"/>, ToString if Description unavailable.</returns>
        public static string GetDescription<T>(this T value) where T : Enum
        {
            var type = typeof(T);
            var enumName = Enum.GetName(type, value);
            var member = type.GetMember(enumName).FirstOrDefault();
            var attribute = member?.GetCustomAttribute<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
