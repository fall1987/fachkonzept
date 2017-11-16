using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schulklassenuebersicht
{
    class Fachkonzept : IFachkonzept
    {
        private Datenerhaltung datenHaltung = new Datenerhaltung();
        private DataTable students;
        private DataTable schoolClasses;

        public DataTable GetAllClasses()
        {
            return schoolClasses = new DataTable();            
        }

        public DataTable GetStudentsByClass(string schoolClass)
        {
            return students = new DataTable();
        }

        public void ChangeStudent(int id, string name, int classId)
        {

        }

        public void RemoveStudent(string name)
        {

        }

        public void RemoveClass(string schoolClass)
        {

        }
    }
}
