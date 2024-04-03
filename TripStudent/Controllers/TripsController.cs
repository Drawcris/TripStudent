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

namespace TripStudent.Controllers
{
    public class TripsController : Controller
    {
        private ITripRepository _tripRepository;

        public TripsController(DbContextOptions<TripContext> options)
        {
            _tripRepository = new TripRepository(new TripContext(options));
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = _tripRepository.GetAll();
            return View(model);
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
                _tripRepository.Insert(model);
                _tripRepository.Save();
                return RedirectToAction("Index", "Trips");
            }

            return View();
        }

        [HttpGet]
        public ActionResult EditTrip(int tripID)
        {
            Trip? model = _tripRepository.GetById(tripID);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditTrip(Trip model)
        {
            if (ModelState.IsValid)
            {
                _tripRepository.Update(model);
                _tripRepository.Save();
                return RedirectToAction("Index", "Trips");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteTrip(int tripID)
        {
            Trip? model = _tripRepository.GetById(tripID);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int tripID)
        {
            _tripRepository.Delete(tripID);
            _tripRepository.Save();
            return RedirectToAction("Index", "Trips");
        }
    }
}