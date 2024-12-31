using hospital.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace hospital.DTO
{
    public class DoctorDTO
    {
        public string? Name { get; set; }
        [Phone]
        public string? Phone { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [PasswordPropertyText]
        public string? Password { get; set; }
        public string? Address { get; set; }
        public List<AppointmentDTO>? appointments { get; set; } = new List<AppointmentDTO>();

    }
    public class DoctorDTO_date
    {
        public string? Name { get; set; }
        [Phone]
        public string? Phone { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [PasswordPropertyText]
        public string? Password { get; set; }
        public string? Address { get; set; }

    }


}
