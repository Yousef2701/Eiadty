using Medical.Core.Dtos;
using Medical.EF.Models;

namespace Medical.Core.Interfaces
{
    public interface IDiseasesRepository : IBaseRepository<Diseases>
    {
        public Task<IEnumerable<Diseases>> GetAllPatientDiseases(string patientPhone);

        public Task<string> DeleteDiseases(DiseasesDto dto);
    }
}
