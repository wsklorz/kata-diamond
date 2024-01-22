namespace KataDiamond;

public class Diamond
{
    public Diamond(char midpoint, char separator)
    {
        Midpoint = midpoint;
        Separator = separator;
        Data = CreateArray();
        PopulateData();
    }

    private void PopulateData()
    {
        for (int i = 0; i < Data.Length; i++)
        {
            Data[i] = $"A{new string(Separator, Data.Length - 1)}";
        }
    }

    public string[] Data { get; }

    public char Separator { get; }

    public char Midpoint { get; }

    public string[] CreateArray()
    {
        int midpointPosition = Alphabet.PositionOf(Midpoint);
        int size = (midpointPosition * 2) + 1;
        return new string[size];
    }
}