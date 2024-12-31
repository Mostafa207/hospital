using hospital.Models;
using System.ComponentModel.DataAnnotations;


namespace hospital.DTO
{
    public class MedicineDTO
    {

        public string? name { get; set; }
        public List<PatientDTO>? pations { get; set; } = new List<PatientDTO>();

    }
}
