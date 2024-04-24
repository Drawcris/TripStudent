using System.ComponentModel.DataAnnotations;

namespace TripStudent.ViewModel
{
    public class TripViewModel
    {
        public int tripID { get; set; }

        public string Destination { get; set; }

        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
