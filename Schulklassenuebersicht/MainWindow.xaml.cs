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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Schulklassenuebersicht
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Datenerhaltung db = new Datenerhaltung();
            
        }

        private void LstBxSchollClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void BtnLink_Click(object sender, RoutedEventArgs e)
        {
            LstBxStudent.Items.Add("Student 1");
        }

        private void LstBxStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (true/*Student in Class*/)
            {
                BtnLink.Content = "Entfernen";
            }
        }

        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowAdd wa = new WindowAdd();
            wa.Show();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
 
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
