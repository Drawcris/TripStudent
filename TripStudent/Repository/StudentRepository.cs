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

        public Task<List<Student>> GetAll()
        {
            return _context.Students.ToListAsync();
        }

        public ValueTask<Student?> GetById(int tripID)
        {
            return _context.Students.FindAsync(tripID);
        }

        public async Task Insert(Student student)
        {
            await _context.Students.AddAsync(student);
        }

        public void Update(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
        }

        public void Delete(Student student)
        {
           _context.Students.Find(student);

            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChangesAsync();
            }


        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
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