﻿using Bashi.Core.Enums;
using NUnit.Framework;

namespace Bashi.Core.Tests.Enums
{
    [TestFixture]
    public class EnumExtensionsTests
    {
        [Test]
        public void GetDescription_GivenMemberDoesNotHaveDescriptionAttribute_ShouldReturnToString()
        {
            Assert.That(TestColour.Yellow.GetDescription(), Is.EqualTo("Yellow"));
        }

        [Test]
        public void GetDescription_GivenMemberDoesHaveDescriptionAttribute_ShouldReturnDescriptionValue()
        {
            Assert.That(TestColour.Red.GetDescription(), Is.EqualTo("#FF0000"));
            Assert.That(TestColour.Green.GetDescription(), Is.EqualTo("#00FF00"));
            Assert.That(TestColour.Blue.GetDescription(), Is.EqualTo("#0000FF"));
        }
    }
}