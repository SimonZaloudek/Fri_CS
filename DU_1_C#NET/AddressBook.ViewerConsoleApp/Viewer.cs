using AddressBook.ViewerConsoleApp;
using AdressBook.CommonLibrary;
using System.Linq;

public class Viewer 
{
    public Viewer()
    {
        Commands commands = new Commands();
        string? input;

        Console.WriteLine("Welcome to FRI database...");
        Console.Write("List of all commands: ");
        for (int i = 0; i < commands.getCommands().Length; i++) 
        {
            Console.Write($"{commands.getCommands()[i]}" + ", ");
        }
        Console.WriteLine(" ,--exit");

        Console.WriteLine();
        input = Console.ReadLine();
        if (input != null)
        {
            string[] wholeInput = input.Split(" ");
            for (int i = 0; i < wholeInput.Length; i++)
            {
                foreach (string command in commands.getCommands()) 
                {
                    if (wholeInput[i] == command)
                    {
                        commands.Execute(command, wholeInput[i + 1]);
                    }
                }
            }
        }
        commands.SResult.WriteToConsole();
    }

    public static void Main(string[] args) 
    {
        new Viewer();
    }


}
