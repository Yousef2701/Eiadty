﻿using AutoMapper;
using Medical.Core.Dtos;
using Medical.Core.Interfaces;
using Medical.EF.Models;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChecksController : ControllerBase
    {

        #region Dependancey injuction

        private readonly ICheckRepository _checkRepository;
        private readonly IMapper _mapper;

        public ChecksController(ICheckRepository checkRepository,
                                IMapper mapper)
        {
            _checkRepository = checkRepository;
            _mapper = mapper;
        }

        #endregion


        #region Create New Check

        [HttpPost("AddCheckInformation")]
        public async Task<IActionResult> CreateNewCheck([FromBody] AddCheckDto dto)
        {
            return Ok(await _checkRepository.CreateAsync(_mapper.Map<Check>(dto)));
        }

        #endregion

        #region Get All Doctor Checks

        [HttpGet("GetAllDoctorChecks")]
        public async Task<IActionResult> GetAllDoctorChecks(string doctorPhone)
        {
            return Ok(await _checkRepository.GetAllDoctorChecks(doctorPhone));
        }

        #endregion

        #region Get All Patient Checks

        [HttpGet("GetAllPatientChecks")]
        public async Task<IActionResult> GetAllPatientChecks(string patientPhone)
        {
            return Ok(await _checkRepository.GetAllPatientChecks(patientPhone));
        }

        #endregion

        #region Get All Patient Doctor Check

        [HttpGet("GetAllPatientDoctorCheck")]
        public async Task<IActionResult> GetAllPatientDoctorCheck(string patientPhone, string doctorPhone)
        {
            return Ok(await _checkRepository.GetAllPatientDoctorCheck(patientPhone, doctorPhone));
        }

        #endregion

        #region Get Check By Numbre

        [HttpGet("GetCheckByNumbre")]
        public async Task<IActionResult> GetCheckByNumbre(int num)
        {
            return Ok(await _checkRepository.GetCheckByNumbre(num));
        }

        #endregion

    }
}
