using Medical.Core.Interfaces;
using Medical.EF.Models;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicsController : ControllerBase
    {

        #region Dependancey injuction

        private readonly IBaseRepository<Clinic> _clinicsRepository;

        public ClinicsController(IBaseRepository<Clinic> clinicsRepository)
        {
            _clinicsRepository = clinicsRepository;
        }

        #endregion


        #region Git Clinics

        [HttpGet("GitClinics")]
        public async Task<IActionResult> GitClinics()
        {
            return Ok(await _clinicsRepository.GetAllAsync());
        }

        #endregion

    }
}
