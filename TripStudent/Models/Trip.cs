using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace TripStudent.Models
{
    public class Trip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int tripID { get; set; }

        public string Destination { get; set; }

        public decimal Price { get; set; }

        public DateTime StartDate {  get; set; }
        
        public DateTime EndDate { get; set; }

        

        public ICollection<Reservation>? Reservations { get; set; }
    }
}
