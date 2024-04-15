using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.IO.StreamReader;

namespace AdressBook.CommonLibrary;

public class EmployeeList : ObservableCollection<Employee>
{ 
    public static EmployeeList? LoadFromJson(FileInfo jsonFile)
    {
        try
        {
            StreamReader reader = new(jsonFile.FullName);
            string json = reader.ReadToEnd();
            
            EmployeeList? list = JsonSerializer.Deserialize<EmployeeList>(json);

            return list;
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occured: " + ex.Message);
            return null;
        }
    }

    public void SaveToJson(FileInfo jsonFile)
    {
        string json = JsonSerializer.Serialize(this);
        File.WriteAllText(jsonFile.FullName, json);
    }

    public IEnumerable<string> GetPositions() 
    {    
        List<string> positions = new();

        foreach (Employee employee in this)
        {
            if (!positions.Contains(employee.Position))
            {
                positions.Add(employee.Position);
            }
        }
        positions.Sort();
        return positions;
    }
    //Daval som do ChatGPT aby som nasiel riesenie cez Enumerable, ale pouzil som svoje OG.
    public IEnumerable<string> GetMainWorkplaces()
    {
        List<string> mainWorkplaces = new();

        foreach(Employee employee in this) 
        {
            if (employee.MainWorkplace != null)
                if (!mainWorkplaces.Contains(employee.MainWorkplace)) 
                {
                    mainWorkplaces.Add(employee.MainWorkplace);
                }
        }
        
        mainWorkplaces.Sort();
        return mainWorkplaces;
    }

    public SearchResult Search(string? mainWorkplace = null, string? position = null, string? name = null)
    {
        //ChatGPT mi pomohol s rozlisovanim malych/velkych pismen, okrem toho vlastna metoda
        List<Employee> employees = new();
        StringComparison comparison = StringComparison.OrdinalIgnoreCase;

        foreach (Employee emp in this)
        {
            bool matchesMainWorkplace = false;
            bool matchesPosition = false;
            bool matchesName = false;

            if (mainWorkplace == null || (emp.MainWorkplace != null && emp.MainWorkplace.Contains(mainWorkplace, comparison)))
                matchesMainWorkplace = true;
            if (position == null || (emp.Position != null && emp.Position.Contains(position, comparison)))
                matchesPosition = true;
            if (name == null || (emp.Name != null && emp.Name.Contains(name, comparison)))
                matchesName = true;

            if (matchesMainWorkplace && matchesPosition && matchesName)
            {
                employees.Add(emp);
            }
        }

        if (employees.Count == 0)
        {
            return new SearchResult(this.ToArray());
        }

        return new SearchResult(employees.ToArray());
    }
}      
