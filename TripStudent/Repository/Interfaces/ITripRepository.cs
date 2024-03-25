using TripStudent.Models;
namespace TripStudent.Repository.Interfaces
{
    public interface ITripRepository
    {
        IEnumerable<Trip> GetAll();
        Trip? GetById(int tripID);
        void Insert(Trip trip);
        void Update(Trip trip);
        void Delete(int tripID);
        void Save();
    }
}
