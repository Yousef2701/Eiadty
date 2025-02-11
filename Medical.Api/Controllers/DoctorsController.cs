﻿using AutoMapper;
using Medical.Core.Dtos;
using Medical.Core.Interfaces;
using Medical.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {

        #region Dependancey injuction

        private readonly IBaseRepository<Doctor> _doctorsRepository;
        private readonly IDoctorRepository _docRepository;
        private readonly IMapper _mapper;

        public DoctorsController(IBaseRepository<Doctor> doctorsRepository,
                                 IDoctorRepository docRepository,
                                 IMapper mapper)
        {
            _doctorsRepository = doctorsRepository;
            _docRepository = docRepository;
            _mapper = mapper;
        }

        #endregion


        #region Get By Id Async

        [HttpGet("GetDoctorById")]
        public async Task<IActionResult> GetByIdAsync(string phone)
        {
            var doctor = await _doctorsRepository.GetByIdAsync(phone);

            if (doctor == null)
                return NotFound("This Doctor is not Found!");

            var dto = _mapper.Map<DoctorDto>(doctor);

            return Ok(dto);
        }

        #endregion

        #region Get All

        [HttpGet("GetAllDoctors")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _docRepository.GetAllDoctors());
        }

        #endregion

        #region Get All Clinic Doctors

        [HttpGet("GetAllClinicDoctors")]
        public async Task<IActionResult> GetAllClinicDoctors(string clinicName)
        {
            var doctors = await _docRepository.GetAllClinicDoctors(clinicName);
            var dto = _mapper.Map<IEnumerable<DoctorDto>>(doctors);

            return Ok(dto);
        }

        #endregion

    }
}
