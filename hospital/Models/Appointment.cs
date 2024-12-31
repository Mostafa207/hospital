using System.ComponentModel.DataAnnotations;

namespace hospital.Models
{
    public class Appointment
    {
        [Key]
        public int Id {  get; set; }
        public DateTime? Date { get; set; }
        public int ?patientId { get; set; }
        public Patient? patient { get; set; }
        public int? doctorId { get; set; }
        public Doctor? doctor { get; set; }


    }
}
