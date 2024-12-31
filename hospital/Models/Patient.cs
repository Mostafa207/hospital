using System.ComponentModel.DataAnnotations;

namespace hospital.Models
{
    
    public class Patient
    {
        [Key]
        public int Id {  get; set; }
        public string ?Name { get; set; }
        [EmailAddress]
        public string ? Email { get; set; }
        public string ? Address { get; set; }
        [Phone] 
        public string ?phone { get; set; }
        
        public Prescription? prescription { get; set; }
        public List<Medicine> ?medicines { get; set; }= new List<Medicine>();
        public List<Appointment>? appointments { get; set; } = new List<Appointment>();

    }
}
