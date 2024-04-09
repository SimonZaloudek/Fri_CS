using AdressBook.CommonLibrary;
using System.Linq;
using System.Runtime.CompilerServices;

public class Viewer 
{
    readonly string[] commandList = { "input", "name", "position", "main-workplace", "output", "exit" };
    private SearchResult searchResult;
    private EmployeeList? empList = new();
    private string? name = null;
    private string? position = null;
    private string? mainWorkplace = null;
    private string? csvPath = null;

    public Viewer()
    {
        while (true)
        { 
            Console.WriteLine("Welcome to FRI employee database...");
            foreach (string com in commandList) 
            {
                Console.Write("--" + com + ", ");
            }
            Console.WriteLine();

            Console.Write("Enter command: ");
            string? input = Console.ReadLine();
            if (input == "--exit" || input == null || input == "") 
            {
                break;
            }

            int startQot = 0;
            int endQot = 0;

            if (input.Contains("\""))
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == '\"' && startQot == 0)
                    {
                        startQot = i + 1;
                    }
                    if (input[i] == '\"' && startQot != i)
                    {
                        endQot = i;
                    }
                }
                mainWorkplace = input.Substring(startQot, endQot - startQot);
                input = input.Remove(startQot, endQot - startQot + 1);
            }

            string[] inputSplit = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (inputSplit.Length % 2 != 0 || !inputSplit[inputSplit.Length % 2].StartsWith("--")) 
            {
                Console.WriteLine("Invalid command format! Please write \"--command parameter\"");
                continue;
            }
            for (int i = 0; i < inputSplit.Length; i += 2) 
            {
                Execute(inputSplit[i], inputSplit[i + 1]);
            }
            searchResult = empList.Search(mainWorkplace, position, name);
            searchResult.WriteToConsole();
            if (csvPath != null) 
            {
                searchResult.SaveToCsv(new FileInfo(csvPath));
            }
            mainWorkplace = null;
        }
    }

    private void Execute(string command, string? parameter)
    {
        switch (command)
        {
            case "--input":
                empList = empList.LoadFromJson(new FileInfo(parameter));
                break;
            case "--name":
                name = parameter;
                break;
            case "--position":
                position = parameter;
                break;
            case "--main-workplace":
                break;
            case "--output":
                csvPath = parameter;
                break;
            default:
                Console.WriteLine("Unknown command: " + command);
                break;
        }
    }

    public static void Main(string[] args) 
    {
        new Viewer();
    }


}
