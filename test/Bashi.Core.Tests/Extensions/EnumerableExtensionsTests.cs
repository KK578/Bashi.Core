using System.Collections.Generic;
using System.Linq;
using Bashi.Core.Extensions;
using NUnit.Framework;

namespace Bashi.Core.Tests.Extensions
{
    [TestFixture]
    public class EnumerableExtensionsTests
    {
        [Test]
        public void NullToEmpty_GivenNull_ThenReturnsEmpty()
        {
            IEnumerable<string>? source = null;
            Assert.That(source.NullToEmpty(), Is.Not.Null);
        }

        [Test]
        public void NullToEmpty_GivenNonNull_ThenReturnsSameInstance()
        {
            IEnumerable<string> source = Enumerable.Empty<string>();
            IEnumerable<int> source2 = Enumerable.Range(0, 5);
            Assert.That(source.NullToEmpty(), Is.EqualTo(source));
            Assert.That(source2.NullToEmpty(), Is.EqualTo(source2));
        }
    }
}
