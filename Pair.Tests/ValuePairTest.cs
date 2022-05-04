using Moq;
using Pair;
using Shouldly;
using Xunit;

namespace ValuePair.Tests
{
    public class ValuePairTest
    {

        [Theory]
        [InlineData(1, 2, 2, 1)]
        [InlineData(1, 2, 1, 2)]
        [InlineData(1, null, 1, null)]
        [InlineData(1, null, null, 1)]
        [InlineData(null, null, null, null)]
        public void EqualsIntTest(int? a1, int? b1, int? a2, int? b2)
        {
            var valuePair1 = new ValuePair<int?>(a1, b1);
            var valuePair2 = new ValuePair<int?>(a2, b2);

            valuePair1.Equals(valuePair2).ShouldBeTrue();
            (valuePair1 == valuePair2).ShouldBeTrue();
            (valuePair1 != valuePair2).ShouldBeFalse();
        }

        [Theory]
        [InlineData(1, 2, 2, 2)]
        [InlineData(1, 1, 2, 2)]
        [InlineData(2, null, 1, null)]
        [InlineData(0, null, null, null)]
        public void NotEqualsIntTest(int? a1, int? b1, int? a2, int? b2)
        {
            var valuePair1 = new ValuePair<int?>(a1, b1);
            var valuePair2 = new ValuePair<int?>(a2, b2);

            valuePair1.Equals(valuePair2).ShouldBeFalse();
            (valuePair1 != valuePair2).ShouldBeTrue();
            (valuePair1 == valuePair2).ShouldBeFalse();
        }

        [Fact]
        public void EqualsObjectTest()
        {
            var obj1 = new object();
            var obj2 = new object();
            var valuePair1 = new ValuePair<object>(obj1, obj2);
            var valuePair2 = new ValuePair<object>(obj2, obj1);

            valuePair1.Equals(valuePair2).ShouldBeTrue();
        }

        [Fact]
        public void NotEqualsObjectTest()
        {
            var obj1 = new object();
            var obj2 = new object();
            var obj3 = new object();
            var valuePair1 = new ValuePair<object>(obj1, obj2);
            var valuePair2 = new ValuePair<object>(obj2, obj3);

            valuePair1.Equals(valuePair2).ShouldBeFalse();
        }

        [Fact]
        public void EqualsNullObjectTest()
        {
            var obj1 = new object();
            var valuePair1 = new ValuePair<object?>(obj1, null);
            var valuePair2 = new ValuePair<object?>(null, obj1);

            valuePair1.Equals(valuePair2).ShouldBeTrue();
        }

        [Fact]
        public void NotEqualsDifferentTypeObjectTest()
        {
            var obj1 = new object();
            var valuePair1 = new ValuePair<object?>(obj1, null);

            valuePair1.Equals(obj1).ShouldBeFalse();
            valuePair1.Equals(null).ShouldBeFalse();
        }

        [Theory]
        [InlineData(1, 2, 2, 1)]
        [InlineData(1, 2, 1, 2)]
        [InlineData(1, null, 1, null)]
        [InlineData(1, null, null, 1)]
        [InlineData(null, null, null, null)]
        public void EqualHashCodeIntTest(int? a1, int? b1, int? a2, int? b2)
        {
            var valuePair1 = new ValuePair<int?>(a1, b1);
            var valuePair2 = new ValuePair<int?>(a2, b2);

            valuePair1.GetHashCode().ShouldBe(valuePair2.GetHashCode());
        }

        [Theory]
        [InlineData(1, 2, 2, 2)]
        [InlineData(1, 1, 2, 2)]
        [InlineData(2, null, 1, null)]
        [InlineData(0, null, null, null)]
        public void NotEqualHashCodeIntTest(int? a1, int? b1, int? a2, int? b2)
        {
            var valuePair1 = new ValuePair<int?>(a1, b1);
            var valuePair2 = new ValuePair<int?>(a2, b2);

            valuePair1.GetHashCode().ShouldNotBe(valuePair2.GetHashCode());
        }

        [Fact]
        public void HashCodeObjectTest()
        {
            var obj1 = new object();
            var obj2 = new object();
            var valuePair1 = new ValuePair<object>(obj1, obj2);
            var valuePair2 = new ValuePair<object>(obj2, obj1);

            valuePair1.GetHashCode().ShouldBe(valuePair2.GetHashCode());
        }

        [Theory]
        [InlineData(1, 2, 2, 1)]
        [InlineData(1, 2, 1, 2)]
        public void IComparableTest(int a1, int b1, int a2, int b2)
        {
            var pairMock = new Mock<IPair<object>>();
            pairMock.SetupGet(x => x.Item1).Returns(a1);
            pairMock.SetupGet(x => x.Item2).Returns(b1);

            var valuePair = new ValuePair<object>(a2, b2);

            valuePair.Equals(pairMock.Object).ShouldBeTrue();
            valuePair.Equals((object)pairMock.Object).ShouldBeTrue();
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, null)]
        public void ItemsArrayTest(int? a, int? b)
        {
            var valuePair = new ValuePair<int?>(a, b);

            valuePair.Items.ShouldContain(a);
            valuePair.Items.ShouldContain(b);
        }

    }
}