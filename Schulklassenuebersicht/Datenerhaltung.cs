using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows;
using System.IO;

namespace Schulklassenuebersicht
{
    class Datenerhaltung
    {
        public SQLiteConnection con = new SQLiteConnection(@"data source=.\Schulklassenuebersicht\Datenhaltung.db");

        public void test()
        {
            string path = Path.GetTempPath();
            try
            {
                FileStream fs = File.Open(path, FileMode.Open);
            }
            catch
            {
                MessageBox.Show("Datenbank nicht da", "Database", MessageBoxButton.OK);
            }



        }
    }
}
