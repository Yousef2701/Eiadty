using AutoMapper;
using Medical.Core.Dtos;
using Medical.Core.Interfaces;
using Medical.EF.Models;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugsController : ControllerBase
    {

        #region Dependancey injuction

        private readonly IDrugPerository _drugsRepository;
        private readonly IMapper _mapper;

        public DrugsController(IDrugPerository drugsRepository, IMapper mapper)
        {
            _drugsRepository = drugsRepository;
            _mapper = mapper;
        }

        #endregion


        #region Add Drug

        [HttpPost("AddDrug")]
        public async Task<IActionResult> AddDrug([FromBody] DrugDto dto)
        {
            return Ok(await _drugsRepository.CreateAsync(_mapper.Map<Drug>(dto)));
        }

        #endregion

        #region Get All Patient Drugs

        [HttpGet("GetAllPatientDrugs")]
        public async Task<IActionResult> GetAllPatientDrugs(string patientPhone)
        {
            return Ok(await _drugsRepository.GetAllPatientDrugs(patientPhone));
        }

        #endregion

        #region Delete Drug

        [HttpDelete("DeleteDrug")]
        public async Task<IActionResult> DeleteDrug(string Patient_Phone, string Drug_Name)
        {
            DrugDto dto = new DrugDto
            {
                Patient_Phone = Patient_Phone,
                Drug_Name = Drug_Name
            };
            return Ok(await _drugsRepository.DeleteDrug(dto));
        }

        #endregion

    }
}
