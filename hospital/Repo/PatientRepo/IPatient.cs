using hospital.DTO;

namespace hospital.Repo.PatientRepo
{
    public interface IPatient
    {
        public void Add(PatientDTO_date dto);
        public void Updata(PatientDTO_date dto, int id);
        public void Remove(int id);
        public PatientDTO GetbyId(int id);
        IEnumerable<object> GetAll();
    }
}
