namespace KataDiamond;

public class App
{
    public const char DEFAULT_SEPARATOR_CHARACTER = '-';

    public void Run(string[] args)
    {
        if (args.Length == 0)
        {
            throw new ArgumentException("The app must be run with at least an argument for the midpoint character.");
        }

        Print(args[0][0], args.Length > 1 ? args[1][0] : DEFAULT_SEPARATOR_CHARACTER);
    }

    public void Print(char midpoint, char separator)
    {
        var diamond = new Diamond(midpoint, separator);
        foreach (var s in diamond.Data)
        {
            Console.WriteLine(s);
        }
    }
}