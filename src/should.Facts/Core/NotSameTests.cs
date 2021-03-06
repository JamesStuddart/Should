using Should.Core.Exceptions;
using Xunit;
using Assert = Should.Core.Assertions.Assert;

namespace Should.Facts.Core
{
    public class NotSameTests
    {
        [Fact]
        public void NotSameFailsWith()
        {
            object actual = new object();

            try
            {
                Assert.NotSame(actual, actual);
            }
            catch (NotSameException exception)
            {
                Assert.Equal("Assert.NotSame() Failure", exception.UserMessage);
            }
        }

        [Fact]
        public void ValuesAreNotTheSame()
        {
            Assert.NotSame("bob", "jim");
        }

        [Fact]
        public void ValuesAreTheSame()
        {
            string jim = "jim";

            Assert.Throws<NotSameException>(() => Assert.NotSame(jim, jim));
        }

        [Fact]
        public void ValueTypesGetBoxedTwice()
        {
            int index = 0;

            Assert.NotSame(index, index);
        }
    }
}