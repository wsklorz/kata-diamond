namespace KataDiamond;

public class Diamond
{
    public Diamond(char midpoint, char separator)
    {
        Midpoint = midpoint;
        Separator = separator;
        MidpointPosition = Alphabet.PositionOf(Midpoint);

        Data = CreateArray();
        PopulateData();
    }

    public int MidpointPosition { get; }

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
        int size = (MidpointPosition * 2) + 1;
        return new string[size];
    }
}