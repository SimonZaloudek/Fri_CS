class Program {

    public static void Main(String[] args)
    {
        int counter = 1;
        foreach (String arg in args) 
        { 
            Console.WriteLine(counter + ". " + arg);
            counter++;
        }

        Console.WriteLine();    

        foreach (String arg in args)
        {
            Console.WriteLine(arg.Length + ". " + arg);
        }


    }
}