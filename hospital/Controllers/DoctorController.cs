using hospital.DTO;
using hospital.Repo.DoctorRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctor repo;

        public DoctorController(IDoctor repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(repo.GETall());
        }
        [HttpPost]
        public IActionResult Add(DoctorDTO_date date)
        {
            repo.Add(date);
            return Created();
        }
        [HttpPut]
        public IActionResult update(DoctorDTO_date date, int id)
        {
            repo.Update(date, id);
            return Ok();
        }
       
    }
}
