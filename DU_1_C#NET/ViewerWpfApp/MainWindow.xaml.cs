using AdressBook.CommonLibrary;
using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ViewerWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string path;
        private string fileName;
        private bool sourceLoaded = false;
        private EmployeeList? _employeeList = new();
        private SearchResult? _searchResult;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Select a .json file";
            fileDialog.Filter = ".json files | *.json";
            bool? opened = fileDialog.ShowDialog();
            if (opened == true)
            {
                path = fileDialog.SafeFileName;
                fileName = fileDialog.FileName;

                _employeeList = _employeeList.LoadFromJson(new FileInfo(path));
                sourceLoaded = true;
                sourceFileLoaded();
            }
        }

        private void sourceFileLoaded() 
        {
            foreach (string function in _employeeList.GetPositions()) 
            {
                FunctionsCB.Items.Add(function);
            }

            foreach (string workplace in _employeeList.GetMainWorkplaces()) 
            {
                WorkplaceCB.Items.Add(workplace);
            }
        }

        private void employeeSearch_Click(object sender, RoutedEventArgs e)
        {
            if (sourceLoaded == false)
            {
                employeeList.Text = "No source file loaded..";
            }
            else 
            {
                _searchResult = _employeeList.Search(mainWorkplace: WorkplaceCB.SelectedValue.ToString(), position: FunctionsCB.SelectedValue.ToString(), null);
                foreach (Employee emp in _searchResult.Employees) 
                {
                    employeeList.Text += emp.Name + "\n";
                } 
            }
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }
    }
}