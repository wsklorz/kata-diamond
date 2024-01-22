namespace KataDiamond;

public static class Alphabet
{
    private static readonly string String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public static readonly char[] Letters = String.ToCharArray();

    public static int PositionOf(char letter) => String.IndexOf(letter);
}