using hospital.Data;
using hospital.DTO;
using hospital.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace hospital.Repo.PatientRepo
{
    public class PatientR: IPatient
    {
        private readonly Appdbcontext context;
        public PatientR(Appdbcontext context)
        {
            this.context = context;
        }

        public void Add(PatientDTO_date dto)
        {
            Patient date = new Patient
            {
                Name = dto.Name,
                Email = dto.Email,
                phone = dto.phone,
                Address = dto.Address,
                
            };
            context.Patient.Add(date);
            context.SaveChanges();
        }

        public IEnumerable<object> GetAll()
        {
            return context.Patient.Include(x=>x.appointments).ThenInclude(x=>x.doctor).Include(x=>x.prescription).Select(x => new
            {
                Name = x.Name,
                Email = x.Email,
                phone = x.phone,
                Address = x.Address,
                appointments=x.appointments.Select(x => new
                {
                    Date=x.Date,
                    doctor = new
                    {
                        Name = x.doctor.Name,
                        Email = x.doctor.Email,
                        Password = x.doctor.Password,
                        Phone = x.doctor.Phone,
                        Address = x.doctor.Address,
                    }
                    
                }).ToList(),
               
                prescription = new
                {
                    Name = x.prescription.Name,
                }

            }).ToList();
        }

        public PatientDTO GetbyId(int id)
        {
            var date = context.Patient.Include(x => x.appointments).ThenInclude(x => x.doctor).Include(x => x.prescription).FirstOrDefault(x => x.Id == id);
            if (date != null)
            {
                PatientDTO patientDTO = new PatientDTO
                {
                    Name = date.Name,
                    Email = date.Email,
                    phone = date.phone,
                    Address = date.Address,
                    appointments = date.appointments.Select(x => new AppointmentDTO_date
                    {
                        Date = x.Date,
                        doctor = new DoctorDTO_date
                        {
                            Name = x.doctor.Name,
                            Email = x.doctor.Email,
                            Password = x.doctor.Password,
                            Phone = x.doctor.Phone,
                            Address = x.doctor.Address,
                        },
                    }).ToList(),
                    
                    prescription = new PrescriptionDTO_date
                    {
                        Name = date.prescription.Name
                    }

                };
                return (patientDTO);
            }
            throw new Exception("not found");
        }

        public void Remove(int id)
        {
            var date = context.Patient.FirstOrDefault(x => x.Id == id);
            if (date != null)
            {
                context.Patient.Remove(date);
                context.SaveChanges();
            }

        }

        public void Updata(PatientDTO_date dto, int id)
        {
            var date = context.Patient.FirstOrDefault(x => x.Id == id);
            if (date != null)
            {

                date.Name = dto.Name;
                date.Email = dto.Email;
                date.phone= dto.phone;
                date.Address = dto.Address;
                context.Patient.Update(date);
                context.SaveChanges();
            };
        }
    }
}
