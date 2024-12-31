using hospital.Models;
using System.ComponentModel.DataAnnotations;

namespace hospital.DTO
{


    public class AppointmentDTO
    {
        public DateTime? Date { get; set; }
        public PatientDTO_date? patient { get; set; }
        public DoctorDTO_date? doctor { get; set; }
    }
    public class AppointmentDTO_date
    {
        public DateTime? Date { get; set; }
        public DoctorDTO_date? doctor { get; set; }
    }

}
