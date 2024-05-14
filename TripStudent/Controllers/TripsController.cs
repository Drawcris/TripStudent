using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TripStudent.Data;
using TripStudent.Models;
using TripStudent.Repository;
using TripStudent.Repository.Interfaces;
using TripStudent.Services;
using TripStudent.Services.Interfaces;
using TripStudent.Validator;
using TripStudent.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace TripStudent.Controllers
{
    [Authorize] ///
    public class TripsController : Controller
    {
        private ITripService _tripService;
        private readonly IValidator<TripViewModel> _tripValidator;
        private readonly IMapper _mapper;

        public TripsController(ITripService options, IValidator<TripViewModel> tripValidator, IMapper mapper)
        {
            this._tripService = options;
            _tripValidator = tripValidator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var trips = await _tripService.GetAllTrips();

            var tripViewModelList = _mapper.Map<List<TripViewModel>>(trips);

            return View(tripViewModelList);


            
            
        }

        [HttpGet]
        public ActionResult AddTrip()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTrip(TripViewModel tripViewModel)
        {
            //var _TripValidator = _tripValidator.Validate(tripViewModel);
            //if (_TripValidator.IsValid) {
            //    if (ModelState.IsValid)
            //    {
            //        var trip = new Trip
            //        {
            //            tripID = tripViewModel.tripID,
            //            Destination = tripViewModel.Destination,
            //            Price = tripViewModel.Price,
            //            StartDate = tripViewModel.StartDate,
            //            EndDate = tripViewModel.EndDate,
            //        };
            //        _tripService.AddTrip(trip);
            //        _tripService.SaveTrip();
            //    }
            //    return RedirectToAction("Index", "Trips");
            //}

            //return View();

            var _TripValidator = _tripValidator.Validate(tripViewModel);

            if (!_TripValidator.IsValid)
            {
                foreach (var failure in _TripValidator.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
            }
            if (_TripValidator.IsValid)
            {
                var trip = _mapper.Map<TripViewModel, Trip>(tripViewModel);
                _tripService.AddTrip(trip);
                _tripService.SaveTrip();
                return RedirectToAction(nameof(Index));
            }
            return View(tripViewModel);
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
            var _TripValidator = _tripValidator.Validate(tripViewModel);
            if (_TripValidator.IsValid)
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
                }
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