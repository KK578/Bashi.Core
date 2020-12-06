using System;
using System.Globalization;
using Bashi.Core.TinyTypes;
using Bashi.Tests.Framework.Data;
using NUnit.Framework;

namespace Bashi.Core.Tests.TinyTypes
{
    [TestFixture]
    public class TinyStringTests
    {
        private class MyTinyString : TinyString
        {
            public MyTinyString(string value)
                : base(value)
            {
            }
        }

        private class MySensitiveTinyString : TinyString
        {
            public MySensitiveTinyString(string value)
                : base(value, StringComparer.Ordinal)
            {
            }
        }

        public class CompareToTests
        {
            [Test]
            public void GivenNull_ThenShouldThrowException()
            {
                var tt = new MyTinyString(TestData.WellKnownString);
                Assert.That(() => tt.CompareTo((object?)null), Throws.ArgumentNullException);
                Assert.That(() => tt.CompareTo((MyTinyString?)null), Throws.ArgumentNullException);
            }

            [Test]
            public void GivenStringWithDifferentCases_WhenStringComparerIgnoresCase_ThenShouldBeZero()
            {
                var tt = new MyTinyString(TestData.WellKnownString);
                var upperTt = new MyTinyString(TestData.WellKnownString.ToUpper(CultureInfo.InvariantCulture));
                Assert.That(tt.CompareTo(upperTt), Is.Zero);
            }

            [Test]
            public void GivenStringWithDifferentCases_WhenStringComparerIsCaseSensitive_ThenShouldBeZero()
            {
                var tt = new MySensitiveTinyString(TestData.WellKnownString);
                var upperTt = new MySensitiveTinyString(TestData.WellKnownString.ToUpper(CultureInfo.InvariantCulture));
                Assert.That(tt.CompareTo(upperTt), Is.Not.Zero);
            }
        }

        public class EqualsTests
        {
            [Test]
            public void GivenStringsWithDifferentCases_WhenStringComparerIgnoresCase_ThenShouldBeTrue()
            {
                var tt = new MyTinyString(TestData.WellKnownString);
                var upperTt = new MyTinyString(TestData.WellKnownString.ToUpper(CultureInfo.InvariantCulture));
                Assert.That(tt.Equals(upperTt), Is.True);
            }

            [Test]
            public void GivenStringsWithDifferentCases_WhenStringComparerIsCaseSensitive_ThenShouldBeFalse()
            {
                var tt = new MySensitiveTinyString(TestData.WellKnownString);
                var upperTt = new MySensitiveTinyString(TestData.WellKnownString.ToUpper(CultureInfo.InvariantCulture));
                Assert.That(tt.Equals(upperTt), Is.False);
            }
        }

        public class GetHashCodeTests
        {
            [Test]
            public void GivenStringsWithDifferentCases_WhenStringComparerIgnoresCase_ThenShouldBeTrue()
            {
                var tt = new MyTinyString(TestData.WellKnownString);
                var upperTt = new MyTinyString(TestData.WellKnownString.ToUpper(CultureInfo.InvariantCulture));
                Assert.That(tt.GetHashCode(), Is.EqualTo(upperTt.GetHashCode()));
            }

            [Test]
            public void GivenStringsWithDifferentCases_WhenStringComparerIsCaseSensitive_ThenShouldBeFalse()
            {
                var tt = new MySensitiveTinyString(TestData.WellKnownString);
                var upperTt = new MySensitiveTinyString(TestData.WellKnownString.ToUpper(CultureInfo.InvariantCulture));
                Assert.That(tt.GetHashCode(), Is.Not.EqualTo(upperTt.GetHashCode()));
            }
        }
    }
}
