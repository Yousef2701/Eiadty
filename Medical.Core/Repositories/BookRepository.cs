using Medical.Core.Dtos;
using Medical.Core.Interfaces;
using Medical.EF.Data;
using Medical.EF.Models;
using Medical.EF.Repositories;

namespace Medical.Core.Repositories
{
    public class BookRepository : BaseRepository<Book> ,IBookRepository
    {

        public BookRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DoctorBooksDto>> GetAllDoctorBooksAsync(string Doctor_Phone)
        {
            var books = _context.Books.Where(m => m.Doctor_Phone == Doctor_Phone).OrderBy(m => m.Date).ThenBy(m => m.Am_Pm).ThenBy(m => m.Time).ToList();
            List<DoctorBooksDto> docBooks = new List<DoctorBooksDto>();

            foreach (Book item in books)
            {
                var b = new DoctorBooksDto
                {
                    Doctor_Name = _context.Doctors.Where(m => m.Phone == item.Doctor_Phone).Select(m => m.Name).FirstOrDefault(),
                    Patient_Name = _context.Patients.Where(m => m.Phone == item.Patient_Phone).Select(m => m.FName).FirstOrDefault() +" "+ _context.Patients.Where(m => m.Phone == item.Patient_Phone).Select(m => m.LName).FirstOrDefault(),
                    Complaint = item.Complaint,
                    Date = item.Date,
                    Time = item.Time + " " + item.Am_Pm,
                    Book_Type = item.Book_Type,
                    Patient_Phone = item.Patient_Phone,
                    Book_Numbre = item.Numbre.ToString()
                };

                docBooks.Add(b);
            }

            return docBooks;
        }

        public async Task<IEnumerable<DoctorBooksDto>> GetAllPatientBooksAsync(string Patient_Phone)
        {
            var books = _context.Books.Where(m => m.Patient_Phone == Patient_Phone).OrderBy(m => m.Date).ThenBy(m => m.Am_Pm).ThenBy(m => m.Time).ToList();
            List<DoctorBooksDto> docBooks = new List<DoctorBooksDto>();

            foreach (Book item in books)
            {
                var b = new DoctorBooksDto
                {
                    Doctor_Name = _context.Doctors.Where(m => m.Phone == item.Doctor_Phone).Select(m => m.Name).FirstOrDefault(),
                    Patient_Name = _context.Patients.Where(m => m.Phone == item.Patient_Phone).Select(m => m.FName).FirstOrDefault() + " " + _context.Patients.Where(m => m.Phone == item.Patient_Phone).Select(m => m.LName).FirstOrDefault(),
                    Complaint = item.Complaint,
                    Date = item.Date,
                    Time = item.Time + " " + item.Am_Pm,
                    Book_Type = item.Book_Type,
                    Patient_Phone = item.Patient_Phone,
                    Book_Numbre = item.Numbre.ToString()
                };

                docBooks.Add(b);
            }

            return docBooks;
        }

        public async Task<IEnumerable<DoctorBooksDto>> GetAllDoctorBooksInDayAsync(string Doctor_Phone, string Date)
        {
            var books = _context.Books.Where(m => m.Doctor_Phone == Doctor_Phone & m.Date == Date).OrderBy(m => m.Am_Pm).ThenBy(m => m.Time).ToList();
            List<DoctorBooksDto> docBooks = new List<DoctorBooksDto>();

            foreach (Book item in books)
            {
                var b = new DoctorBooksDto
                {
                    Doctor_Name = _context.Doctors.Where(m => m.Phone == item.Doctor_Phone).Select(m => m.Name).FirstOrDefault(),
                    Patient_Name = _context.Patients.Where(m => m.Phone == item.Patient_Phone).Select(m => m.FName).FirstOrDefault() + " " + _context.Patients.Where(m => m.Phone == item.Patient_Phone).Select(m => m.LName).FirstOrDefault(),
                    Complaint = item.Complaint,
                    Date = item.Date,
                    Time = item.Time + " " + item.Am_Pm,
                    Book_Type = item.Book_Type,
                    Patient_Phone = item.Patient_Phone,
                    Book_Numbre = item.Numbre.ToString()
                };

                docBooks.Add(b);
            }

            return docBooks;
        }
    }
}
