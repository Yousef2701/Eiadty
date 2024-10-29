using AutoMapper;
using Medical.Core.Dtos;
using Medical.Core.Interfaces;
using Medical.EF.Models;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseasesController : ControllerBase
    {
        private readonly IDiseasesRepository _diseasesRepository;
        private readonly IMapper _mapper;

        public DiseasesController(IDiseasesRepository diseasesRepository, IMapper mapper)
        {
            _diseasesRepository = diseasesRepository;
            _mapper = mapper;
        }

        [HttpPost("AddDiseases")]
        public async Task<IActionResult> AddDiseases([FromBody] DiseasesDto dto)
        {
            return Ok(await _diseasesRepository.CreateAsync(_mapper.Map<Diseases>(dto)));
        }

        [HttpGet("GetAllPatientDiseases")]
        public async Task<IActionResult> GetAllPatientDiseases(string patientPhone)
        {
            return Ok(await _diseasesRepository.GetAllPatientDiseases(patientPhone));
        }

        [HttpDelete("DeleteDiseases")]
        public async Task<IActionResult> DeleteDiseases(string Patient_Phone, string Diseases_Name)
        {
            DiseasesDto dto = new DiseasesDto
            {
                Patient_Phone = Patient_Phone,
                Diseases_Name = Diseases_Name
            };
            return Ok(await _diseasesRepository.DeleteDiseases(dto));
        }

    }
}
