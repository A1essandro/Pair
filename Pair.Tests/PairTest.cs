using Xunit;

namespace Pair.Tests
{
    public class PairTest
    {

        [Theory]
        [InlineData(1, 2, 2, 1)]
        [InlineData(1, 2, 1, 2)]
        public void EqualsIntTest(int a1, int b1, int a2, int b2)
        {
            var pair1 = new Pair<int>(a1, b1);
            var pair2 = new Pair<int>(a2, b2);

            Assert.Equal(pair1, pair2);
        }

        [Theory]
        [InlineData(1, 2, 2, 2)]
        [InlineData(1, 1, 2, 2)]
        public void NotEqualsIntTest(int a1, int b1, int a2, int b2)
        {
            var pair1 = new Pair<int>(a1, b1);
            var pair2 = new Pair<int>(a2, b2);

            Assert.NotEqual(pair1, pair2);
        }

        [Fact]
        public void EqualsObjectTest()
        {
            var obj1 = new object();
            var obj2 = new object();
            var pair1 = new Pair<object>(obj1, obj2);
            var pair2 = new Pair<object>(obj2, obj1);

            Assert.Equal(pair1, pair2);
        }

        [Fact]
        public void NotEqualsObjectTest()
        {
            var obj1 = new object();
            var obj2 = new object();
            var obj3 = new object();
            var pair1 = new Pair<object>(obj1, obj2);
            var pair2 = new Pair<object>(obj2, obj3);

            Assert.NotEqual(pair1, pair2);
        }

        [Theory]
        [InlineData(1, 2, 2, 1)]
        [InlineData(1, 2, 1, 2)]
        public void EqualHashCodeIntTest(int a1, int b1, int a2, int b2)
        {
            var pair1 = new Pair<int>(a1, b1);
            var pair2 = new Pair<int>(a2, b2);

            Assert.Equal(pair1.GetHashCode(), pair2.GetHashCode());
        }

        [Theory]
        [InlineData(1, 2, 2, 2)]
        [InlineData(1, 1, 2, 2)]
        public void NotEqualHashCodeIntTest(int a1, int b1, int a2, int b2)
        {
            var pair1 = new Pair<int>(a1, b1);
            var pair2 = new Pair<int>(a2, b2);

            Assert.NotEqual(pair1.GetHashCode(), pair2.GetHashCode());
        }

        [Fact]
        public void HashCodeObjectTest()
        {
            var obj1 = new object();
            var obj2 = new object();
            var pair1 = new Pair<object>(obj1, obj2);
            var pair2 = new Pair<object>(obj2, obj1);

            Assert.Equal(pair1.GetHashCode(), pair2.GetHashCode());
        }

    }
}