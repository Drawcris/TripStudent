using System;
using System.Collections.Generic;

namespace TripStudent.Models
{
    public class Student
    {

        public int studentID { get; set; }

        public string name { get; set;}

        public string lastname { get; set;}

        public string email { get; set;}

        public ICollection<Reservation> Reservations { get; set; }
    }
}
