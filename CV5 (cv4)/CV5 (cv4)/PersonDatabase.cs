using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV5__cv4_
{
    public class PersonDatabase
    {
        List<Person> _people = new();

        public PersonDatabase()
        {

        }
        public void Add(Person person) 
        {
            _people.Add(person);
        }
        public void Add(params Person[] people)
        {
        }

        public static List<Person> Find(string text, Gender? Gender = null) 
        {
            return null;
        }

        public void PrintToConsole() 
        {
            foreach (Person person in _people) 
            {
                Console.WriteLine(person.ToString());
            }
        }

        public void Remove(Person person)
        {
        
        } 
    }
}
