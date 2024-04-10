using System.Collections.Generic;
using System.Threading.Tasks;
using TripStudent.Models;

namespace TripStudent.Services.Interfaces
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudents();

        Task<Student?> GetStudentById(int studentID);

        Task AddStudent(Student student);

        void UpdateStudent(Student student);

        void DeleteStudent(int studentID);

        Task SaveStudent();
    }
}
