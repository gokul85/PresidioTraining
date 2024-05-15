using DoctorPatient.Exceptions;
using DoctorPatient.Interfaces;
using DoctorPatient.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorPatient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorServices _doctorServices;

        public DoctorController(IDoctorServices doctorServices)
        {
            _doctorServices = doctorServices;
        }

        [HttpGet]
        public async Task<IList<Doctor>> Get()
        {
            var doctors = await _doctorServices.GetDoctors();
            return doctors.ToList();
        }

        [HttpPut]
        public async Task<ActionResult<Doctor>> Put(int id, float experience)
        {
            try
            {
                var doctor = await _doctorServices.UpdateDoctorExperience(id, experience);
                return Ok(doctor);
            }
            catch (NoSuchDoctorFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<Doctor>> Post([FromBody] string specialization)
        {
            try
            {
                var employee = await _doctorServices.GetDoctorBySpecilization(specialization);
                return Ok(employee);
            }
            catch (NoDoctorsFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
