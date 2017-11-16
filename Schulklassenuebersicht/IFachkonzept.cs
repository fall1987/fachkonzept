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
        DataTable GetStudentsByClass(int SchoolClassId);
        void ChangeStudent(int id, string name, int classId);
        void RemoveStudent(int StudentId);
        void RemoveClass(int SchoolClassId);

        void AddStudent(string name);
        void AddSchoolClass(string name);
        
    }
}
