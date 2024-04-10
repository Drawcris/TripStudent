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
using TripStudent.Services.Interfaces;

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
            return View(await _tripService.GetAllTrips());
        }

        [HttpGet]
        public ActionResult AddTrip()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTrip(Trip model)
        {
            if (ModelState.IsValid)
            {
                _tripService.AddTrip(model);
                _tripService.SaveTrip();
                return RedirectToAction("Index", "Trips");
            }

            return View();
        }

        [HttpGet]
        public async Task<ActionResult> EditTrip(int tripID)
        {
            Trip? model = await _tripService.GetTripById(tripID);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditTrip(Trip model)
        {
            if (ModelState.IsValid)
            {
                _tripService.UpdateTrip(model);
                _tripService.SaveTrip();
                return RedirectToAction("Index", "Trips");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public async Task<ActionResult> DeleteTrip(int tripID)
        {
            Trip? model = await _tripService.GetTripById(tripID);
            return View(model);
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