using System.ComponentModel.DataAnnotations;


namespace TripStudent.ViewModel
{
    public class StudentViewModel
    {
        public int studentID { get; set; }
       
        public string name { get; set; }

        public string lastname { get; set; }
        
        public string email { get; set; }
    }
}
