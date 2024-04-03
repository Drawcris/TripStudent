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
    public class ReservationsController : Controller
    {
        private IReservationRepository _reservationRepository;

        public ReservationsController(DbContextOptions<TripContext> options)
        {
            _reservationRepository = new ReservationRepository(new TripContext(options));
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = _reservationRepository.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddReservation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddReservation(Reservation model)
        {
            if (ModelState.IsValid)
            {
                _reservationRepository.Insert(model);
                _reservationRepository.Save();
                return RedirectToAction("Index", "Reservations");
            }

            return View();
        }

        [HttpGet]
        public ActionResult EditReservation(int reservationID)
        {
            Reservation? model = _reservationRepository.GetById(reservationID);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Reservation model)
        {
            if (ModelState.IsValid)
            {
                _reservationRepository.Update(model);
                _reservationRepository.Save();
                return RedirectToAction("Index", "Reservations");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteReservation(int reservationID)
        {
            Reservation? model = _reservationRepository.GetById(reservationID);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int reservationID)
        {
            _reservationRepository.Delete(reservationID);
            _reservationRepository.Save();
            return RedirectToAction("Index", "Reservation");
        }
    }
}