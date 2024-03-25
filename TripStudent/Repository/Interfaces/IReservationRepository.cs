using TripStudent.Models;

namespace TripStudent.Repository.Interfaces
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> GetAll();
        Reservation? GetById(int reservationID);
        void Insert(Reservation reservation);
        void Update(Reservation reservation);
        void Delete(int reservationID);
        void Save();
    }
}
