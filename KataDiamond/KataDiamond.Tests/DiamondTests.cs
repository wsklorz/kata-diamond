using FluentAssertions;
using NUnit.Framework;

namespace KataDiamond.Tests
{
    [TestFixture]
    public class DiamondTests
    {
        [Test]
        public void DummyTest()
        {
            // arrange
            char midpoint = 'A', separator = ' ';

            // act
            var diamond = new Diamond(midpoint, separator);
            
            // assert
            diamond.Midpoint.Should().Be(midpoint);
            diamond.Separator.Should().Be(separator);
        }
    }
}