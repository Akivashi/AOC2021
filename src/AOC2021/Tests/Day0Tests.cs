using Day0;
using FluentAssertions;
using Xunit;

namespace Tests
{
    public class Day0Tests
    {
        [Fact]
        public void Assignment1ShouldReturn1()
        {
            Program.Assignment1().Should().Be(1);
        }

        [Fact]
        public void Assignment2ShouldReturn2()
        {
            Program.Assignment2().Should().Be(2);
        }
    }
}