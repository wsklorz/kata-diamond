using FluentAssertions;
using NUnit.Framework;

namespace KataDiamond.Tests;

[TestFixture]
public class DiamondTests
{
    private static readonly char[] AllLetters = Alphabet.Letters;

    private static readonly char[] AllLettersWithoutA = Alphabet.Letters.Except("A").ToArray();

    private static readonly object[][] AllLettersWithPosition = Alphabet.Letters.Select((c, i) => new object[] { c, i }).ToArray();

    private static readonly char[] SomeUnsupportedCharacters = "1234567890-_!@#$%^&*()Ł".ToCharArray();

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

    [TestCaseSource(nameof(SomeUnsupportedCharacters))]
    public void CannotCreateDiamondForLetterOutsideOfEnglishAlphabet(char midpoint)
    {
        // arrange
        char separator = ' ';

        // act
        var action = () => new Diamond(midpoint, separator);

        // assert
        action.Should().Throw<UnsupportedDiamondMidpointCharacterException>();
    }

    [Test]
    public void ForMidpointATheDiamondConsistsOfOnlyA()
    {
        // arrange
        // act
        var diamond = new Diamond('A', '-');

        // assert
        diamond.Data.Should().HaveCount(1);
        diamond.Data[0].Should().Be("A");
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
            var side2 = GetMirroredRow(diamond, index);
            side1.Should().Be(side2);
        }
    }

    [TestCaseSource(nameof(AllLettersWithPosition))]
    public void MidpointLetterPositionInAlphabetIsCorrect(char midpoint, int expectedMidpointPosition)
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
        diamond.Data[diamond.MidpointPosition].Should().Contain(midpoint.ToString(), midpoint == 'A' ? Exactly.Once() : Exactly.Twice());
    }

    [TestCaseSource(nameof(AllLetters))]
    public void MiddleRowContainsNoMargins(char midpoint)
    {
        // arrange
        char separator = '-';

        // act
        var diamond = new Diamond(midpoint, separator);

        // assert
        diamond.Data[diamond.MidpointPosition].Should().NotStartWith(separator.ToString());
        diamond.Data[diamond.MidpointPosition].Should().NotEndWith(separator.ToString());
    }

    [TestCaseSource(nameof(AllLetters))]
    public void MarginsSizeShouldStartFromMidpointPositionMinusOneAndDecrement(char midpoint)
    {
        // arrange
        char separator = '-';

        // act
        var diamond = new Diamond(midpoint, separator);

        // assert

        for (int index = 0, marginSize = diamond.MidpointPosition; index < diamond.Data.Length / 2; index++, marginSize--)
        {
            var side1 = diamond.Data[index];
            var side2 = GetMirroredRow(diamond, index);

            side1.Should().StartWith(new string(separator, marginSize));
            side2.Should().StartWith(new string(separator, marginSize));
        }
    }

    [TestCaseSource(nameof(AllLettersWithoutA))]
    public void AfterALetterMiddleSpaceStartsAppearingInTheSecondRowAndIncrementsByTwo(char midpoint)
    {
        // arrange
        char separator = '-';

        // act
        var diamond = new Diamond(midpoint, separator);

        // assert
        for (int index = 1, middleSpaceCount = 1; index <= diamond.Data.Length / 2; index++, middleSpaceCount += 2)
        {
            var side1 = diamond.Data[index];
            var side2 = GetMirroredRow(diamond, index);

            var expectedMiddleSpace = new string(separator, middleSpaceCount);
            side1.Should().Contain(expectedMiddleSpace);
            side2.Should().Contain(expectedMiddleSpace);
        }
    }

    private static string GetMirroredRow(Diamond diamond, int index)
    {
        return diamond.Data[diamond.Data.Length - index - 1];   
    }
}