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
    public class StudentsController : Controller
    {
        private IStudentRepository _studentRepository;

        public StudentsController(DbContextOptions<TripContext> options)
        {
            _studentRepository = new StudentRepository(new TripContext(options));
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = _studentRepository.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(Student model)
        {
            if (ModelState.IsValid)
            {
                _studentRepository.Insert(model);
                _studentRepository.Save();
                return RedirectToAction("Index", "Students");
            }

            return View();
        }

        [HttpGet]
        public ActionResult EditStudent(int studentID)
        {
            Student? model = _studentRepository.GetById(studentID);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditStudent(Student model)
        {
            if (ModelState.IsValid)
            {
                _studentRepository.Update(model);
                _studentRepository.Save();
                return RedirectToAction("Index", "Students");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteStudent(int studentID)
        {
            Student? model = _studentRepository.GetById(studentID);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int studentID)
        {
            _studentRepository.Delete(studentID);
            _studentRepository.Save();
            return RedirectToAction("Index", "Students");
        }
    }
}