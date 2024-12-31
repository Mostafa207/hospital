using hospital.Data;
using hospital.DTO;
using hospital.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace hospital.Repo.AppointmentRepo
{
    public class AppointmentR : IAppointment
    {
        private readonly Appdbcontext context;
        public AppointmentR(Appdbcontext context)
        {
            this.context = context;
        }
        public void Add(AppointmentDTO dto)
        {
            Appointment appointment = new Appointment
            {
                Date = dto.Date,
                doctor = new Doctor
                {
                    Name = dto.doctor.Name,
                    Email = dto.doctor.Email,
                    Password = dto.doctor.Password,
                    Phone = dto.doctor.Phone,
                    Address = dto.doctor.Address,
                },
                patient = new Patient
                {

                    Name = dto.patient.Name,
                    Email = dto.patient.Email,
                    phone = dto.patient.phone,
                    Address = dto.patient.Address,
                },
            };
            context.Appointment.Add(appointment);
            context.SaveChanges();
        }

        public AppointmentDTO GetbyId(int id)
        {
            var date = context.Appointment.Include(x => x.patient).Include(x => x.doctor).FirstOrDefault(x => x.Id == id);
            if (date != null)
            {
                AppointmentDTO appointment = new AppointmentDTO
                {
                    Date=date.Date,
                    doctor = new DoctorDTO_date
                    {
                        Name = date.doctor.Name,
                        Email = date.doctor.Email,
                        Password = date.doctor.Password,
                        Phone = date.doctor.Phone,
                        Address = date.doctor.Address,
                    },
                    patient=new PatientDTO_date
                    { 
                    

                        Name = date.patient.Name,
                        Email = date.patient.Email,
                        phone = date.patient.phone,
                        Address = date.patient.Address,
                    },
                    
           
                };
                return (appointment);
            }
            return null;
        }

        public void Remove(int id)
        {
            var date = context.Appointment.FirstOrDefault(x => x.Id == id);
            context.Appointment.Remove(date);
            context.SaveChanges();
        }

        public void Updata(AppointmentDTO dto, int id)
        {
            var date = context.Appointment.FirstOrDefault(x => x.Id == id);
            if (date != null)
            {

                date.Date = dto.Date;
                
                context.Appointment.Update(date);
                context.SaveChanges();
            };

        }

        
    }
}
