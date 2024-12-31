using hospital.DTO;
using hospital.Repo.AppointmentRepo;
using Microsoft.AspNetCore.Mvc;

namespace hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointment repo;

        public AppointmentController(IAppointment repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public IActionResult Getbyid(int id)
        {
            return Ok(repo.GetbyId(id));
        }
        [HttpPost]
        public IActionResult Add(AppointmentDTO date)
        {
            repo.Add(date);
            return Created();
        }
        [HttpPut]
        public IActionResult update(AppointmentDTO date, int id)
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
