using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EditorWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            editButton.IsEnabled = false;
            deleteButton.IsEnabled = false;
            searchButton.IsEnabled = false;
            editMenuButton.IsEnabled = false;
            deleteMenuButton.IsEnabled = false;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            addButton.IsEnabled = false;
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            editButton.IsEnabled = false;
        }

        private void newMenuClick(object sender, RoutedEventArgs e)
        {

        }

        private void openMenuClick(object sender, RoutedEventArgs e) 
        {
        
        }

        private void saveMenuClick(object sender, RoutedEventArgs e)
        {

        }

        private void exitMenuClick(object sender, RoutedEventArgs e)
        {

        }

        private void helpMenuClick(object sender, RoutedEventArgs e)
        {

        }

        private void fileMenuClick(object sender, RoutedEventArgs e)
        {

        }
        private void deleteButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}