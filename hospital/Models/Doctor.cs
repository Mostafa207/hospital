using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace hospital.Models
{
    public class Doctor
    {
        [Key]
        public  int Id {  get; set; }
        public string ?Name { get; set; }
        [Phone]
        public string ?Phone { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [PasswordPropertyText]
        public string ?Password { get; set; }
        public string ? Address { get; set; }
        public List<Appointment>? appointments { get; set; } = new List<Appointment>();


    }
}
