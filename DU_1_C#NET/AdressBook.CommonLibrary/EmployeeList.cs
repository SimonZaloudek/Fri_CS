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
    public EmployeeList? LoadFromJson(FileInfo jsonFile)
    {
        StreamReader reader = new(jsonFile.FullName);
        string json = reader.ReadToEnd();

        EmployeeList? list = JsonSerializer.Deserialize<EmployeeList>(json);
        return list;
    }

    public void SaveToJson(FileInfo jsonFile)
    {
        string json = JsonSerializer.Serialize(this);
        File.WriteAllText(jsonFile.FullName, json);
    }

    public IEnumerable<string> GetPositions() 
    {
        //return this.Select(Employee => Employee.Position).Distinct();    
        List<string> positions = new List<string>();

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

    public IEnumerable<string> GetMainWorkplaces()
    {
        List<string> mainWorkplaces = new List<string>();

        foreach(Employee employee in this) 
        {
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
        List<Employee> employees = new List<Employee>();
        StringComparison comparison = StringComparison.OrdinalIgnoreCase;

        foreach (Employee emp in this)
        {
            bool matchesMainWorkplace = false;
            bool matchesPosition = false;
            bool matchesName = false;

            if (mainWorkplace == null || (emp.MainWorkplace != null && emp.MainWorkplace.IndexOf(mainWorkplace, comparison) >= 0))
                matchesMainWorkplace = true;
            if (position == null || (emp.Position != null && emp.Position.IndexOf(position, comparison) >= 0))
                matchesPosition = true;
            if (name == null || (emp.Name != null && emp.Name.IndexOf(name, comparison) >= 0))
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
