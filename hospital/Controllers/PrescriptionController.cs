using hospital.DTO;
using hospital.Repo.PatientRepo;
using hospital.Repo.PrescriptionsRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescription repo;

        public PrescriptionController(IPrescription repo)
        {
            this.repo = repo;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(repo.GetAll());
        }

        [HttpPost]
        public IActionResult Add(PrescriptionDTO date)
        {
            repo.Add(date);
            return Created();
        }
       
       
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            repo.Remove(id);
            return Ok();
        }
    }
}
