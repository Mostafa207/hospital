using hospital.Models;
using System.ComponentModel.DataAnnotations;


namespace hospital.DTO
{
    
    public class PatientDTO
    {
        public string? Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Address { get; set; }
        [Phone]
        public string? phone { get; set; }

        public PrescriptionDTO_date? prescription { get; set; }
        public List<MedicineDTO>? medicines { get; set; } = new List<MedicineDTO>();
        public List<AppointmentDTO_date>? appointments { get; set; } = new List<AppointmentDTO_date>();
    }
    public class PatientDTO_date
    {
        public string? Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Address { get; set; }
        [Phone]
        public string? phone { get; set; }
    }




}
