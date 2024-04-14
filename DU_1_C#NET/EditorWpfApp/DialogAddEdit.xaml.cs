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
        private Employee? _employee;
        private MainWindow _mainWindow;
        private bool edit = true;

        public DialogAddEdit(MainWindow mw, Employee? emp = null)
        {
            InitializeComponent();
            _mainWindow = mw;
            
            if (emp != null && _mainWindow != null && _mainWindow.EmployeeList != null) 
            {
                _employee = emp;
                _mainWindow.EmployeeList.Remove(emp);
                _mainWindow.empListView.Items.Remove(emp);
                FillTextBox();
            }
        }

        private void FillTextBox()
        {
            if (_employee != null) { 
                empTB.Text = _employee.Name;
                posTB.Text = _employee.Position;
                phoneTB.Text = _employee.Phone;
                mailTB.Text = _employee.Email;
                roomTB.Text = _employee.Room;
                mainWTB.Text = _employee.MainWorkplace;
                workTB.Text = _employee.Workplace;
            }
        }

        private void okButtonClick(object sender, RoutedEventArgs e)
        {
            if (_employee != null && _mainWindow != null && _mainWindow.EmployeeList != null) {
                _employee.Name = empTB.Text;
                _employee.Position = posTB.Text;
                _employee.Phone = phoneTB.Text;
                _employee.Email = mailTB.Text;
                _employee.Room= roomTB.Text;
                _employee.MainWorkplace = mainWTB.Text;
                _employee.Workplace = workTB.Text;


                _mainWindow.empListView.Items.Add(_employee);
                _mainWindow.EmployeeList.Add(_employee);
            }
            this.Close();
        }

        private void cancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
