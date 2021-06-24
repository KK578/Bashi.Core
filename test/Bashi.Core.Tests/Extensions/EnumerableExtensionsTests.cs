using System.Collections.Generic;
using System.Linq;
using Bashi.Core.Extensions;
using NUnit.Framework;

namespace Bashi.Core.Tests.Extensions
{
    [TestFixture]
    public class EnumerableExtensionsTests
    {
        public class AsReadOnlyListTests
        {
            [Test]
            public void GivenEnumerable_ThenReturnsNewList()
            {
                var enumerable = Enumerable.Range(1, 10);
                Assert.That(enumerable.AsReadOnlyList(), Is.Not.SameAs(enumerable));
            }

            [Test]
            public void GivenList_ThenReturnsNewList()
            {
                var list = Enumerable.Range(1, 10).ToList();
                Assert.That(list.AsReadOnlyList(), Is.Not.SameAs(list));
            }

            [Test]
            public void GivenReadOnlyList_ThenReturnsExistingList()
            {
                var readonlyList = Enumerable.Range(1, 10).ToList().AsReadOnly();
                Assert.That(readonlyList.AsReadOnlyList(), Is.SameAs(readonlyList));
            }
        }

        public class NullToEmptyTests
        {
            [Test]
            public void GivenNull_ThenReturnsEmpty()
            {
                IEnumerable<string>? source = null;
                Assert.That(source.NullToEmpty(), Is.Not.Null);
            }

            [Test]
            public void GivenNonNull_ThenReturnsSameInstance()
            {
                IEnumerable<string> source = Enumerable.Empty<string>();
                IEnumerable<int> source2 = Enumerable.Range(0, 5);
                Assert.That(source.NullToEmpty(), Is.SameAs(source));
                Assert.That(source2.NullToEmpty(), Is.SameAs(source2));
            }
        }

        public class FirstRandomTests
        {
            [Test]
            public void GivenEmptyList_ThenReturnsDefault()
            {
                var empty = Enumerable.Empty<int>();
                Assert.That(empty.FirstRandom(), Is.EqualTo(0));
            }

            [Test]
            public void GivenListOf10Items_ThenReturnsAnItemFromCollectionEachTime()
            {
                var list = Enumerable.Range(1, 10).ToList();
                for (var i = 0; i < 100; i++)
                {
                    Assert.That(list, Contains.Item(list.FirstRandom()));
                }
            }
        }
    }
}
