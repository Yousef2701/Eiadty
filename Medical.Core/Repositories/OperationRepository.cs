using Medical.Core.Dtos;
using Medical.Core.Interfaces;
using Medical.EF.Data;
using Medical.EF.Models;
using Medical.EF.Repositories;

namespace Medical.Core.Repositories
{
    public class OperationRepository : BaseRepository<Operation>, IOperationRepository
    {

        #region Dependancey injuction

        public OperationRepository(ApplicationDbContext context) : base(context)
        {
        }

        #endregion


        #region Get All Patient Operation

        public async Task<IEnumerable<Operation>> GetAllPatientOperation(string patientPhone)
        {
            var operations = _context.Operations.Where(m => m.Patient_Phone == patientPhone).ToList();

            return operations;
        }

        #endregion

        #region Delete Operation

        public async Task<string> DeleteOperation(OperationDto dto)
        {
            var check = _context.Operations.Where(m => m.Operation_Name == dto.Operation_Name & m.Patient_Phone == dto.Patient_Phone).FirstOrDefault();
            if (check != null)
            {
                _context.Operations.Remove(check);
                _context.SaveChanges();

                return "Success";
            }
            else
                return "Operation Not Found";
        }

        #endregion

    }
}
