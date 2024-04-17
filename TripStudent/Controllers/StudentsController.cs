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
            var students = await _studentService.GetAllStudents();

            var studentsViewModellist = students.Select(student => new StudentViewModel
            {
                studentID = student.studentID,
                name = student.name,
                lastname = student.lastname,
                email = student.email,
            });


            return View(studentsViewModellist);
        }

        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(StudentViewModel studentViewModel)
        {
            if (ModelState.IsValid)
            {
                var student = new Student
                {
                    studentID = studentViewModel.studentID,
                    name = studentViewModel.name,
                    lastname = studentViewModel.lastname,
                    email = studentViewModel.email

                };
                _studentService.AddStudent(student);
                _studentService.SaveStudent();
                return RedirectToAction("Index", "Students");
            }

            return View();
        }

        [HttpGet]
        public async Task<ActionResult> EditStudent(int studentID)
        {
            var student = await _studentService.GetStudentById(studentID);
            if (student == null)
            {
                return NotFound();
            }
            var studentViewModel = new StudentViewModel
            {
                studentID = student.studentID,
                name = student.name,
                lastname = student.lastname,
                email = student.email
            };
            return View(studentViewModel);
            
        }

        [HttpPost]
        public ActionResult EditStudent(StudentViewModel studentViewModel)
        {
            if (ModelState.IsValid)
            {
                var student = new Student
                {
                    studentID = studentViewModel.studentID,
                    name = studentViewModel.name,
                    lastname = studentViewModel.lastname,
                    email = studentViewModel.email

                };
                _studentService.UpdateStudent(student);
                _studentService.SaveStudent();
                return RedirectToAction("Index", "Students");
            }
            else
            {
                return View(studentViewModel);
            }
        }

        [HttpGet]
        public async Task<ActionResult> DeleteStudent(int studentID)
        {
            var student = await _studentService.GetStudentById(studentID);
            if (student == null)
            {
                return NotFound();
            }
            var studentViewModel = new StudentViewModel
            {
                studentID = student.studentID,
                name = student.name,
                lastname = student.lastname,
                email = student.email
            };
            return View(studentViewModel);
        }

        [HttpPost]
        public ActionResult Delete(Student student)
        {
            _studentService.DeleteStudent(student);
            _studentService.SaveStudent();
            return RedirectToAction("Index", "Students");
        }
    }
}