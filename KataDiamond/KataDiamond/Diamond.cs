namespace KataDiamond;

public class Diamond
{
    public Diamond(char midpoint, char separator)
    {
        Midpoint = midpoint;
        Separator = separator;

        MidpointPosition = ValidateAndGetAlphabetPosition();

        Data = CreateArray();
        PopulateData();
    }

    public int MidpointPosition { get; }

    public string[] Data { get; }

    public char Separator { get; }

    public char Midpoint { get; }

    public string[] CreateArray()
    {
        int size = (MidpointPosition * 2) + 1;
        return new string[size];
    }

    private int ValidateAndGetAlphabetPosition()
    {
        var position = Alphabet.PositionOf(Midpoint);
        if (position < 0)
        {
            throw new UnsupportedDiamondMidpointCharacterException(Midpoint);
        }

        return position;
    }

    private void PopulateData()
    {
        string margin = new(Separator, MidpointPosition);

        SetCharactersOnBothSidesRows(0, $"{margin}A{margin}");

        for (int i = 1, middleSpaceCount = 1; i <= MidpointPosition; i++, middleSpaceCount += 2)
        {
            char letter = Alphabet.Letters[i];
            margin = new string(Separator, MidpointPosition - i);
            var middleSpace = new string(Separator, middleSpaceCount);
            SetCharactersOnBothSidesRows(i, $"{margin}{letter}{middleSpace}{letter}{margin}");
        }
    }

    private void SetCharactersOnBothSidesRows(int index, string characters)
    {
        Data[index] = characters;
        MirrorRow(index);
    }

    private void MirrorRow(int index)
    {
        Data[Data.Length - index - 1] = Data[index];
    }
}