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
            return schoolClasses = datenHaltung.GetAllSchoolClass();               
        }

        public DataTable GetAllStudents()
        {
            students = datenHaltung.GetAllStudent();

            foreach (DataRow dataRow in students.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            Console.ReadKey();
            return students;
        }

        public DataTable GetStudentsByClass(int schoolClassId)
        {

            return students = datenHaltung.GetAllStudentByClass(schoolClassId);
        }

        public void ChangeStudent(int id, string name, int classId)
        {
           
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
    }
}
