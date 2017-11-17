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
using System.Windows.Shapes;

namespace Schulklassenuebersicht
{
    public partial class WindowAdd : Window
    {
        public bool isStudent;
        string msgText;
        Fachkonzept fachkonzept = new Fachkonzept();
        MainWindow mw = App.Current.MainWindow as MainWindow;
        public WindowAdd(bool isStudent)
        {
            this.isStudent = isStudent;
            InitializeComponent();
            if (isStudent)
            {
                LblName.Content = "Name des Schülers";
                msgText = "Schüler erfolgreich angelegt.";
            }
            else
            {                
                LblName.Content = "Name der Klasse";
                msgText = "Klasse erfolgreich angelegt.";
            }

            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {   
            this.Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (isStudent)
            {
                fachkonzept.AddStudent(TxbStudentName.Text);
                mw.UpdateListBxViews();
                MessageBox.Show(msgText);
                TxbStudentName.Text = "";
            }
            else
            {
                fachkonzept.AddSchoolClass(TxbStudentName.Text);
                MessageBox.Show(msgText);
                TxbStudentName.Text = "";
            }

            mw.UpdateListBxViews();
        }
    }
}
