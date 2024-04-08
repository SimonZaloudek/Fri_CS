using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressBook.CommonLibrary
{
    internal class Employee : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public string Name { get; set; }
        public string Position { get; set; }
        public string? Phone { get; set; }
        public string Email { get; set; }
        public string? Room { get; set; }
        public string? MainWorkplace { get; set; }
        public string? Workplace { get; set; }

        public Employee()
        {
        
        
        }
    }
}
