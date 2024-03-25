using Microsoft.EntityFrameworkCore;
using TripStudent.Data;
using TripStudent.Models;
using TripStudent.Repository.Interfaces;



namespace TripStudent.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly TripContext _context;

        public StudentRepository(TripContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student? GetById(int studentID)
        {
            return _context.Students.Find(studentID);
        }

        public void Insert(Student student)
        {
            _context.Students.Add(student);
        }

        public void Update(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
        }

        public void Delete(int studentID)
        {
            Student? student = _context.Students.Find(studentID);

            if (student != null)
            {
                _context.Students.Remove(student);
            }

        }
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}