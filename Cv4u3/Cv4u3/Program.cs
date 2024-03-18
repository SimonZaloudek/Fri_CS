using Figgle;

class Program 
{
    string[] file1;
    string[] file2;
    
    static void Main(string[] args) 
    {
        new Program(args);
    }
    
    public Program(string[] args) 
    {
        Console.ForegroundColor = ConsoleColor.Green;
        if (true) 
        {
            file1 = File.ReadAllLines(args[0]);
            file2 = File.ReadAllLines(args[1]);
        }

        foreach (String line in file1) 
        {
            Console.WriteLine(FiggleFonts.Standard.Render(line));
        }
        Console.WriteLine();
        var Peter = FiggleFonts.Standard;
        foreach (String line in file2) 
        {
            Console.WriteLine(Peter.Render(line));
        }
    }



}
