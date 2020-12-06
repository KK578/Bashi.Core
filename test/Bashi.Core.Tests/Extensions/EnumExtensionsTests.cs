using Bashi.Core.Extensions;
using Bashi.Core.Tests.Utils;
using NUnit.Framework;

namespace Bashi.Core.Tests.Extensions
{
    [TestFixture]
    public class EnumExtensionsTests
    {
        public class GetDescriptionTests
        {
            [Test]
            public void GetDescription_GivenMemberDoesNotHaveDescriptionAttribute_ShouldReturnToString()
            {
                Assert.That(EnumUtilTests.TestColour.Yellow.GetDescription(), Is.EqualTo("Yellow"));
            }

            [Test]
            public void GetDescription_GivenMemberDoesHaveDescriptionAttribute_ShouldReturnDescriptionValue()
            {
                Assert.That(EnumUtilTests.TestColour.Red.GetDescription(), Is.EqualTo("#FF0000"));
                Assert.That(EnumUtilTests.TestColour.Green.GetDescription(), Is.EqualTo("#00FF00"));
                Assert.That(EnumUtilTests.TestColour.Blue.GetDescription(), Is.EqualTo("#0000FF"));
            }
        }
    }
}
