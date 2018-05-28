using System;
using Xunit;
namespace MyFirstUnitTests
{
    public class Class1
    {
        

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(4,add(3,1));
        }

        [Fact]
        public void SuccessTest()
        {
            Assert.Equal(4,add(2,2));
        }
        public int add(int a, int b)
        {
            return a+b;
        }


        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]

        public void TestOdds(int value )
        {
            Assert.True(isOdd(value));
        }
        public bool isOdd(int value)
        {
            return value % 2 == 1;
        }
    }
}