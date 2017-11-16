using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Schulklassenuebersicht
{
    interface IDatenhaltung
    {
       void CreateTable(string name);
       void SetSchoolClass(SchoolClass schoolclass);
       SchoolClass GetSchoolClass(string id);
       ArrayList GetAllSchoolClass();
       void RemoveSchoolClass(SchoolClass schoolclass);
       void SetStudent(Student student);
       Student GetStudent();
       ArrayList GetAllStudent(SchoolClass schoolclass);
       void RemoveStudent(Student student);
       void SetRelation(SchoolClass schoolclass, Student student);
    }
}
