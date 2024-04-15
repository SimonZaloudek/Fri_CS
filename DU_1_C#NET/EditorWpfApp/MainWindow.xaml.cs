using AdressBook.CommonLibrary;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Threading;

namespace EditorWpfApp
{
    public partial class MainWindow : Window
    {
        readonly DispatcherTimer timer = new();
        private string? fileName;
        private bool wasChanged = false;
        private EmployeeList? _employeeList = new();

        public EmployeeList? EmployeeList { get => _employeeList; set => _employeeList = value; }

        public MainWindow()
        {
            InitializeComponent();

            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();

            editButton.IsEnabled = false;
            deleteButton.IsEnabled = false;
            searchButton.IsEnabled = false;
            editMenuButton.IsEnabled = false;
            deleteMenuButton.IsEnabled = false;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            DialogAddEdit dialogAddEdit = new();
            dialogAddEdit.ShowDialog();
            if (dialogAddEdit.Cancel == false && dialogAddEdit.Employee != null && _employeeList != null) 
            {
                empListView.ItemsSource = null;
                _employeeList.Add(dialogAddEdit.Employee);
                empListView.ItemsSource = _employeeList;

                wasChanged = true;
            }
            dialogAddEdit.Close();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Employee tempEmployee = (Employee)empListView.SelectedItem;
            
            DialogAddEdit dialogAddEdit = new((Employee)empListView.SelectedItem);
            dialogAddEdit.ShowDialog();
            if (dialogAddEdit.Cancel == false && dialogAddEdit.Employee != null && _employeeList != null)
            {      
                
                empListView.SelectedItem = dialogAddEdit.Employee;
                for (int i = 0; i < empListView.Items.Count; i++) 
                {
                    _employeeList[i] = (Employee)empListView.Items[i];
                }
                empListView.ItemsSource = null;
                empListView.ItemsSource = _employeeList;

                if (tempEmployee != dialogAddEdit.Employee)
                    wasChanged = true;
            }
            dialogAddEdit.Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            wasChanged = true;

            List<Employee> itemsForRemoval = new();
            MessageBoxResult result;
            result = MessageBox.Show(this, "Are you sure you want to remove selected employees?..", "Remove employees..", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                foreach (Employee emp in empListView.SelectedItems)
                {
                    itemsForRemoval.Add(emp);
                }
                foreach (Employee emp in itemsForRemoval)
                {
                    _employeeList?.Remove(emp);
                }
                empListView.ItemsSource = null;
                empListView.ItemsSource = _employeeList;
                
            }
            empListView.SelectedItems.Clear();
        }

        private void NewMenuClick(object sender, RoutedEventArgs e)
        {
            if (wasChanged == true)
            {
                MessageBoxResult result;
                result = MessageBox.Show(this, "Database was modified, do you want to save it?..", "Database modified..", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    SaveMenuClick(null, null);
                }
            }
            new MainWindow().Show();
            this.Close();
        }

        private void OpenMenuClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new()
            {
                Title = "Select a .json file",
                Filter = ".json files | *.json"
            };
            bool? opened = fileDialog.ShowDialog();
            if (opened == true)
            {
                fileName = fileDialog.FileName;

                if (_employeeList != null)
                    _employeeList = EmployeeList.LoadFromJson(new FileInfo(fileName));
                empListView.ItemsSource = _employeeList;
            }
        }

        private void SaveMenuClick(object? sender, RoutedEventArgs? e)
        {
            if (empListView.Items.Count < 1)
            {
                _ = MessageBox.Show(this, "No employees in the database", "Error..", MessageBoxButton.OK);
            }
            else
            {
                SaveFileDialog saveDialog = new()
                {
                    Title = "Save to JSON:",
                    Filter = ".json files | *.json",

                    FileName = "Document",
                    DefaultExt = ".json"
                };

                bool? result = saveDialog.ShowDialog();
                if (result == true && _employeeList != null)
                {
                    _employeeList.SaveToJson(new FileInfo(saveDialog.FileName));
                }
            }
        }

        private void ExitMenuClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (_employeeList != null)
                _ = new SearchWindow(_employeeList);
        }

        private void AboutMenuClick(object sender, RoutedEventArgs e)
        {
            new AboutDialog().Show();
        }

        private void Timer_Tick(object? sender, EventArgs e) 
        {
            if (empListView.SelectedItems.Count > 0)
            {
                deleteButton.IsEnabled = true;
                editButton.IsEnabled = true;
                editMenuButton.IsEnabled = true;
                deleteMenuButton.IsEnabled = true;
            }
            else 
            {
                deleteButton.IsEnabled = false;
                editButton.IsEnabled = false;
                editMenuButton.IsEnabled = false;
                deleteMenuButton.IsEnabled = false;
            }

            if (empListView.Items.Count > 0)
            {
                searchButton.IsEnabled = true;
            }
            else 
            {
                searchButton.IsEnabled = false;
            }
            totalEmployeesText.Text = "Total employees: " + empListView.Items.Count;
        }


    }
}  