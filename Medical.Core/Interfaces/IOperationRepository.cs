using Medical.Core.Dtos;
using Medical.EF.Models;

namespace Medical.Core.Interfaces
{
    public interface IOperationRepository : IBaseRepository<Operation>
    {
        public Task<IEnumerable<Operation>> GetAllPatientOperation(string patientPhone);

        public Task<string> DeleteOperation(OperationDto dto);
    }
}
