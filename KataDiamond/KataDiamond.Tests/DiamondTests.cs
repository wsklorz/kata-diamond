using FluentAssertions;
using NUnit.Framework;

namespace KataDiamond.Tests;

[TestFixture]
public class DiamondTests
{
    private static readonly char[] AllLetters = Alphabet.Letters;

    private static readonly object[][] AllLettersWithPosition = Alphabet.Letters.Select((c, i) => new object[] { c, i }).ToArray();

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

    [TestCaseSource(nameof(AllLetters))]
    public void FirstAndLastRowContainSingleA(char midpoint)
    {
        // arrange
        // act
        var diamond = new Diamond(midpoint, '-');

        // assert
        diamond.Data.First().Should().Contain("A", Exactly.Once());
        diamond.Data.Last().Should().Contain("A", Exactly.Once());
    }

    [TestCaseSource(nameof(AllLetters))]
    public void GridIsHorizontallyAndVerticallySymetric(char midpoint)
    {
        // arrange
        // act
        var diamond = new Diamond(midpoint, '-');

        // assert
        foreach (var s in diamond.Data)
        {
            s.Length.Should().Be(diamond.Data.Length);
        }

        for (var index = 0; index < diamond.Data.Length / 2; index++)
        {
            var side1 = diamond.Data[index];
            var side2 = diamond.Data[diamond.Data.Length - index - 1];
            side1.Should().Be(side2);
        }
    }

    [TestCaseSource(nameof(AllLettersWithPosition))]
    public void MidpointLetterPositionInAlphabetIsCorrect(char midpoint, int  expectedMidpointPosition)
    {
        // arrange
        char separator = '-';

        // act
        var diamond = new Diamond(midpoint, separator);

        // assert
        diamond.MidpointPosition.Should().Be(expectedMidpointPosition);
    }

    [TestCaseSource(nameof(AllLetters))]
    public void MiddleRowContainsTheMidpointLetter(char midpoint)
    {
        // arrange
        char separator = '-';

        // act
        var diamond = new Diamond(midpoint, separator);

        // assert
        diamond.Data[diamond.MidpointPosition].Should().Contain(midpoint.ToString(), Exactly.Twice());
    }
}