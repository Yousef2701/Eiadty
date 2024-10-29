using Medical.Core.Dtos;
using Medical.EF;

namespace Medical.Core.Interfaces
{
    public interface IPatientRepository
    {
        public Task<AuthModel> AddPatientAsync(PatientDto patient);
    }
}
