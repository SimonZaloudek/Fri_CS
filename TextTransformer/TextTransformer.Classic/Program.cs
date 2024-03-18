using Figgle;

if (args.Length == 0 || args[0] == "--help")
{
    Console.WriteLine("Description:");
    Console.WriteLine("  Display text to output.");
    Console.WriteLine();
    Console.WriteLine("Usage:");
    Console.WriteLine("  TextTransformer.Classic <text> [--uppercase] [--add-spaces <number>]");
    Console.WriteLine();
    Console.WriteLine("Arguments:");
    Console.WriteLine("  <text>        Input text.");
    Console.WriteLine("  --uppercase   Change the letters to uppercase.");
    Console.WriteLine("  --add-spaces <number>  Add spaces between words.");
    Console.WriteLine("  --help  Show help and usage information.");
    return;
}

string text = args[0];
bool uppercase = false;
int addSpaces = 0;


if (args.Length > 1)
{
    uppercase = Array.IndexOf(args, "--uppercase") > 0;

    int index = Array.IndexOf(args, "--add-spaces");
    if (index > 0 && index + 1 < args.Length)
    {
        int.TryParse(args[index + 1], out addSpaces);
    }
}

DisplayToOutput(text, uppercase, addSpaces);

static void DisplayToOutput(string text, bool uppercase, int addSpaces)
{
    if (uppercase)
        text = text.ToUpper();

    if (addSpaces > 0)
    {
        var newSpaces = new string(' ', addSpaces);
        text = text.Replace(" ", newSpaces);
    }

    Console.WriteLine(FiggleFonts.Slant.Render(text));
}