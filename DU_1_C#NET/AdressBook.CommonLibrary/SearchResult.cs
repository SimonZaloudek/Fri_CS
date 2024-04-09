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
        var csv = new StringBuilder();

        foreach (var employee in Employees) 
        {
            csv.AppendLine("Name" + delimiter + employee.Name);
            csv.AppendLine("MainWorkplace" + delimiter + employee.MainWorkplace);
            csv.AppendLine("Workplace" + delimiter + employee.Workplace);
            csv.AppendLine("Room" + delimiter + employee.Room);
            csv.AppendLine("Phone" + delimiter + employee.Phone);
            csv.AppendLine("Email" + delimiter + employee.Email);
            csv.AppendLine("Position" + delimiter + employee.Position);
        }

        File.AppendAllText(csvFile.FullName, csv.ToString());
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
