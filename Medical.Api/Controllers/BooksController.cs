using AutoMapper;
using Medical.Core.Dtos;
using Medical.Core.Interfaces;
using Medical.EF.Models;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly IBookRepository _booksRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public BooksController(IBookRepository booksRepository,
                               IDoctorRepository doctorRepository,
                               IMapper mapper)
        {
            _booksRepository = booksRepository;
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        [HttpPost("CreateBookAsync")]
        public async Task<IActionResult> CreateBookAsync([FromBody] BookDto dto)
        {          

            var book = new Book
            {
                Doctor_Phone = dto.Doctor_Phone,
                Patient_Phone = dto.Patient_Phone,
                Complaint = dto.Complaint,
                Date = dto.Date,
                Time = dto.Time.Substring(0,5),
                Am_Pm = dto.Time.Substring(5,2),
                Book_Type = dto.Book_Type,
                price = await _doctorRepository.GetDoctorCheckPrice(dto.Doctor_Phone,dto.Book_Type)
            };

            return Ok(await _booksRepository.CreateAsync(book));
        }

        [HttpGet("GetAllDoctorBooks")]
        public async Task<IActionResult> GetAllDoctorBooks(string phone)
        {
            return Ok(await _booksRepository.GetAllDoctorBooksAsync(phone));
        }

        [HttpGet("GetAllPatientBooks")]
        public async Task<IActionResult> GetAllPatientBooks(string patient_Phone)
        {
            return Ok(await _booksRepository.GetAllPatientBooksAsync(patient_Phone));
        }

        [HttpGet("GetAllDoctorBooksInDay")]
        public async Task<IActionResult> GetAllDoctorBooksInDay(string phone)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");

            return Ok(await _booksRepository.GetAllDoctorBooksInDayAsync(phone, date));
        }

        [HttpGet("GetDoctorNameAndTodatDate")]
        public async Task<IActionResult> GetDoctorNameAndTodatDate(string phone)
        {
            return Ok(await _doctorRepository.GetDoctorName(phone));
        }
    }
}
