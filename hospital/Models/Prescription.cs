using System.ComponentModel.DataAnnotations;

namespace hospital.Models
{
    public class Prescription
    {
        [Key]
        public int Id {  get; set; }
        public string ?Name { get; set; }
        public int? PatientId { get; set; }
        public Patient ?Patient { get; set; }
       

    }
}
