using TripStudent.Models;
namespace TripStudent.Repository.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAll();
        ValueTask<Student?> GetById(int studentID);
        Task Insert(Student student);
        void Update(Student student);
        void Delete(int studentID);
        Task Save();
    }
}
