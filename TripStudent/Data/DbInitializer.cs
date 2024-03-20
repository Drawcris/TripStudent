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
                new Student{studentID = 1, name = "Carson", lastname = "Alexander", email = "CAlexander@gmail.com" },
                new Student{studentID = 2, name = "Meredith", lastname = "Alonso", email = "MAlonso@gmail.com" },
                new Student{studentID = 3, name = "Arturo", lastname = "Anand", email = "Anand@gmail.com" },
                new Student{studentID = 4, name = "Gytis", lastname = "Barzdus", email = "GBarzdus@gmail.com" }
            };

            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var trip = new Trip[]
            {
                new Trip{ tripID = 1, Destination = "Kraków", Price = 500, StartDate = DateTime.Parse("2024-03-20"), EndDate= DateTime.Parse("2024-03-30")  },
                new Trip{ tripID = 2, Destination = "Paryż", Price = 3000, StartDate = DateTime.Parse("2024-04-20"), EndDate= DateTime.Parse("2024-04-30")  },
                new Trip{ tripID = 3, Destination = "Wiedeń", Price = 1000, StartDate = DateTime.Parse("2024-05-20"), EndDate= DateTime.Parse("2024-05-30")  },
                new Trip{ tripID = 4, Destination = "Berlin", Price = 800, StartDate = DateTime.Parse("2024-06-20"), EndDate= DateTime.Parse("2024-06-30")  }

            };
            foreach (Trip c in trip)
            {
                context.Trips.Add(c);
            }
            context.SaveChanges();

            var reservation = new Reservation[]
            {
                new Reservation{reservationID = 1 ,studentID = 1, tripID = 1, reservation_date = DateTime.Parse("2024-03-18"),  status = status.Zatwierdzona  },
                new Reservation{reservationID = 2 ,studentID = 2, tripID = 2, reservation_date = DateTime.Parse("2024-04-18"),  status = status.Zatwierdzona  },
                new Reservation{reservationID = 3 ,studentID = 3, tripID = 3, reservation_date = DateTime.Parse("2024-05-18"),  status = status.Anulowana  },
                new Reservation{reservationID = 4 ,studentID = 4, tripID = 4, reservation_date = DateTime.Parse("2024-06-18"),  status = status.Oczekująca  }
            };
            foreach (Reservation e in reservation)
            {
                context.Reservations.Add(e);
            }
            context.SaveChanges();

        }
    }
}
