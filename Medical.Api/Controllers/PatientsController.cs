using AutoMapper;
using Medical.Core.Dtos;
using Medical.Core.Interfaces;
using Medical.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IBaseRepository<Patient> _patientsRepository;
        private readonly IMapper _mapper;

        public PatientsController(IBaseRepository<Patient> patientsRepository,
                                  IMapper mapper)
        {
            _patientsRepository = patientsRepository;
            _mapper = mapper;
        }

        [HttpGet("GetPatientById")]
        public async Task<IActionResult> GetById(string phone)
        {
            var patient = await _patientsRepository.GetByIdAsync(phone);

            if (patient == null) 
                return NotFound("This Patient is not Found!");

            var dto = _mapper.Map<PatientDto>(patient);

            return Ok(dto);
        }

        [HttpGet("GetAllPatients")]
        public async Task<IActionResult> GetAll()
        {
            var patients = await _patientsRepository.GetAllAsync();
            var dto = _mapper.Map<IEnumerable<PatientDto>>(patients);

            return Ok(dto);
        }
    }
}
