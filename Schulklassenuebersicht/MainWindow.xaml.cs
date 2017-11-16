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

    public partial class MainWindow : Window
        
    {
        Fachkonzept fachkonzept = new Fachkonzept();
        public MainWindow()
        {
            InitializeComponent();
            LstBxVwStudent.DisplayMemberPath = "ID";
            LstBxVwStudent.DisplayMemberPath = "Name";
            LstBxVwStudent.ItemsSource = fachkonzept.GetAllStudents().DefaultView;

            LstBxVwSchoolClasses.DisplayMemberPath = "ID";
            LstBxVwSchoolClasses.DisplayMemberPath = "Name";
            LstBxVwSchoolClasses.ItemsSource = fachkonzept.GetAllClasses().DefaultView;


        }


        private void BtnLink_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowAdd wa = new WindowAdd();
            wa.Show();
            wa.TxbStudentName.Text = "Mapfred";
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowAdd wa = new WindowAdd();
            wa.Show();
            
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LstBxVwSchoolClasses_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LstBxVwStudent_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
