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
using System.Data;

namespace Schulklassenuebersicht
{

    public partial class MainWindow : Window
        
    {
        Fachkonzept fachkonzept = new Fachkonzept();
        public MainWindow()
        {
            InitializeComponent();
            UpdateListBxViews();
            
        }

        private void BtnLink_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string studentName = (LstBxVwStudent.SelectedItem as DataRowView).Row.ItemArray[1].ToString();
                int studenId = Int16.Parse((LstBxVwStudent.SelectedItem as DataRowView).Row.ItemArray[0].ToString());
                int classId = Int16.Parse((LstBxVwSchoolClasses.SelectedItem as DataRowView).Row.ItemArray[0].ToString());
                fachkonzept.ChangeStudent(studenId, studentName, classId);
            } catch (Exception es)
            {
                Console.WriteLine(es.StackTrace);
            }
            
            
        }

        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            UpdateListBxViews();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowEdit we = new WindowEdit();

            if (LstBxVwStudent.SelectedItems.Count != 0)
            {
                we.TxbStudentName.Text = ((DataRowView)(LstBxVwStudent.SelectedItem)).Row.ItemArray[1].ToString();
                if (((System.Data.DataRowView)(LstBxVwStudent.SelectedItem)).Row.ItemArray[0].ToString() != "")
                {
                    we.StudentID.Content = ((DataRowView)(LstBxVwStudent.SelectedItem)).Row.ItemArray[0].ToString();
                }
                we.Show();
            }
            else
            {
                MessageBox.Show("Schüler auswählen");
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowAdd wa = new WindowAdd();
            wa.Show();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LstBxVwSchoolClasses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListView).SelectedItem != null && LstBxVwStudent.SelectedItems.Count == 0)
            {
                LstBxVwStudent.DisplayMemberPath = "ID";
                LstBxVwStudent.DisplayMemberPath = "Name";
                LstBxVwStudent.ItemsSource = fachkonzept.GetStudentsByClass(Convert.ToInt32(((System.Data.DataRowView)(LstBxVwSchoolClasses.SelectedItem)).Row.ItemArray[0].ToString())).DefaultView;
            }
        }


        private void LstBxVwStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(((System.Data.DataRowView)(LstBxVwStudent.SelectedItem)).Row.ItemArray[0].ToString());
        }

        private void UpdateListBxViews()
        {
            LstBxVwStudent.DisplayMemberPath = "ID";
            LstBxVwStudent.DisplayMemberPath = "Name";
            LstBxVwStudent.ItemsSource = fachkonzept.GetAllStudents().DefaultView;

            LstBxVwSchoolClasses.DisplayMemberPath = "ID";
            LstBxVwSchoolClasses.DisplayMemberPath = "Name";
            LstBxVwSchoolClasses.ItemsSource = fachkonzept.GetAllClasses().DefaultView;
        }
    }
}
