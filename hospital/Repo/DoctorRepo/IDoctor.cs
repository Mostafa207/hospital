using hospital.DTO;

namespace hospital.Repo.DoctorRepo
{
    public interface IDoctor
    {
        IEnumerable<object> GETall();

        public void Add(DoctorDTO_date doctordto);

        public void Update(DoctorDTO_date doctordto, int id);
    }
}
