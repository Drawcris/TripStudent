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

        public IEnumerable<Trip> GetAll()
        {
            return _context.Trips.ToList();
        }

        public Trip? GetById(int tripID)
        {
            return _context.Trips.Find(tripID);
        }

        public void Insert(Trip trip)
        {
            _context.Trips.Add(trip);
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