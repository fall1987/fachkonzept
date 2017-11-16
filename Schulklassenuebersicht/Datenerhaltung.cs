using System;
using System.Data.SQLite;
using System.IO;
using System.Data;

namespace Schulklassenuebersicht
{
    class Datenerhaltung :IDatenhaltung
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
        #region IDatenhaltung
        public void SetSchoolClass(string name)
        {
            string path = GetProjectPath();
            SQLiteConnection connection = new SQLiteConnection("Data source=" + path + "Datenhaltung.db");
            SQLiteCommand cmd = connection.CreateCommand();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            connection.Open();
            cmd.CommandText="INSERT INTO SchoolClass (Name) VALUES ('" + name + "');" ;
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public DataTable GetSchoolClass(int id)
        {
            string path = GetProjectPath();
            SQLiteConnection connection = new SQLiteConnection("Data source=" + path + "Datenhaltung.db");
            SQLiteCommand cmd = connection.CreateCommand();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            connection.Open();
            cmd.CommandText = "Select * FROM SchoolClass WHERE ID like " + id + ";";
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public DataTable GetAllSchoolClass()
        {
            string path = GetProjectPath();
            SQLiteConnection connection = new SQLiteConnection("Data source=" + path + "Datenhaltung.db");
            SQLiteCommand cmd = connection.CreateCommand();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            connection.Open();
            cmd.CommandText = "Select * FROM SchoolClass ;";
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            return dt;
        }
        public void RemoveSchoolClass(int id)
        {
            string path = GetProjectPath();
            SQLiteConnection connection = new SQLiteConnection("Data source=" + path + "Datenhaltung.db");
            SQLiteCommand cmd = connection.CreateCommand();
            connection.Open();
            cmd.CommandText = "DELETE FROM SchoolClass Where ID like "+ id+";";
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void SetStudent(string name)
        {
            string path = GetProjectPath();
            SQLiteConnection connection = new SQLiteConnection("Data source=" + path + "Datenhaltung.db");
            SQLiteCommand cmd = connection.CreateCommand();
            connection.Open();
            cmd.CommandText = "INSERT INTO Student (name) VALUES ('" + name + "');";
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public DataTable GetStudent(int id)
        {
            string path = GetProjectPath();
            SQLiteConnection connection = new SQLiteConnection("Data source=" + path + "Datenhaltung.db");
            SQLiteCommand cmd = connection.CreateCommand();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            connection.Open();
            cmd.CommandText = "Select * FROM Student WHERE ID like " + id + ";";
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public DataTable GetAllStudent()
        {
            string path = GetProjectPath();
            SQLiteConnection connection = new SQLiteConnection("Data source=" + path + "Datenhaltung.db");
            SQLiteCommand cmd = connection.CreateCommand();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            connection.Open();
            cmd.CommandText = "Select * FROM Student ;";
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public DataTable GetAllStudentByClass(int SchoolclassID)
        {
            string path = GetProjectPath();
            SQLiteConnection connection = new SQLiteConnection("Data source=" + path + "Datenhaltung.db");
            SQLiteCommand cmd = connection.CreateCommand();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            connection.Open();
            cmd.CommandText = String.Format("Select * FROM Student WHERE Fk_ID_SchoolClass = {0};",SchoolclassID);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public void RemoveStudent(int id)
        {
            string path = GetProjectPath();
            SQLiteConnection connection = new SQLiteConnection("Data source=" + path + "Datenhaltung.db");
            SQLiteCommand cmd = connection.CreateCommand();
            connection.Open();
            cmd.CommandText = "DELETE FROM Student Where ID like " + id + ";";
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void SetRelation(int SchoolClassID, int StudentID)
        {
            string path = GetProjectPath();
            SQLiteConnection connection = new SQLiteConnection("Data source=" + path + "Datenhaltung.db");
            SQLiteCommand cmd = connection.CreateCommand();
            connection.Open();
            cmd.CommandText = "UPDATE Student SET Fk_ID_SchoolClass = " + SchoolClassID + " WHERE ID = " + StudentID + ";";
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void RemoveRelation(int SchoolClassID)
        {
            string path = GetProjectPath();
            SQLiteConnection connection = new SQLiteConnection("Data source=" + path + "Datenhaltung.db");
            SQLiteCommand cmd = connection.CreateCommand();
            connection.Open();
            cmd.CommandText = "UPDATE Student SET Fk_ID_SchoolClass = NULL WHERE Fk_ID_SchoolClass = "+SchoolClassID+";";
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void RemoveRelation(int SchoolClassID, int StudentID)
        {
            string path = GetProjectPath();
            SQLiteConnection connection = new SQLiteConnection("Data source=" + path + "Datenhaltung.db");
            SQLiteCommand cmd = connection.CreateCommand();
            connection.Open();
            cmd.CommandText = "UPDATE Student SET Fk_ID_SchoolClass = NULL WHERE Fk_ID_SchoolClass = " + SchoolClassID + " AND ID = "+StudentID+";";
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        #endregion

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
