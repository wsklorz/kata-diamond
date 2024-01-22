namespace KataDiamond;

public class UnsupportedDiamondMidpointCharacterException : Exception
{
    public UnsupportedDiamondMidpointCharacterException(char midpoint)
        : base($"Unsupported Diamond Midpoint Character: {midpoint}. The supported characters are: {new string(Alphabet.Letters)}")
    {
    }
}