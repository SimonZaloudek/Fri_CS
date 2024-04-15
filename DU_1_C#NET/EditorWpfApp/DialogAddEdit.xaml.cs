using AdressBook.CommonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EditorWpfApp
{

    public partial class DialogAddEdit : Window
    {
        public Employee? Employee { get; set; }
        public bool Cancel { get; set; }

        public DialogAddEdit(Employee? emp = null)
        {
            InitializeComponent();
            Cancel = false;
            
            if (emp != null) 
            {
                Employee = emp;
                FillTextBox();
            }
        }

        private void FillTextBox()
        {
            if (Employee != null) { 
                empTB.Text = Employee.Name;
                posTB.Text = Employee.Position;
                phoneTB.Text = Employee.Phone;
                mailTB.Text = Employee.Email;
                roomTB.Text = Employee.Room;
                mainWTB.Text = Employee.MainWorkplace;
                workTB.Text = Employee.Workplace;
            }
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            if (Employee != null)
            {
                Employee.Name = empTB.Text;
                Employee.Position = posTB.Text;
                Employee.Phone = phoneTB.Text;
                Employee.Email = mailTB.Text;
                Employee.Room = roomTB.Text;
                Employee.MainWorkplace = mainWTB.Text;
                Employee.Workplace = workTB.Text;
            }
            else 
            {
                if (empTB.Text == "" && posTB.Text == "" && phoneTB.Text == "" && roomTB.Text == "" && mainWTB.Text == "" && workTB.Text == "" && mailTB.Text == "")
                    Employee = null;
                else
                    Employee = new Employee(empTB.Text, posTB.Text, mailTB.Text, phoneTB.Text, roomTB.Text, mainWTB.Text, workTB.Text);
            }
            DialogResult = true;
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            Cancel = true;
            DialogResult = true;
        }

    }
}
