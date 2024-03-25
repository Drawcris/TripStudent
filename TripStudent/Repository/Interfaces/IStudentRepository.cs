using TripStudent.Models;
namespace TripStudent.Repository.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student? GetById(int studentID);
        void Insert(Student student);
        void Update(Student student);
        void Delete(int studentID);
        void Save();
    }
}
