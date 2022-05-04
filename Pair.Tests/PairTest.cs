using Moq;
using Shouldly;
using Xunit;

namespace Pair.Tests
{
    public class PairTest
    {

        [Theory]
        [InlineData(1, 2, 2, 1)]
        [InlineData(1, 2, 1, 2)]
        [InlineData(1, null, 1, null)]
        [InlineData(1, null, null, 1)]
        [InlineData(null, null, null, null)]
        public void EqualsIntTest(int? a1, int? b1, int? a2, int? b2)
        {
            var Pair1 = new Pair<int?>(a1, b1);
            var Pair2 = new Pair<int?>(a2, b2);

            Pair1.Equals(Pair2).ShouldBeTrue();
            (Pair1 == Pair2).ShouldBeTrue();
            (Pair1 != Pair2).ShouldBeFalse();
        }

        [Theory]
        [InlineData(1, 2, 2, 2)]
        [InlineData(1, 1, 2, 2)]
        [InlineData(2, null, 1, null)]
        [InlineData(0, null, null, null)]
        public void NotEqualsIntTest(int? a1, int? b1, int? a2, int? b2)
        {
            var Pair1 = new Pair<int?>(a1, b1);
            var Pair2 = new Pair<int?>(a2, b2);

            Pair1.Equals(Pair2).ShouldBeFalse();
            (Pair1 != Pair2).ShouldBeTrue();
            (Pair1 == Pair2).ShouldBeFalse();
        }

        [Fact]
        public void EqualsObjectTest()
        {
            var obj1 = new object();
            var obj2 = new object();
            var Pair1 = new Pair<object>(obj1, obj2);
            var Pair2 = new Pair<object>(obj2, obj1);

            Pair1.Equals(Pair2).ShouldBeTrue();
        }

        [Fact]
        public void NotEqualsObjectTest()
        {
            var obj1 = new object();
            var obj2 = new object();
            var obj3 = new object();
            var Pair1 = new Pair<object>(obj1, obj2);
            var Pair2 = new Pair<object>(obj2, obj3);

            Pair1.Equals(Pair2).ShouldBeFalse();
        }

        [Fact]
        public void EqualsNullObjectTest()
        {
            var obj1 = new object();
            var Pair1 = new Pair<object?>(obj1, null);
            var Pair2 = new Pair<object?>(null, obj1);

            Pair1.Equals(Pair2).ShouldBeTrue();
        }

        [Fact]
        public void NotEqualsDifferentTypeObjectTest()
        {
            var obj1 = new object();
            var Pair1 = new Pair<object?>(obj1, null);

            Pair1.Equals(obj1).ShouldBeFalse();
            Pair1.Equals(null).ShouldBeFalse();
        }

        [Theory]
        [InlineData(1, 2, 2, 1)]
        [InlineData(1, 2, 1, 2)]
        [InlineData(1, null, 1, null)]
        [InlineData(1, null, null, 1)]
        [InlineData(null, null, null, null)]
        public void EqualHashCodeIntTest(int? a1, int? b1, int? a2, int? b2)
        {
            var Pair1 = new Pair<int?>(a1, b1);
            var Pair2 = new Pair<int?>(a2, b2);

            Pair1.GetHashCode().ShouldBe(Pair2.GetHashCode());
        }

        [Theory]
        [InlineData(1, 2, 2, 2)]
        [InlineData(1, 1, 2, 2)]
        [InlineData(2, null, 1, null)]
        [InlineData(0, null, null, null)]
        public void NotEqualHashCodeIntTest(int? a1, int? b1, int? a2, int? b2)
        {
            var Pair1 = new Pair<int?>(a1, b1);
            var Pair2 = new Pair<int?>(a2, b2);

            Pair1.GetHashCode().ShouldNotBe(Pair2.GetHashCode());
        }

        [Fact]
        public void HashCodeObjectTest()
        {
            var obj1 = new object();
            var obj2 = new object();
            var Pair1 = new Pair<object>(obj1, obj2);
            var Pair2 = new Pair<object>(obj2, obj1);

            Pair1.GetHashCode().ShouldBe(Pair2.GetHashCode());
        }

        [Theory]
        [InlineData(1, 2, 2, 1)]
        [InlineData(1, 2, 1, 2)]
        public void IComparableTest(int a1, int b1, int a2, int b2)
        {
            var pairMock = new Mock<IPair<object>>();
            pairMock.SetupGet(x => x.Item1).Returns(a1);
            pairMock.SetupGet(x => x.Item2).Returns(b1);

            var Pair = new Pair<object>(a2, b2);

            Pair.Equals(pairMock.Object).ShouldBeTrue();
            Pair.Equals((object)pairMock.Object).ShouldBeTrue();
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, null)]
        public void ItemsArrayTest(int? a, int? b)
        {
            var Pair = new Pair<int?>(a, b);

            Pair.Items.ShouldContain(a);
            Pair.Items.ShouldContain(b);
        }

    }
}