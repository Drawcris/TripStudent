using TripStudent.Models;
using System;
using System.Linq;

namespace TripStudent.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TripContext context)
        {
            context.Database.EnsureCreated();


            if (context.Students.Any())
            {
                return; 
            }
            var students = new Student[]
            {
                new Student{ name = "Carson", lastname = "Alexander", email = "CAlexander@gmail.com" },
                new Student{ name = "Meredith", lastname = "Alonso", email = "MAlonso@gmail.com" },
                new Student{ name = "Arturo", lastname = "Anand", email = "Anand@gmail.com" },
                new Student{ name = "Gytis", lastname = "Barzdus", email = "GBarzdus@gmail.com" }
            };

            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var trip = new Trip[]
            {
                new Trip{  Destination = "Kraków", Price = 500, StartDate = DateTime.Parse("2024-03-20"), EndDate= DateTime.Parse("2024-03-30")  },
                new Trip{  Destination = "Paryż", Price = 3000, StartDate = DateTime.Parse("2024-04-20"), EndDate= DateTime.Parse("2024-04-30")  },
                new Trip{  Destination = "Wiedeń", Price = 1000, StartDate = DateTime.Parse("2024-05-20"), EndDate= DateTime.Parse("2024-05-30")  },
                new Trip{  Destination = "Berlin", Price = 800, StartDate = DateTime.Parse("2024-06-20"), EndDate= DateTime.Parse("2024-06-30")  }

            };
            foreach (Trip c in trip)
            {
                context.Trips.Add(c);
            }
            context.SaveChanges();

            var astudents = context.Students.ToList();
            var atrip = context.Trips.ToList();

            var reservation = new Reservation[]
            {
                new Reservation{studentID = astudents[0].studentID, tripID = atrip[0].tripID, reservation_date = DateTime.Parse("2024-03-18"),  status = status.Zatwierdzona  },
                new Reservation{studentID = astudents[1].studentID, tripID = atrip[1].tripID, reservation_date = DateTime.Parse("2024-04-18"),  status = status.Zatwierdzona  },
                new Reservation{studentID = astudents[2].studentID, tripID = atrip[2].tripID, reservation_date = DateTime.Parse("2024-05-18"),  status = status.Anulowana  },
                new Reservation{studentID = astudents[3].studentID, tripID = atrip[3].tripID, reservation_date = DateTime.Parse("2024-06-18"),  status = status.Oczekująca  }
            };
            foreach (Reservation e in reservation)
            {
                context.Reservations.Add(e);
            }
            context.SaveChanges();


        }
    }
}
