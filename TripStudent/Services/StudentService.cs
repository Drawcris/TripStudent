using Microsoft.EntityFrameworkCore;
using TripStudent.Data;
using TripStudent.Models;
using TripStudent.Repository.Interfaces;
using TripStudent.Repository;
using System.Threading.Tasks;
using TripStudent.Services.Interfaces;

namespace TripStudent.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _context;

        public StudentService(IStudentRepository context)
        {
            this._context = context;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _context.GetAll();
        }


        public async Task<Student?> GetStudentById(int studentID)
        {
            return await _context.GetById(studentID);
        }

        public async Task AddStudent(Student student)
        {
            await _context.Insert(student);
        }

        public void UpdateStudent(Student student)
        {
            _context.Update(student);
        }

        public void DeleteStudent(int studentID)
        {
            _context.Delete(studentID);
        }

        public async Task SaveStudent()
        {
            await _context.Save();
        }
    }
}
