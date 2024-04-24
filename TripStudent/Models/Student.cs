using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripStudent.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int studentID { get; set; }
        [Required]
        [MaxLength(50)]
        public string name { get; set;}
        
        [MaxLength(50)]
        public string lastname { get; set;}
      
        [MaxLength(50)]
        public string email { get; set;}

        public ICollection<Reservation>? Reservations { get; set; }
    }
}
