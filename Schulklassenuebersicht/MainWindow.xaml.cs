using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;

namespace Schulklassenuebersicht
{
    public partial class MainWindow : Window       
    {
        Fachkonzept fachkonzept = new Fachkonzept();
        bool isStudent = false;
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
                UpdateListBxViews();
            } catch (Exception es)
            {
               MessageBox.Show(es.StackTrace);
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
                if (((DataRowView)(LstBxVwStudent.SelectedItem)).Row.ItemArray[0].ToString() != "")
                {
                    we.StudentID.Content = ((DataRowView)(LstBxVwStudent.SelectedItem)).Row.ItemArray[0].ToString();
                    we.TxbClassID.Text = ((DataRowView)(LstBxVwStudent.SelectedItem)).Row.ItemArray[2].ToString();
                    we.TxbClassName.Text = we.TxbClassID.Text != "" ? fachkonzept.GetClassByID(Int32.Parse(we.TxbClassID.Text)).Rows[0][1].ToString() : "";
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
            WindowAdd wa = new WindowAdd(isStudent);
            wa.Show();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            string msg;
            if (isStudent)
            {
                fachkonzept.RemoveStudent(Convert.ToInt16(((DataRowView)(LstBxVwStudent.SelectedItem)).Row.ItemArray[0]));
                msg = "Schüler gelöscht.";
            } else
            {
                fachkonzept.RemoveClass(Convert.ToInt16(((DataRowView)(LstBxVwSchoolClasses.SelectedItem)).Row.ItemArray[0]));
                msg = "Klasse gelöscht";
            }            
            UpdateListBxViews();
            MessageBox.Show(msg);
        }

        private void LstBxVwSchoolClasses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListView).SelectedItem != null && LstBxVwStudent.SelectedItems.Count == 0)
            {
                LstBxVwStudent.DisplayMemberPath = "ID";
                LstBxVwStudent.DisplayMemberPath = "Name";
                LstBxVwStudent.ItemsSource = fachkonzept.GetStudentsByClass(Convert.ToInt32(((DataRowView)(LstBxVwSchoolClasses.SelectedItem)).Row.ItemArray[0].ToString())).DefaultView;
            }
        }
        
        internal void UpdateListBxViews()
        {
            LstBxVwStudent.DisplayMemberPath = "ID";
            LstBxVwStudent.DisplayMemberPath = "Name";
            LstBxVwStudent.ItemsSource = fachkonzept.GetAllStudents().DefaultView;

            LstBxVwSchoolClasses.DisplayMemberPath = "ID";
            LstBxVwSchoolClasses.DisplayMemberPath = "Name";
            LstBxVwSchoolClasses.ItemsSource = fachkonzept.GetAllClasses().DefaultView;
        }

        private void ListView_GotFocus(object sender, RoutedEventArgs e)
        {
            switch ((sender as ListView).Name)
            {
                case "LstBxVwStudent":
                    BtnAdd.Content = "Schüler hinzufügen";
                    BtnDelete.Content = "Schüler löschen";
                    isStudent = true;
                    BtnAdd.IsEnabled = true;
                    BtnDelete.IsEnabled = true;
                    break;
                case "LstBxVwSchoolClasses":
                    BtnAdd.Content = "Klasse hinzufügen";
                    BtnDelete.Content = "Klasse löschen";
                    isStudent = false;
                    BtnAdd.IsEnabled = true;
                    BtnDelete.IsEnabled = true;
                    break;
            }
        }

        private void ListView_LostFocus(object sender, RoutedEventArgs e)
        {
            switch ((sender as ListView).Name)
            {
                case "LstBxVwStudent":
                    BtnAdd.Content = "Schüler hinzufügen";
                    isStudent = true;
                    BtnAdd.IsEnabled = true;
                    break;
                case "LstBxVwSchoolClasses":
                    BtnAdd.Content = "Klasse hinzufügen";
                    isStudent = false;
                    BtnAdd.IsEnabled = true;
                    break;
            }        
        }

        private void BtnStudentWithoutClass_Click(object sender, RoutedEventArgs e)
        {
            LstBxVwStudent.DisplayMemberPath = "ID";
            LstBxVwStudent.DisplayMemberPath = "Name";
            LstBxVwStudent.ItemsSource = fachkonzept.GetAllStudentsWithoutClass().DefaultView;
        }
    }
}
