using Microsoft.EntityFrameworkCore;
using TripStudent.Data;
using TripStudent.Models;
using TripStudent.Repository.Interfaces;


namespace TripStudent.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly TripContext _context;

        public ReservationRepository(TripContext context)
        {
            _context = context;
        }

        public Task<List<Reservation>> GetAll()
        {
            return _context.Reservations.ToListAsync();
        }

        public ValueTask<Reservation?> GetById(int reservationsID)
        {
            return _context.Reservations.FindAsync(reservationsID);
        }

        public async Task Insert(Reservation reservation)
        {
            await _context.Reservations.AddAsync(reservation);
        }


        public void Update(Reservation reservation)
        {
            _context.Entry(reservation).State = EntityState.Modified;
        }

        public void Delete(int reservationID)
        {
            Reservation? reservation = _context.Reservations.Find(reservationID);

            if (reservation != null)
            {          
                _context.Reservations.Remove(reservation);
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

