using System;

using System.Windows;

namespace Schulklassenuebersicht
{

    public partial class WindowEdit : Window
    {
        Fachkonzept fachkonzept = new Fachkonzept();
        MainWindow mw = App.Current.MainWindow as MainWindow;
        public WindowEdit()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            fachkonzept.ChangeStudent(Convert.ToInt16(StudentID.Content), TxbStudentName.Text, 0);
            MessageBox.Show("Schüler erfolgreich bearbeitet.");
            mw.UpdateListBxViews();
            this.Close();
        }

        private void BtnAbort_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnDelRelation_Click(object sender, RoutedEventArgs e)
        {
            fachkonzept.RemoveClassFromStudent( Int32.Parse(TxbClassID.Text), Int32.Parse(StudentID.Content.ToString()));
            TxbClassName.Text = "";
        }
    }
}
