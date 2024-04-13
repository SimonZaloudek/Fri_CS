using AdressBook.CommonLibrary;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// <summary>
    /// Interaction logic for searchWindow.xaml
    /// </summary>
    public partial class searchWindow : Window
    {
        private string path;
        private string fileName;
        private bool sourceLoaded = false;
        private EmployeeList? _employeeList;
        private SearchResult? _searchResult;

        public searchWindow(EmployeeList list)
        {
            InitializeComponent();
            this.Show();

            _employeeList =list;
            sourceLoaded = true;
            sourceFileLoaded();
        }

        private void sourceFileLoaded()
        {
            if (_employeeList != null)
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
                MessageBoxResult result;
                result = MessageBox.Show(this, "No source file loaded..", "Error..", MessageBoxButton.OK);
            }
            else
            {
                string? workplace = null;
                string? position = null;

                if (WorkplaceCB.SelectedValue != null)
                {
                    workplace = WorkplaceCB.SelectedValue.ToString();
                }
                if (FunctionsCB.SelectedValue != null)
                {
                    position = FunctionsCB.SelectedValue.ToString();
                }

                if (_employeeList != null)
                    _searchResult = _employeeList.Search(mainWorkplace: workplace, position: position, NameTextBox.Text);

                if (_searchResult != null)
                    empListView.ItemsSource = _searchResult.Employees;

                if (_searchResult != null)
                    empFound.Text = "Employees found: " + _searchResult.Employees.Count();
            }
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            new searchWindow(_employeeList).Show();
            this.Close();
        }

        private void exportCSV_Click(object sender, RoutedEventArgs e)
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


    }
}
