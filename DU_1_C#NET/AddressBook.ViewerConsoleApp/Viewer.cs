using AdressBook.CommonLibrary;
using System.Linq;

public class Viewer 
{
    readonly string[] commands = { "input", "name", "position", "main-workplace", "output", "exit" };
    private SearchResult searchResult;
    private EmployeeList empList;

    public Viewer()
    {
        while (true)
        {
            Console.WriteLine("Welcome to FRI employee database...");
            foreach (string com in commands) 
            {
                Console.Write("--" + com + ", ");
            }
            Console.WriteLine();

            Console.Write("Enter command: ");
            string? input = Console.ReadLine();
            if (input == "--exit") 
            {
                break;
            }


            string[] words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Process the commands (every odd-indexed word)
            for (int i = 0; i < words.Length; i += 2)
            {
                string? command = words[i];
                string parameter = (i + 1 < words.Length) ? words[i + 1] : null;

                // Remove quotes if present
                if (!string.IsNullOrEmpty(parameter) && parameter.StartsWith("\"") && parameter.EndsWith("\""))
                {
                    parameter = parameter.Substring(1, parameter.Length - 2);
                }

                Execute(command, parameter);
            }
            Console.WriteLine();
        }

    }

    static void Execute(string command, string? parameter)
    {
        switch (command)
        {
            case "--input":
                empList = empList.LoadFromJson(new FileInfo(parameter));
                break;
            case "--name":
                Console.WriteLine(parameter);
                break;
            case "--position":
                Console.WriteLine(parameter);
                break;
            case "--main-workplace":
                Console.WriteLine(parameter);
                break;
            case "--output":
                Console.WriteLine(parameter);
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
