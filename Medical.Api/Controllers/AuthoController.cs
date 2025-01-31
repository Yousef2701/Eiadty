using AutoMapper;
using Medical.Core.Dtos;
using Medical.Core.Interfaces;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthoController : ControllerBase
    {

        #region Dependancey injuction

        private readonly IAuthoRepository _authoRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;
        private readonly IDataProtector _dataProtector;

        public AuthoController(IAuthoRepository authoRepository,
                               IMapper mapper,
                               IPatientRepository patientRepository,
                               IDoctorRepository doctorRepository,
                               IDataProtectionProvider dataProtectionProvider)
        {
            _authoRepository = authoRepository;
            _mapper = mapper;
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
            _dataProtector = dataProtectionProvider.CreateProtector("SecureCoding");
        }

        #endregion


        #region Patient Register Async

        [HttpPost("PatientRsegister")]
        public async Task<IActionResult> PatientRegisterAsync([FromBody] PatientDto patient)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = _mapper.Map<RegisterDTO>(patient);
            var register = await _authoRepository.RegisterAsync(model, "Patient");
            if (!register.IsAuthenticated)
                return BadRequest(register.Message);

            var result = await _patientRepository.AddPatientAsync(patient);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(new { phone = result.Phone, role = "Patient", token = result.Token });
        }

        #endregion

        #region Doctor Register Async

        [HttpPost("DoctorRegister")]
        public async Task<IActionResult> DoctorRegisterAsync([FromForm] DoctorDto doctor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = _mapper.Map<RegisterDTO>(doctor);
            var register = await _authoRepository.RegisterAsync(model, "Doctor");
            if (!register.IsAuthenticated)
                return BadRequest(register.Message);

            var result = await _doctorRepository.AddDoctorAsync(doctor);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(new { phone = result.Phone, role = "Doctor", token = result.Token });
        }

        #endregion

        #region Admin Register Async

        [HttpPost("AdminRegister")]
        public async Task<IActionResult> AdminRegisterAsync([FromBody] AdminRegisterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = _mapper.Map<RegisterDTO>(dto);
            var register = await _authoRepository.RegisterAsync(model, "Admin");
            if (!register.IsAuthenticated)
                return BadRequest(register.Message);


            return Ok("Success!");
        }

        #endregion

        #region Append Account

        [HttpPost("AppendAccount")]
        public async Task<IActionResult> AppendAccount([FromBody] AppentAccountDto dto)
        {
            return Ok(await _authoRepository.AppendAccount(dto.phone));
        }

        #endregion

        #region Activate Account

        [HttpPost("ActivateAccount")]
        public async Task<IActionResult> ActivateAccount([FromBody] AppentAccountDto dto)
        {
            return Ok(await _authoRepository.ActivateAccount(dto.phone));
        }

        #endregion

        #region Is Account Active

        [HttpPost("IsAccountActive")]
        public async Task<IActionResult> IsAccountActive([FromBody] AppentAccountDto dto)
        {
            return Ok(await _authoRepository.IsAccountAvtive(dto.phone));
        }

        #endregion

        #region LogIn Async

        [HttpPost("LogIn")]
        public async Task<IActionResult> LogInAsync([FromBody] LogInDTO user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authoRepository.GetTokenAsync(user);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            string role = await _authoRepository.GetRole(user.Phone);

            if (!string.IsNullOrEmpty(result.RefreshToken))
                SetRefreshTokenCookie(result.RefreshToken, result.RefreshTokenExpiration);

            //return Ok(result);
            //return Ok(new { phone = result.Phone, role = role, token = result.Token, RefreshToken = result.RefreshToken });
            return Ok(new { phone = result.Phone, role = role, token = result.Token });
        }

        #endregion

        #region LogOut

        [HttpPost("RevokeToken")]
        public async Task<IActionResult> LogOut([FromBody] RevokeDto model)
        {
            var token = model.Token ?? Request.Cookies[key: "refreshToken"];
            if (string.IsNullOrEmpty(token))
                return BadRequest("Token is required");

            var result = await _authoRepository.RevokeTokenAsync(token);
            if (!result)
                return BadRequest("Token is Invalid");

            return Ok("loged out success");
        }

        #endregion

        #region Set Refresh Token Cookie

        private void SetRefreshTokenCookie(string refreshToken, DateTime expires)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = expires.ToLocalTime()
            };

            Response.Cookies.Append(key: "refreshToken", refreshToken, cookieOptions);

        }

        #endregion

    }
}
