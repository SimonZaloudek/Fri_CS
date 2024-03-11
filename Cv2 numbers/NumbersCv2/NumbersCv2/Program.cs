class Program 
{

    string[] text = File.ReadAllLines("numbers.txt");
    int[] textCisla;

    static void Main()
    {
        new Program();
    }

    public Program()
    {
        textCisla = new int[text.Length];
        for (int i = 0; i < text.Length; i++) 
        {
            textCisla[i] = int.Parse(text[i]); 
        }

        //1.0
        Console.WriteLine("Prvý prvok: " + text[0]);
        Console.WriteLine("Posledny prvok: " + text[^1]);
        Console.WriteLine("Prostredny prvok: " + text[text.Length / 2]);

        Console.WriteLine();

        var span = textCisla.AsSpan();

        //1.1
        Console.WriteLine("//1.1");
        PrintStatistics(span);

        //1.2
        Console.WriteLine("//1.2");
        span[..300].Clear();
        PrintStatistics(span);

        //1.3
        Console.WriteLine("//1.3");
        span[4000..6001].Fill(500);
        PrintStatistics(span);

        //1.4
        Console.WriteLine("//1.4");
        PrintStatistics(span.Slice(5000));
    }

    void PrintStatistics(ReadOnlySpan<int> span) 
    {
        int suma = 0;
        double priemer = 0.0;
        double rozptyl = 0.0;

        //Suma
        foreach (int num in span) 
        {
            suma += num;
        }

        //Priemer
        priemer = suma / (double)span.Length;

        //Rozptyl
        double temp = 0.0;
        foreach (int num in span) 
        {
            temp +=  Math.Pow((num - priemer), 2);
        }
        rozptyl = temp / span.Length;

        Console.WriteLine("Suma: " + suma);
        Console.WriteLine("Priemer: " + priemer);
        Console.WriteLine("Rozptyl: " + rozptyl);

        Console.WriteLine();
    }
}
