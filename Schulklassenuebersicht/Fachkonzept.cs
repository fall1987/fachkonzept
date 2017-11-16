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
            schoolClasses = sortByName(datenHaltung.GetAllSchoolClass());

            return schoolClasses;
        }

        public DataTable GetAllStudents()
        {
            students = sortByName(datenHaltung.GetAllStudent());
            
            return students;
        }

        public DataTable GetStudentsByClass(int schoolClassId)
        {
            students = sortByName(datenHaltung.GetAllStudentByClass(schoolClassId));
            return students;
        }

        public void ChangeStudent(int id, string name, int classId)
        {
            datenHaltung.UpdateStudent(id, name);
            datenHaltung.SetRelation(id, classId);
        }

        public void RemoveStudent(int StudentId)
        {
            datenHaltung.RemoveStudent(StudentId);
        }

        public void RemoveClass(int SchoolClassId)
        {
            datenHaltung.RemoveSchoolClass(SchoolClassId);
        }

        public void AddStudent(string name)
        {
            datenHaltung.SetStudent(name);
        }
        public void AddSchoolClass(string name)
        {
            datenHaltung.SetSchoolClass(name);
        }

        private DataTable sortByName(DataTable data)
        {            
            data.DefaultView.Sort = "Name";
            return data;
        }
    }
}
