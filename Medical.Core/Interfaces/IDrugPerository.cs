using Medical.Core.Dtos;
using Medical.EF.Models;

namespace Medical.Core.Interfaces
{
    public interface IDrugPerository : IBaseRepository<Drug>
    {
        public Task<IEnumerable<Drug>> GetAllPatientDrugs(string patientPhone);

        public Task<string> DeleteDrug(DrugDto dto);
    }
}
