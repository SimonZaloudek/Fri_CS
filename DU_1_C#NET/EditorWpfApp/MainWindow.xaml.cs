using AdressBook.CommonLibrary;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Threading;

namespace EditorWpfApp
{
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        private string path;
        private string fileName;
        private bool sourceLoaded = false;
        private bool wasChanged = false;
        private EmployeeList? _employeeList = new();
        private SearchResult? _searchResult;

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
            new DialogAddEdit(mw: this).Show();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            new DialogAddEdit(this, (Employee)empListView.SelectedItem).Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            wasChanged = true;

            List<Employee> itemsToRemove = new List<Employee>();
            MessageBoxResult result;
            result = MessageBox.Show(this, "Are you sure you want to remove selected employees?..", "Remove employees..", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                foreach (Employee emp in empListView.SelectedItems)
                {
                    itemsToRemove.Add(emp);
                }
                //Priamo mazat neslo, preto takyto blby "obchvat" xd
                foreach (Employee emp in itemsToRemove)
                {
                    _employeeList.Remove(emp);
                }
                empListView.ItemsSource = null;
                empListView.ItemsSource = _employeeList;
            }
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
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Select a .json file";
            fileDialog.Filter = ".json files | *.json";
            bool? opened = fileDialog.ShowDialog();
            if (opened == true)
            {
                path = fileDialog.SafeFileName;
                fileName = fileDialog.FileName;

                if (_employeeList != null)
                    _employeeList = _employeeList.LoadFromJson(new FileInfo(path));
                sourceLoaded = true;
                empListView.ItemsSource = _employeeList;

                searchButton.IsEnabled = true;
            }
        }

        private void SaveMenuClick(object sender, RoutedEventArgs e)
        {
            if (sourceLoaded == false)
            {
                MessageBoxResult result;
                result = MessageBox.Show(this, "No source file loaded..", "Error..", MessageBoxButton.OK);
            }
            else
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Title = "Save to CSV:";
                saveDialog.Filter = ".csv files | *.csv";

                saveDialog.FileName = "Document";
                saveDialog.DefaultExt = ".csv";

                bool? result = saveDialog.ShowDialog();
                if (result == true)
                {
                    if (_searchResult != null)
                        _searchResult.SaveToCsv(new FileInfo(saveDialog.FileName));
                }
            }
        }

        private void ExitMenuClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            new searchWindow(_employeeList);
            this.Close();
        }

        private void AboutMenuClick(object sender, RoutedEventArgs e)
        {
            new AboutDialog().Show();
        }

        private void Timer_Tick(object sender, EventArgs e) 
        {
            if (empListView.SelectedItems.Count > 0)
            {
                deleteButton.IsEnabled = true;
                editButton.IsEnabled = true;
                editMenuButton.IsEnabled = true;
                deleteMenuButton.IsEnabled = true;
            }
            totalEmployeesText.Text = "Total employees: " + empListView.Items.Count;
        }


    }
}  