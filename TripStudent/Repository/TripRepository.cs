using Microsoft.EntityFrameworkCore;
using TripStudent.Data;
using TripStudent.Models;
using TripStudent.Repository.Interfaces;



namespace TripStudent.Repository
{
    public class TripRepository : ITripRepository
    {
        private readonly TripContext _context;

        public TripRepository(TripContext context)
        {
            _context = context;
        }

        public Task<List<Trip>> GetAll()
        {
            return _context.Trips.ToListAsync();
        }

        public ValueTask<Trip?> GetById(int tripID)
        {
            return _context.Trips.FindAsync(tripID);
        }

        public async Task Insert(Trip trip)
        {
           await _context.Trips.AddAsync(trip);
        }

        public void Update(Trip trip)
        {
            _context.Entry(trip).State = EntityState.Modified;
        }
        public void Delete(int tripID)
        {
            Trip? trip = _context.Trips.Find(tripID);

            if (trip != null)
            {
                _context.Trips.Remove(trip);
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