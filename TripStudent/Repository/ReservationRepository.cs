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

        public IEnumerable<Reservation> GetAll()
        {
            return _context.Reservations.ToList();
        }

        public Reservation? GetById(int reservationID)
        {
            return _context.Reservations.Find(reservationID);
        }

        public void Insert(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
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

