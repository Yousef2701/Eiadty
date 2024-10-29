using Medical.Core.Dtos;
using Medical.Core.Interfaces;
using Medical.EF.Data;
using Medical.EF.Models;
using Medical.EF.Repositories;

namespace Medical.Core.Repositories
{
    public class DiseasesRepository : BaseRepository<Diseases>, IDiseasesRepository
    {
        public DiseasesRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Diseases>> GetAllPatientDiseases(string patientPhone)
        {
            var diseases = _context.Diseases.Where(m => m.Patient_Phone == patientPhone).ToList();

            return diseases;
        }

        public async Task<string> DeleteDiseases(DiseasesDto dto)
        {
            var check = _context.Diseases.Where(m => m.Diseases_Name == dto.Diseases_Name & m.Patient_Phone == dto.Patient_Phone).FirstOrDefault();
            if (check != null)
            {
                _context.Diseases.Remove(check);
                _context.SaveChanges();

                return "Success";
            }
            else
                return "Diseases Not Found";
        }
    }
}
