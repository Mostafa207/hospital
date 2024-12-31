using hospital.Data;
using hospital.DTO;
using hospital.Models;
using Microsoft.EntityFrameworkCore;
using System;


namespace hospital.Repo.DoctorRepo
{
    public class DoctorR : IDoctor
    {
        private readonly Appdbcontext context;
        public DoctorR(Appdbcontext context)
        {
            this.context = context;
        }
        public void Add(DoctorDTO_date doctordto)
        {
            Doctor doctor = new Doctor
            {
                Name = doctordto.Name,
                Email = doctordto.Email,
                Password = doctordto.Password,
                Phone = doctordto.Phone,
                Address = doctordto.Address,
                

            };
            context.Doctor.Add(doctor);
            context.SaveChanges();
        }

        public IEnumerable<object> GETall()
        {
            return context.Doctor.Include(x=>x.appointments).ThenInclude(x=>x.patient).Select(x=> new
            {
                
                    Name = x.Name,
                    Email = x.Email,
                    Password = x.Password,
                    Phone = x.Phone,
                    Address = x.Address,
                    appointments = x.appointments.Select(x => new 
                    {
                        Date = x.Date,
                        patient = new 
                        {
                            Name = x.patient.Name,
                            Email = x.patient.Email,
                            Address = x.patient.Address,
                            phone = x.patient.phone


                        }
                    }).ToList(),


            }).ToList();
        }

        public void Update(DoctorDTO_date doctordto,int id)
        {
            var date = context.Doctor.FirstOrDefault(c => c.Id == id);
            if (date != null)
            {
                date.Name = doctordto.Name;
                date.Email = doctordto.Email;
                date.Password = doctordto.Password;
                date.Phone = doctordto.Phone;
                date.Address = doctordto.Address;
                
                context.Doctor.Update(date);
                context.SaveChanges();
            };
        }
    }
}
