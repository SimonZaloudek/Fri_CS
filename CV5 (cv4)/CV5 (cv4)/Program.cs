using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV5__cv4_
{
    internal class Program
    {

        public static void Main(string[] agrs)
        {   
            PersonDatabase pd = new PersonDatabase();
            var jano1 = new Person();
            jano1.FirstName = "Jano";
            jano1.LastName = "Starinsky8@gmail.com";
            jano1.Gender = Gender.Male;
            jano1.Birthday = new DateTime(1950, 12, 31);

            var jano2 = new Person("Jan", new DateTime(1488, 9, 11), "Hulak", Gender.Female);
            Console.WriteLine(jano1.FullName);
        }

    }
}
