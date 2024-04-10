using TripStudent.Models;

namespace TripStudent.Services.Interfaces
{
    public interface IReservationService
    {
        Task<List<Reservation>> GetAllReservation();

        Task<Reservation?> GetReservationById(int reservationID);

        Task AddReservation(Reservation reservation);

        void UpdateReservation(Reservation reservation);

        void DeleteReservation(int reservationID);

        Task SaveReservation();
    }
}

