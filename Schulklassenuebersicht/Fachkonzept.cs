using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schulklassenuebersicht
{
    class Fachkonzept : IFachkonzept
    {
        private Datenerhaltung datenHaltung = new Datenerhaltung();
        private List<string> students;
        private List<string> schoolClasses;

        public List<string> GetAllClasses()
        {
            
        }

        public List<string> GetStudentsByClass(string schoolClass)
        {

        }

        public void ChangeStudent(string name)
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


/*
 * List<string> GetAllClasses();
        List<string> GetStudentsByClass(string schoolClass);
        void ChangeStudent(string name);
        void RemoveStudent(string name);
        void RemoveClass(string schoolClass);
        
*/