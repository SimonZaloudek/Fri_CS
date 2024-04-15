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
   
    public partial class SearchWindow : Window
    {
        private readonly bool sourceLoaded;
        private readonly EmployeeList? _employeeList;
        private SearchResult? _searchResult;

        public SearchWindow(EmployeeList list)
        {
            InitializeComponent();
            this.Show();

            _employeeList =list;
            sourceLoaded = true;
            SourceFileLoaded();
        }

        private void SourceFileLoaded()
        {
            if (_employeeList != null)
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
        }

        private void EmployeeSearch_Click(object sender, RoutedEventArgs e)
        {
            if (sourceLoaded == false)
            {
                _ = MessageBox.Show(this, "No source file loaded..", "Error..", MessageBoxButton.OK);
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
                    empFound.Text = "Employees found: " + _searchResult.Employees.Length;
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ExportCSV_Click(object sender, RoutedEventArgs e)
        {
            if (sourceLoaded == false)
            {
                _ = MessageBox.Show(this, "No source file loaded..", "Error..", MessageBoxButton.OK);
            }
            else
            {
                SaveFileDialog saveDialog = new()
                {
                    Title = "Save to CSV:",
                    Filter = ".csv files | *.csv",

                    FileName = "Document",
                    DefaultExt = ".csv"
                };

                bool? result = saveDialog.ShowDialog();
                if (result == true)
                {
                    _searchResult?.SaveToCsv(new FileInfo(saveDialog.FileName));
                }
            }
        }


    }
}
