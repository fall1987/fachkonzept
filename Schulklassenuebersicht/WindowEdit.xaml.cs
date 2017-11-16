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

    public partial class WindowEdit : Window
    {
        Fachkonzept fachkonzept = new Fachkonzept();
        public WindowEdit()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            fachkonzept.ChangeStudent(Convert.ToInt16(StudentID.Content), TxbStudentName.Text, 2);
            MessageBox.Show("Schüler erfolgreich bearbeitet");
            this.Close();
        }

        private void BtnAbort_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
