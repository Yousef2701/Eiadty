using Medical.Core.Dtos;
using Medical.Core.Models;
using Medical.EF;

namespace Medical.Core.Interfaces
{
    public interface IDoctorRepository
    {
        public Task<AuthModel> AddDoctorAsync(DoctorDto doctor);

        public Task<IEnumerable<Doctor>> GetAllClinicDoctors(string clinicName);

        public Task<double> GetDoctorCheckPrice(string doctorPhone,string checkType);

        public Task<string> GetDoctorName(string doctorPhone);

        public Task<IEnumerable<DoctorDto>> GetAllDoctors();
    }
}
