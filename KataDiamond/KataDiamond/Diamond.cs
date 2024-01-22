namespace KataDiamond;

public class Diamond
{
    public Diamond(char midpoint, char separator)
    {
        Midpoint = midpoint;
        Separator = separator;
    }

    public char Separator { get; }

    public char Midpoint { get; }
}