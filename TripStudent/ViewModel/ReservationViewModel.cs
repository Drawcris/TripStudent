using TripStudent.Models;

namespace TripStudent.ViewModel
{
    public class ReservationViewModel
    {
        public int reservationID { get; set; }

        public int studentID { get; set; }


        public int tripID { get; set; }

        public DateTime reservation_date { get; set; }
        public status? status { get; set; }

        public Trip? Trip { get; set; }

        public Student? Student { get; set; }
    }
}
