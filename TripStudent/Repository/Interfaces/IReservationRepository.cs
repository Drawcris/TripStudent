using TripStudent.Models;

namespace TripStudent.Repository.Interfaces
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetAll();
        ValueTask<Reservation?> GetById(int reservationID);
        Task Insert(Reservation reservation);
        void Update(Reservation reservation);
        void Delete(int reservationID);
        Task Save();
    }
}
