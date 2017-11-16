using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schulklassenuebersicht
{
    interface IFachkonzept
    {
        DataTable GetAllClasses();
        DataTable GetStudentsByClass(string schoolClass);
        void ChangeStudent(int id, string name, int classId);
        void RemoveStudent(string name);
        void RemoveClass(string schoolClass);
        
    }
}
