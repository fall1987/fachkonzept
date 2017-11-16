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
        Fachkonzept fachkonzept = new Fachkonzept();
        public WindowAdd()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            fachkonzept.AddStudent(TxbStudentName.Text);
            MessageBox.Show("Schüler erfolgreich hinzugefügt");
            TxbStudentName.Text = "";
        }
    }
}
