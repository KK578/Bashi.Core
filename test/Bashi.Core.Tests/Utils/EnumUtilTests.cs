using System;
using System.Collections.Generic;
using Bashi.Core.Utils;
using NUnit.Framework;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Bashi.Core.Tests.Utils
{
    [TestFixture]
    public class EnumUtilTests
    {
        public enum TestColour
        {
            [Description("#FF0000")] Red,
            [Description("#00FF00")] Green,
            [Description("#0000FF")] Blue,
            Yellow
        }

        [Test]
        public void GetValues_ShouldReturnAllEnumMembers()
        {
            var expected = new List<TestColour>
            {
                TestColour.Red,
                TestColour.Green,
                TestColour.Blue,
                TestColour.Yellow
            };
            Assert.That(EnumUtil.GetValues<TestColour>(), Is.EqualTo(expected).AsCollection);
        }

        [Test]
        [TestCase("#FF0000", TestColour.Red)]
        [TestCase("Red", TestColour.Red)]
        [TestCase("#00FF00", TestColour.Green)]
        [TestCase("Green", TestColour.Green)]
        [TestCase("#0000FF", TestColour.Blue)]
        [TestCase("Blue", TestColour.Blue)]
        [TestCase("Yellow", TestColour.Yellow)]
        public void ParseWithDescription_ShouldHandleParsableCases(string description, EnumUtilTests.TestColour expected)
        {
            Assert.That(EnumUtil.ParseWithDescription<TestColour>(description), Is.EqualTo(expected));
        }

        [Test]
        public void ParseWithDescription_WhenCaseSensitiveParsing_ShouldThrowIfDescriptionNotExactMatch()
        {
            Assert.That(() => EnumUtil.ParseWithDescription<TestColour>("#ff0000", StringComparer.Ordinal),
                        Throws.Exception);
        }

        [Test]
        public void ParseWithDescription_ShouldThrowIfNotParseable()
        {
            Assert.That(() => EnumUtil.ParseWithDescription<TestColour>("#FFFF00"), Throws.Exception);
        }
    }
}
