using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TripStudent.Models
{
    public enum status
    {
        Zatwierdzona, Oczekująca, Anulowana
    }
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? reservationID { get; set; }

        public int? studentID { get; set; }


        public int? tripID { get; set; }

        public DateTime? reservation_date { get; set; }
        public status? status { get; set; }



        public Trip? Trip { get; set; }

        public Student? Student { get; set; }

    }
}
