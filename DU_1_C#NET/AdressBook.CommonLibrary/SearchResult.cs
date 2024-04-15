using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AdressBook.CommonLibrary;

public class SearchResult
{
    public Employee[] Employees { get; }


    public SearchResult(Employee[] employees) 
    {
        Employees = employees;
    }

    public void SaveToCsv(FileInfo csvFile, string delimiter = "\t") 
    {
    try
    {
        var csvSubor = new StringBuilder();

        foreach (var employee in Employees) 
        {
            csvSubor.AppendLine("Name" + delimiter + employee.Name);
            csvSubor.AppendLine("MainWorkplace" + delimiter + employee.MainWorkplace);
            csvSubor.AppendLine("Workplace" + delimiter + employee.Workplace);
            csvSubor.AppendLine("Room" + delimiter + employee.Room);
            csvSubor.AppendLine("Phone" + delimiter + employee.Phone);
            csvSubor.AppendLine("Email" + delimiter + employee.Email);
            csvSubor.AppendLine("Position" + delimiter + employee.Position);
        }

        File.AppendAllText(csvFile.FullName, csvSubor.ToString());
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred: " + ex.Message);
    }
}

    public void WriteToConsole() 
    {
        Console.WriteLine();
        int index = 1;
        string text = "";
        foreach (var employee in Employees)
        {
            text += "[" + index + "] " + employee.Name + "\n";
            text += "Pracovisko: " + employee.MainWorkplace + "\n";
            text += "Miestnost: " + employee.Room + "\n";
            text += "Telefon: " + employee.Phone + "\n";
            text += "E-mail: " + employee.Email + "\n";
            text += "Funkcia: " + employee.Position + "\n";
            text += "\n";
            index++;
        }
        Console.WriteLine(text);
        Console.WriteLine();
    }
}
