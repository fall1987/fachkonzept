using System.Windows;

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
