using System.Collections.Generic;
using Bashi.Core.Enums;
using NUnit.Framework;

namespace Bashi.Core.Tests.Enums
{
    [TestFixture]
    public class EnumUtilTests
    {
        private enum TestColour
        {
            Red,
            Green,
            Blue,
        }

        [Test]
        public void GetValues_ShouldReturnAllEnumMembers()
        {
            var expected = new List<TestColour> { TestColour.Red, TestColour.Green, TestColour.Blue };
            Assert.That(EnumUtil.GetValues<TestColour>(), Is.EqualTo(expected).AsCollection);
        }
    }
}
