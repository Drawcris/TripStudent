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
    public class ReservationsController : Controller
    {
        private IReservationService _reservationService;

        public ReservationsController(IReservationService options)
        {
            this._reservationService = options;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _reservationService.GetAllReservation());
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
                _reservationService.AddReservation(model);
                _reservationService.SaveReservation();
                return RedirectToAction("Index", "Reservations");
            }

            return View();
        }

        [HttpGet]
        public async Task<ActionResult> EditReservation(int reservationID)
        {
            Reservation? model = await _reservationService.GetReservationById(reservationID);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Reservation model)
        {
            if (ModelState.IsValid)
            {
                _reservationService.UpdateReservation(model);
                _reservationService.SaveReservation();
                return RedirectToAction("Index", "Reservations");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public async Task<ActionResult> DeleteReservation(int reservationID)
        {
            Reservation? model = await _reservationService.GetReservationById(reservationID);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int reservationID)
        {
            _reservationService.DeleteReservation(reservationID);
            _reservationService.SaveReservation();
            return RedirectToAction("Index", "Reservation");
        }
    }
}