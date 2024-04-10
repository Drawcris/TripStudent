using TripStudent.Models;
using TripStudent.Repository.Interfaces;
using TripStudent.Services.Interfaces;

namespace TripStudent.Services
{
    public class ReservationService : IReservationService
        {
            private readonly IReservationRepository _context;

            public ReservationService(IReservationRepository context)
            {
                this._context = context;
            }

            public async Task<List<Reservation>> GetAllReservation()
            {
                return await _context.GetAll();
            }


            public async Task<Reservation?> GetReservationById(int Reservation)
            {
                return await _context.GetById(Reservation);
            }

            public async Task AddReservation(Reservation Reservation)
            {
                await _context.Insert(Reservation);
            }

            public void UpdateReservation(Reservation Reservation)
            {
                _context.Update(Reservation);
            }

            public void DeleteReservation(int ReservationID)
            {
                _context.Delete(ReservationID);
            }

            public async Task SaveReservation()
            {
                await _context.Save();
            }
        }
    }

