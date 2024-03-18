// Ak sa použije DragonFruit, je nutné vytvoriť metódu Main s parametrami vo vnútri nejakej inej triedy.
// Na základe dokumentačných komentárov sa automaticky vygeneruje help a argumenty sa dajú zadať aj cez príkazový riadok.

internal class Program
{
    /// <summary>
    /// Display text to output.
    /// </summary>
    /// <param name="argument">Input text.</param>
    /// <param name="uppercase">Change the letters to uppercase.</param>
    /// <param name="addSpaces">Add spaces between words.</param>
    private static void Main(string argument, bool uppercase = false, int addSpaces = 0)
    {
        if (uppercase)
            argument = argument.ToUpper();

        if (addSpaces > 0)
        {
            var newSpaces = new string(' ', addSpaces);
            argument = argument.Replace(" ", newSpaces);
        }

        Console.WriteLine(argument);
    }
}