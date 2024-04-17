using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TripStudent.Data;
using TripStudent.Models;
using TripStudent.Repository;
using TripStudent.Repository.Interfaces;
using TripStudent.Services;
using TripStudent.Services.Interfaces;
using TripStudent.ViewModel;

namespace TripStudent.Controllers
{
    public class TripsController : Controller
    {
        private ITripService _tripService;

        public TripsController(ITripService options)
        {
            this._tripService = options;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var trips = await _tripService.GetAllTrips();

            var TripViewModelList = trips.Select(trip => new TripViewModel
            {
               tripID = trip.tripID,
               Destination = trip.Destination,
               Price = trip.Price,
               StartDate = trip.StartDate,
               EndDate = trip.EndDate,
            });


            return View(TripViewModelList);
            
        }

        [HttpGet]
        public ActionResult AddTrip()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTrip(TripViewModel tripViewModel)
        {
            if (ModelState.IsValid)
            {
                var trip = new Trip
                {
                    tripID = tripViewModel.tripID,
                    Destination = tripViewModel.Destination,
                    Price = tripViewModel.Price,
                    StartDate = tripViewModel.StartDate,
                    EndDate = tripViewModel.EndDate,
                };
                _tripService.AddTrip(trip);
                _tripService.SaveTrip();
                return RedirectToAction("Index", "Trips");
            }

            return View();
        }

        [HttpGet]
        public async Task<ActionResult> EditTrip(int tripID)
        {
            var trip = await _tripService.GetTripById(tripID);
            if (trip == null)
            {
                return NotFound();
            }
            var tripViewModel = new TripViewModel
            {
                tripID = trip.tripID,
                Destination = trip.Destination,
                Price = trip.Price,
                StartDate = trip.StartDate,
                EndDate = trip.EndDate,
            };
            return View(tripViewModel);
        }

        [HttpPost]
        public ActionResult EditTrip(TripViewModel tripViewModel)
        {
            if (ModelState.IsValid)
            {
                var trip = new Trip
                {
                    tripID = tripViewModel.tripID,
                    Destination = tripViewModel.Destination,
                    Price = tripViewModel.Price,
                    StartDate = tripViewModel.StartDate,
                    EndDate = tripViewModel.EndDate,
                };
                _tripService.UpdateTrip(trip);
                _tripService.SaveTrip();
                return RedirectToAction("Index", "Trips");
            }
            else
            {
                return View(tripViewModel);
            }
        }

        [HttpGet]
        public async Task<ActionResult> DeleteTrip(int tripID)
        {
            var trip = await _tripService.GetTripById(tripID);
            if (trip == null)
            {
                return NotFound();
            }
            var tripViewModel = new TripViewModel
            {
                tripID = trip.tripID,
                Destination = trip.Destination,
                Price = trip.Price,
                StartDate = trip.StartDate,
                EndDate = trip.EndDate,
            };
            return View(tripViewModel);
        }

        [HttpPost]
        public ActionResult Delete(int tripID)
        {
            _tripService.DeleteTrip(tripID);
            _tripService.SaveTrip();
            return RedirectToAction("Index", "Trips");
        }
    }
}