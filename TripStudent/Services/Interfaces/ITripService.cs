using System.Collections.Generic;
using System.Threading.Tasks;
using TripStudent.Models;

namespace TripStudent.Services.Interfaces
{
    public interface ITripService
    {
        Task<List<Trip>> GetAllTrips();

        Task<Trip?> GetTripById(int tripID);

        Task AddTrip(Trip trip);

        void UpdateTrip(Trip trip);

        void DeleteTrip(int tripID);

        Task SaveTrip();
    }
}
