using AutoMapper;
using Medical.Core.Dtos;
using Medical.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Operation = Medical.EF.Models.Operation;

namespace Medical.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {

        #region Dependancey injuction

        private readonly IOperationRepository _operationRepository;
        private readonly IMapper _mapper;

        public OperationsController(IOperationRepository operationRepository, IMapper mapper)
        {
            _operationRepository = operationRepository;
            _mapper = mapper;
        }

        #endregion


        #region Add Operation

        [HttpPost("AddOperation")]
        public async Task<IActionResult> AddOperation([FromBody] OperationDto dto)
        {
            return Ok(await _operationRepository.CreateAsync(_mapper.Map<Operation>(dto)));
        }

        #endregion

        #region Get All Patient Operations

        [HttpGet("GetAllPatientOperations")]
        public async Task<IActionResult> GetAllPatientOperations(string patientPhone)
        {
            return Ok(await _operationRepository.GetAllPatientOperation(patientPhone));
        }

        #endregion

        #region Delete Operation

        [HttpDelete("DeleteOperation")]
        public async Task<IActionResult> DeleteOperation(string Patient_Phone, string Operation_Name)
        {
            OperationDto dto = new OperationDto
            {
                Patient_Phone = Patient_Phone,
                Operation_Name = Operation_Name
            };
            return Ok(await _operationRepository.DeleteOperation(dto));
        }

        #endregion

    }
}
