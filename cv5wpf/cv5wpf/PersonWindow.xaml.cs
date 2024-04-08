using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace cv5wpf
{
    /// <summary>
    /// Interaction logic for PersonWindow.xaml
    /// </summary>
    public partial class PersonWindow : Window
    {
        private MainWindow _mw;

        public PersonWindow(MainWindow mw)
        {
            InitializeComponent();
            _mw = mw;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string age = "unknown";
            if (BirthdateDatePicker.Text != "") 
            {
                age = (DateTime.Now.Year - BirthdateDatePicker.DisplayDate.Year).ToString();
                   
            }
            _mw.lb1.Items.Add(FirstNameTextBox.Text + " " + LastNameTextBox.Text + " (" + age + ")");
            this.Close();
        }
    }
}
