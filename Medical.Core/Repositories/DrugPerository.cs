using Medical.Core.Dtos;
using Medical.Core.Interfaces;
using Medical.EF.Data;
using Medical.EF.Models;
using Medical.EF.Repositories;

namespace Medical.Core.Repositories
{
    public class DrugPerository : BaseRepository<Drug>, IDrugPerository
    {
        public DrugPerository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Drug>> GetAllPatientDrugs(string patientPhone)
        {
            var drugs = _context.Drugs.Where(m => m.Patient_Phone == patientPhone).ToList();

            return drugs;
        }

        public async Task<string> DeleteDrug(DrugDto dto)
        {
            var check = _context.Drugs.Where(m => m.Patient_Phone == dto.Patient_Phone & m.Drug_Name == dto.Drug_Name).FirstOrDefault();

            if (check != null)
            {
                _context.Drugs.Remove(check);
                _context.SaveChanges();

                return "Success";
            }
            else
                return "Drug Not Found";
        }
 
    }
}
