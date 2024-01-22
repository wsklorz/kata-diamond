namespace KataDiamond;

public static class Alphabet
{
    public static readonly char[] Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

    public static int PositionOf(char letter) => (letter % 32) - 1;
}