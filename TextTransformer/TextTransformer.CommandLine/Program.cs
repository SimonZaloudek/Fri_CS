using System.CommandLine;

// Deklarujeme si argumenty s typmi, príkazy a voľby, ktoré chceme spracovávať
var textArgument = new Argument<string>("text", "Input text.");
var uppercaseOption = new Option<bool>(new[] { "-u", "--uppercase" }, () => false, "Change the letters to uppercase.");
var addSpacesOption = new Option<int>(new[] { "-a", "--add-spaces" }, () => 0, "Add spaces between words.");

var rootCommand = new RootCommand("Display text to output.") { textArgument, uppercaseOption, addSpacesOption };
rootCommand.SetHandler(DisplayToOutput, textArgument, uppercaseOption, addSpacesOption);

return rootCommand.Invoke(args);

// V metóde spracujeme argumenty, ktoré nám knižnica rozparsuje:
void DisplayToOutput(string text, bool uppercase, int addSpaces)
{
    if (uppercase)
        text = text.ToUpper();

    if (addSpaces > 0)
    {
        var newSpaces = new string(' ', addSpaces);
        text = text.Replace(" ", newSpaces);
    }

    Console.WriteLine(text);
}
