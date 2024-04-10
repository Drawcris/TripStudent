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
    public class StudentsController : Controller
    {
        private IStudentService _studentService;

        public StudentsController(IStudentService options)
        {
            this._studentService = options;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _studentService.GetAllStudents());
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
                _studentService.AddStudent(model);
                _studentService.SaveStudent();
                return RedirectToAction("Index", "Students");
            }

            return View();
        }

        [HttpGet]
        public async Task<ActionResult> EditStudent(int studentID)
        {
            Student? model = await _studentService.GetStudentById(studentID);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditStudent(Student model)
        {
            if (ModelState.IsValid)
            {
                _studentService.UpdateStudent(model);
                _studentService.SaveStudent();
                return RedirectToAction("Index", "Students");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public async Task<ActionResult> DeleteStudent(int studentID)
        {
            Student? model = await _studentService.GetStudentById(studentID);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int studentID)
        {
            _studentService.DeleteStudent(studentID);
            _studentService.SaveStudent();
            return RedirectToAction("Index", "Students");
        }
    }
}