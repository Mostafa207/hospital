using hospital.DTO;
using hospital.Repo.AppointmentRepo;
using hospital.Repo.PatientRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatient repo;

        public PatientController(IPatient repo)
        {
            this.repo = repo;
        }
        [HttpGet("{id}")]
        public IActionResult Getbyid(int id)
        {
            return Ok(repo.GetbyId(id));
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(repo.GetAll());
        }

        [HttpPost]
        public IActionResult Add(PatientDTO_date date)
        {
            repo.Add(date);
            return Created();
        }
        [HttpPut]
        public IActionResult update(PatientDTO_date date, int id)
        {
            repo.Updata(date, id);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            repo.Remove(id);
            return Ok();
        }
    }
}
