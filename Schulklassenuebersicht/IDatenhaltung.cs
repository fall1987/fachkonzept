using System.Data;

namespace Schulklassenuebersicht
{
    interface IDatenhaltung
    {
       void SetSchoolClass(string name);
       DataTable GetSchoolClass(int id);
       DataTable GetAllSchoolClass();
       void RemoveSchoolClass(int id);
       void SetStudent(string name);
       DataTable GetStudent(int id);
       DataTable GetAllStudentByClass(int SchoolclassID);
       DataTable GetAllStudent();
       void RemoveStudent(int id);
       void SetRelation(int SchoolClassID, int StudentID);
       void RemoveRelation(int SchoolClassID);
       void RemoveRelation(int SchoolClassID,int StudentID);
    }
}
