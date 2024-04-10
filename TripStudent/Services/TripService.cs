using TripStudent.Models;
using TripStudent.Repository.Interfaces;
using TripStudent.Services.Interfaces;

namespace TripStudent.Services
{
    public class TripService : ITripService
    {
        private readonly ITripRepository _context;

        public TripService(ITripRepository context)
        {
            this._context = context;
        }

        public async Task<List<Trip>> GetAllTrips()
        {
            return await _context.GetAll();
        } 


        public async Task<Trip?> GetTripById(int tripID) 
        {
            return await _context.GetById(tripID);
        }

        public async Task AddTrip(Trip trip) 
        {
            await _context.Insert(trip);
        }

        public void  UpdateTrip(Trip trip) 
        {
             _context.Update(trip);
        }

        public  void DeleteTrip(int tripID) 
        {
             _context.Delete(tripID);
        }

        public async Task SaveTrip() 
        {
            await _context.Save();
        }
    }
}
