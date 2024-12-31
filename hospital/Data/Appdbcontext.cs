using hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace hospital.Data
{
    public class Appdbcontext : DbContext
    {
        public Appdbcontext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Medicine> Medicine { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
    }
}
