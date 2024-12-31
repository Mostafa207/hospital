using hospital.DTO;

namespace hospital.Repo.PrescriptionsRepo
{
    public interface IPrescription
    {
        public void Add(PrescriptionDTO dto);
        
        public void Remove(int id);
        
        IEnumerable<object> GetAll();
    }
}
