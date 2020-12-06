using System.Diagnostics.CodeAnalysis;
using Bashi.Core.TinyTypes;
using Bashi.Tests.Framework.Data;
using NUnit.Framework;

namespace Bashi.Core.Tests.TinyTypes
{
    [TestFixture]
    [SuppressMessage("ReSharper", "SuspiciousTypeConversion.Global", Justification = "Verifying equalities")]
    [SuppressMessage("ReSharper", "RedundantCast", Justification = "Verifying specific equalities")]
    public class TinyTypeTests
    {
        private class MyNumber : TinyType<int>
        {
            public MyNumber(int value)
                : base(value)
            {
            }
        }

        public class CompareToTests
        {
            [Test]
            public void GivenNullOrNonMatchingTypes_ThenWillThrowException()
            {
                var tt = new MyNumber(TestData.WellKnownInt);

                Assert.That(() => tt.CompareTo((object?)null), Throws.ArgumentNullException);
                Assert.That(() => tt.CompareTo((MyNumber?)null), Throws.ArgumentNullException);
                Assert.That(() => tt.CompareTo(TestData.WellKnownInt), Throws.ArgumentException);
                Assert.That(() => tt.CompareTo(TestData.WellKnownString), Throws.ArgumentException);
            }

            [Test]
            public void GivenMatchingTypes_ThenWillCompareByUnderlying()
            {
                var tt = new MyNumber(TestData.WellKnownInt);
                var value = TestData.NextInt();

                Assert.That(tt.CompareTo(new MyNumber(value)), Is.EqualTo(TestData.WellKnownInt.CompareTo(value)));
                Assert.That(tt.CompareTo(new MyNumber(TestData.WellKnownInt)), Is.Zero);
                Assert.That(tt.CompareTo((object)tt), Is.Zero);
                Assert.That(tt.CompareTo(tt), Is.Zero);
            }
        }

        public class EqualsTests
        {
            [Test]
            public void GivenANonMatchingTypeAndValue_ThenTheyAreNotEqual()
            {
                var tt = new MyNumber(TestData.WellKnownInt);

                Assert.That(tt.Equals(TestData.WellKnownInt), Is.False);
                Assert.That(tt.Equals((double)TestData.WellKnownInt), Is.False);
                Assert.That(tt.Equals((object?)null), Is.False);
            }

            [Test]
            public void GivenAMatchingType_WhenValuesDoNotMatch_ThenTheyAreNotEqual()
            {
                var tt = new MyNumber(TestData.WellKnownInt);

                var differentInt = TestData.NextInt();
                Assert.That(tt.Equals(new MyNumber(differentInt)), Is.False);
                Assert.That(tt == new MyNumber(differentInt), Is.False);
                Assert.That(tt != new MyNumber(differentInt), Is.True);
                Assert.That(tt.Equals((MyNumber?)null), Is.False);
            }

            [Test]
            public void GivenAMatchingType_WhenValuesDoNotMatch_ThenTheyAreEqual()
            {
                var tt = new MyNumber(TestData.WellKnownInt);

                Assert.That(tt.Equals(tt), Is.True);
                Assert.That(tt.Equals((object)tt), Is.True);
                Assert.That(tt.Equals(new MyNumber(TestData.WellKnownInt)), Is.True);
                Assert.That(tt.Equals(new MyNumber(TestData.WellKnownInt) as object), Is.True);
                Assert.That(tt == new MyNumber(TestData.WellKnownInt), Is.True);
            }
        }

        public class GetHashCodeTests
        {
            [Test]
            public void MatchesUnderlyingValueHashCode()
            {
                var tt = new MyNumber(TestData.WellKnownInt);
                Assert.That(tt.GetHashCode(), Is.EqualTo(TestData.WellKnownInt.GetHashCode()));
            }
        }

        public class OperationTests
        {
            [Test]
            public void ShouldAutomaticallyConvertValues()
            {
                var tt = new MyNumber(TestData.WellKnownInt);
                int value = tt;
                Assert.That(tt.Value, Is.EqualTo(value));
                Assert.That(value, Is.EqualTo(TestData.WellKnownInt));
            }
        }
    }
}
