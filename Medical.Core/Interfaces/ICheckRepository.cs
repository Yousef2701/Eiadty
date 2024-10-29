using Medical.Core.Dtos;
using Medical.EF.Models;

namespace Medical.Core.Interfaces
{
    public interface ICheckRepository : IBaseRepository<Check>
    {
        public Task<Check> GetCheckByNumbre(int numbre);

        public Task<IEnumerable<CheckDto>> GetAllPatientChecks(string patientPhone);

        public Task<IEnumerable<CheckDto>> GetAllDoctorChecks(string DoctorPhone);

        public Task<IEnumerable<CheckDto>> GetAllPatientDoctorCheck(string patientPhone , string DoctorPhone);
    }
}
