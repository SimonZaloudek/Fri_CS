using AdressBook.CommonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.ViewerConsoleApp
{
    internal class Commands
    {
        private string[] commands = { "--input", "--name", "--position", "--main-workplace", "--output" };
        private EmployeeList? el = new EmployeeList();
        public SearchResult SResult { get; set; }

        public Commands() 
        {
        }

        public void Execute(string command, string parameter) 
        {
            if (!commands.Contains(command))
            {
                Console.WriteLine("invalid command..");
            }
            else 
            {
                switch (command)
                {
                    case "--input":
                        InputCommand(parameter);
                        break;
                    case "--name":
                        NameCommand(parameter);
                        break;
                    case "--position":
                        PositionCommand(parameter);
                        break;
                    case "--main-workplace":
                        MainWorkplaceCommand(parameter);
                        break;
                    default: OutputCommand(parameter); break;
                }
            }
        }

        public string[] getCommands() 
        {
            return commands;
        }

        private void InputCommand(string parameter)
        {
            el = el.LoadFromJson(new FileInfo(parameter));
        }

        private void NameCommand(string parameter)
        {
            SResult = el.Search(null, null, parameter);
        }

        private void PositionCommand(string parameter)
        {
            SResult = el.Search(null, parameter, null);
        }

        private void MainWorkplaceCommand(string parameter)
        {
            SResult = el.Search(parameter, null, null);
        }

        private void OutputCommand(string parameter)
        {
            SResult.SaveToCsv(new FileInfo("emps.csv"));
        }
    }
}
