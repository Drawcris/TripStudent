using TripStudent.Models;
namespace TripStudent.Repository.Interfaces
{
    public interface ITripRepository
    {
        Task<List<Trip>> GetAll();
        ValueTask<Trip?> GetById(int tripID);
        Task Insert(Trip trip);
        void Update(Trip trip);
        void Delete(int tripID);
        Task Save();
    }
}
