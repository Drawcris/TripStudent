using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TripStudent.Data;
using TripStudent.Models;
using TripStudent.ViewModel;
using TripStudent.Repository;
using TripStudent.Repository.Interfaces;
using TripStudent.Services.Interfaces;
using TripStudent.Services;
using FluentValidation;
using AutoMapper;
using TripStudent.Validator;

namespace TripStudent.Controllers
{
    public class ReservationsController : Controller
    {
        private IReservationService _reservationService;
        private readonly IValidator<ReservationViewModel> _reservationValidator;
        private readonly IMapper _mapper;

        public ReservationsController(IReservationService options, IValidator<ReservationViewModel> reservationValidator, IMapper mapper)
        {
            this._reservationService = options;
            _reservationValidator = reservationValidator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var reservations = await _reservationService.GetAllReservation();

            //var reservationsViewModellist = reservations.Select(reservation => new ReservationViewModel
            //{
            //    reservationID = reservation.reservationID,
            //    studentID = reservation.studentID,
            //    tripID = reservation.tripID,
            //    reservation_date = reservation.reservation_date,
            //    status = reservation.status,
            //    Trip = reservation.Trip,
            //    Student = reservation.Student

            //});

            var reservationsViewModellist = _mapper.Map<List<Reservation>, List<ReservationViewModel>>(reservations);


            return View(reservationsViewModellist);
        }

        [HttpGet]
        public ActionResult AddReservation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddReservation(ReservationViewModel reservationViewModel)
        {
            //var _ReservationValidator = _reservationValidator.Validate(reservationViewModel);
            //if (_ReservationValidator.IsValid) {
            //    if (ModelState.IsValid)
            //    {
            //        var reservation = new Reservation
            //        {
            //            reservationID = reservationViewModel.reservationID,
            //            studentID = reservationViewModel.studentID,
            //            tripID = reservationViewModel.tripID,
            //            status = reservationViewModel.status,


            //        };


            //        _reservationService.AddReservation(reservation);
            //        _reservationService.SaveReservation();
            //    }
            //    return RedirectToAction("Index", "Reservations");
            //}

            //return View();

            var _ReservationValidator = _reservationValidator.Validate(reservationViewModel);

            if (!_ReservationValidator.IsValid)
            {
                foreach (var failure in _ReservationValidator.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
            }
            if (_ReservationValidator.IsValid)
            {
                var reservations = _mapper.Map<ReservationViewModel, Reservation>(reservationViewModel);
                _reservationService.AddReservation(reservations);
                _reservationService.SaveReservation();
                return RedirectToAction(nameof(Index));
            }
            return View(reservationViewModel);
        }

        [HttpGet]
        public async Task<ActionResult> EditReservation(int reservationID)
        {
            var reservation = await _reservationService.GetReservationById(reservationID);
            if (reservation == null)
            {
                return NotFound();
            }
            var reservationViewModel = new ReservationViewModel
            {
                reservationID = reservation.reservationID,
                studentID = reservation.studentID,
                tripID = reservation.tripID,
                status = reservation.status,
                Trip = reservation.Trip,
                Student = reservation.Student
            };
            return View(reservationViewModel);
        }

        [HttpPost]
        public ActionResult Edit(ReservationViewModel reservationViewModel)
        {

            var _ReservationValidator = _reservationValidator.Validate(reservationViewModel);
            if (_ReservationValidator.IsValid)
            {
                if (ModelState.IsValid)
                {
                    var reservation = new Reservation
                    {
                        reservationID = reservationViewModel.reservationID,
                        studentID = reservationViewModel.studentID,
                        tripID = reservationViewModel.tripID,
                        status = reservationViewModel.status,
                        Trip = reservationViewModel.Trip,
                        Student = reservationViewModel.Student
                    };
                    _reservationService.UpdateReservation(reservation);
                    _reservationService.SaveReservation();
                }
                return RedirectToAction("Index", "Reservations");
            }
            else
            {
                return View(reservationViewModel);
            }
        }

        [HttpGet]
        public async Task<ActionResult> DeleteReservation(int reservationID)
        {
            var reservation = await _reservationService.GetReservationById(reservationID);
            if (reservation == null)
            {
                return NotFound();
            }
            var reservationViewModel = new ReservationViewModel
            {
                reservationID = reservation.reservationID,
                studentID = reservation.studentID,
                tripID = reservation.tripID,
                status = reservation.status,
                Trip = reservation.Trip,
                Student = reservation.Student
            };
            return View(reservationViewModel);
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