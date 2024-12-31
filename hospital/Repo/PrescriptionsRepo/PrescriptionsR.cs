using hospital.Data;
using hospital.DTO;
using hospital.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace hospital.Repo.PrescriptionsRepo
{
    public class PrescriptionsR : IPrescription
    {
        private readonly Appdbcontext context;
        public PrescriptionsR(Appdbcontext context)
        {
            this.context = context;
        }

        public void Add(PrescriptionDTO dto)
        {
       
            var date = context.Patient.Find(dto.PatientId);
            if (date != null)
            {
                Prescription prescription = new Prescription
                {
                    Name = dto.Name,
                    PatientId = dto.PatientId,

                };
                context.Prescription.Add(prescription);
                context.SaveChanges();

            }

        }

       
        public IEnumerable<object> GetAll()
        {
            return context.Prescription.Include(x => x.Patient).Select(x => new
            {
                Name = x.Name,
                

            }).ToList();
        }

        public void Remove(int id)
        {
            var date=context.Prescription.FirstOrDefault(x => x.Id == id);  
            if(date != null)
            {
                context.Prescription.Remove(date);
                context.SaveChanges();
            }
        }
    }
}
