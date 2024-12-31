using System.ComponentModel.DataAnnotations;

namespace hospital.Models
{
    public class Medicine
    {
        [Key]
        public int Id {  get; set; }
        public string ?name { get; set; }
        public List<Patient> ?pations { get; set; }=new List<Patient>();
       

    }
}
