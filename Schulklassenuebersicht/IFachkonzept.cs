using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schulklassenuebersicht
{
    interface IFachkonzept
    {
        List<string> GetAllClasses();
        List<string> GetStudentsByClass(string schoolClass);
        void ChangeStudent(string name);
        void RemoveStudent(string name);
        void RemoveClass(string schoolClass);
        
    }
}
