using Medical.Core.Dtos;
using Medical.EF.Models;

namespace Medical.Core.Interfaces
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task<IEnumerable<DoctorBooksDto>> GetAllDoctorBooksAsync(string Doctor_Phone);

        Task<IEnumerable<DoctorBooksDto>> GetAllPatientBooksAsync(string Patient_Phone);

        Task<IEnumerable<DoctorBooksDto>> GetAllDoctorBooksInDayAsync(string Doctor_Phone,string Date);
    }
}
