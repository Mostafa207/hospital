using hospital.DTO;

namespace hospital.Repo.AppointmentRepo
{
    public interface IAppointment
    {
        public void Add(AppointmentDTO dto);
        public void Updata(AppointmentDTO dto, int id);
        public void Remove(int id);
        public AppointmentDTO GetbyId(int id);
    }
}
