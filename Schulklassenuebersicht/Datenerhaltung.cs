using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows;
using System.IO;
using System.Data;

namespace Schulklassenuebersicht
{
    class Datenerhaltung
    {
     
        /// <summary>
        /// Konstructor
        /// </summary>
        public Datenerhaltung ()
        {
            string path = GetProjectPath();
            if (ExsitsDatabase(path))
            {
                if (!ExsitsTableSchoolClass(path))
                {
                    CreateTableSchoolClass(path);
                }
                if (!ExsitsTableStudent(path))
                {
                    CreateTableStudent(path);
                }
            }
            else
            {
                CreateDatabase(path);
            }
        }   

        #region initialize Class
        private static string GetProjectPath()
        {
            string projectPath = Environment.CurrentDirectory;
            for (int i = 0; i < 2; i++)
            {
                projectPath = System.IO.Path.GetDirectoryName(projectPath);
            }
            return projectPath + @"\";
        }

        private bool ExsitsDatabase(string path)
        {
            
            if (File.Exists(path + "Datenhaltung.db"))
            {
                return true;
            }
            return false;
        }

        private void CreateDatabase(string path)
        {
            FileInfo file = new FileInfo(path + "Datenhaltung.db");
            FileStream fs = file.Create();
            fs.Close();
            CreateTableSchoolClass(path);
            CreateTableStudent(path);
        }

        private bool ExsitsTableStudent(string path)
        {
            DataTable dt = new DataTable();
            SQLiteConnection connection = new SQLiteConnection("Data source="+path+"Datenhaltung.db");
            SQLiteCommand cmd = connection.CreateCommand();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            connection.Open();
            cmd.CommandText = "SELECT name FROM sqlite_master WHERE type = 'table'";
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][0].ToString() == "Student")
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool ExsitsTableSchoolClass(string path)
        {
            DataTable dt = new DataTable();
            SQLiteConnection connection = new SQLiteConnection("Data source=" + path + "Datenhaltung.db");
            SQLiteCommand cmd = connection.CreateCommand();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            connection.Open();
            cmd.CommandText = "SELECT name FROM sqlite_master WHERE type = 'table'";
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][0].ToString() == "SchoolClass")
                    {
                        connection.Close();
                        return true;
                    }
                }
            }
            connection.Close();
            return false;
        }
        
        private void CreateTableStudent(string path)
        {
            SQLiteConnection connection = new SQLiteConnection("Data source=" + path + "Datenhaltung.db");
            connection.Open();
            SQLiteCommand cmd = connection.CreateCommand();
            cmd.CommandText = "CREATE TABLE `Student` (	`ID`	INTEGER PRIMARY KEY AUTOINCREMENT,	`Name`	TEXT,`Fk_ID_SchoolClass`	INTEGER)";
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        private void CreateTableSchoolClass(string path)
        {
            SQLiteConnection connection = new SQLiteConnection("Data source=" + path + "Datenhaltung.db");
            connection.Open();
            SQLiteCommand cmd = connection.CreateCommand();
            cmd.CommandText = "CREATE TABLE `SchoolClass` (	`ID`	INTEGER PRIMARY KEY AUTOINCREMENT,	`Name`	TEXT)";
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        #endregion
    }
}
