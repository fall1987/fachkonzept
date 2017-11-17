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
        public bool isStudent = false;
        string msgText;
        Fachkonzept fachkonzept = new Fachkonzept();
        public WindowAdd()
        {
            InitializeComponent();
            if (isStudent)
            {
                msgText = "Schüler erfolgreich angelegt";
            }
            else
            {
                msgText = "Klasse erfolgreich angelegt";
                LblName.Content = "Name der Klasse";
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
            MessageBox.Show(msgText);
            TxbStudentName.Text = "";
            }
            else
            {
                fachkonzept.AddSchoolClass(TxbStudentName.Text);
                MessageBox.Show(msgText);
                TxbStudentName.Text = "";
            }
        }
    }
}
