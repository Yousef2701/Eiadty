using Medical.Core.Dtos;
using Medical.Core.Interfaces;
using Medical.EF.Data;
using Medical.EF.Models;
using Medical.EF.Repositories;

namespace Medical.Core.Repositories
{
    public class CheckRepository : BaseRepository<Check>, ICheckRepository
    {

        #region Dependancey injuction

        public CheckRepository(ApplicationDbContext context) : base(context)
        {
        }

        #endregion


        #region Get All Doctor Checks

        public async Task<IEnumerable<CheckDto>> GetAllDoctorChecks(string DoctorPhone)
        {
            var checks = _context.Checks.Where(m => m.Doctor_Phone == DoctorPhone).OrderBy(m => m.Date).ThenBy(m => m.Am_Pm).ThenBy(m => m.Time).ToList();
            List<CheckDto> allChecks = new List<CheckDto>();

            foreach (Check item in checks)
            {
                var ch = new CheckDto
                {
                    Book_Numbre = item.Book_Numbre,
                    Complaint = item.Complaint,
                    Doctor_Phone = item.Doctor_Phone,
                    Doctor_Name = _context.Doctors.Where(m => m.Phone == item.Doctor_Phone).Select(m => m.Name).FirstOrDefault(),
                    clinic = _context.Doctors.Where(m => m.Phone == item.Doctor_Phone).Select(m => m.Department).FirstOrDefault(),
                    Patient_Phone = item.Patient_Phone,
                    Patient_Name = _context.Patients.Where(m => m.Phone == item.Patient_Phone).Select(m => m.FName).FirstOrDefault() + " " + _context.Patients.Where(m => m.Phone == item.Patient_Phone).Select(m => m.LName).FirstOrDefault(),
                    Date = item.Date,
                    Time = item.Time,
                    Am_Pm = item.Am_Pm,
                    Diagnosis = item.Diagnosis,
                    DrugListUrl = item.DrugListUrl,
                    RayListUrl = item.RayListUrl,
                    AnalysistListUrl = item.AnalysistListUrl
                };

                allChecks.Add(ch);
            }

            return allChecks;
        }

        #endregion

        #region Get All Patient Checks

        public async Task<IEnumerable<CheckDto>> GetAllPatientChecks(string patientPhone)
        {
            var checks = _context.Checks.Where(m => m.Patient_Phone == patientPhone).OrderBy(m => m.Date).ThenBy(m => m.Am_Pm).ThenBy(m => m.Time).ToList();

            List<CheckDto> allChecks = new List<CheckDto>();

            foreach (Check item in checks)
            {
                var ch = new CheckDto
                {
                    Book_Numbre = item.Book_Numbre,
                    Complaint = item.Complaint,
                    Doctor_Phone = item.Doctor_Phone,
                    Doctor_Name = _context.Doctors.Where(m => m.Phone == item.Doctor_Phone).Select(m => m.Name).FirstOrDefault(),
                    clinic = _context.Doctors.Where(m => m.Phone == item.Doctor_Phone).Select(m => m.Department).FirstOrDefault(),
                    Patient_Phone = item.Patient_Phone,
                    Patient_Name = _context.Patients.Where(m => m.Phone == item.Patient_Phone).Select(m => m.FName).FirstOrDefault() + " " + _context.Patients.Where(m => m.Phone == item.Patient_Phone).Select(m => m.LName).FirstOrDefault(),
                    Date = item.Date,
                    Time = item.Time,
                    Am_Pm = item.Am_Pm,
                    Diagnosis = item.Diagnosis,
                    DrugListUrl = item.DrugListUrl,
                    RayListUrl = item.RayListUrl,
                    AnalysistListUrl = item.AnalysistListUrl
                };

                allChecks.Add(ch);
            }

            return allChecks;
        }

        #endregion

        #region Get All Patient Doctor Check

        public async Task<IEnumerable<CheckDto>> GetAllPatientDoctorCheck(string patientPhone, string DoctorPhone)
        {
            var checks = _context.Checks.Where(m => m.Doctor_Phone == DoctorPhone & m.Patient_Phone == patientPhone).OrderBy(m => m.Date).ThenBy(m => m.Am_Pm).ThenBy(m => m.Time).ToList();

            List<CheckDto> allChecks = new List<CheckDto>();

            foreach (Check item in checks)
            {
                var ch = new CheckDto
                {
                    Book_Numbre = item.Book_Numbre,
                    Complaint = item.Complaint,
                    Doctor_Phone = item.Doctor_Phone,
                    Doctor_Name = _context.Doctors.Where(m => m.Phone == item.Doctor_Phone).Select(m => m.Name).FirstOrDefault(),
                    clinic = _context.Doctors.Where(m => m.Phone == item.Doctor_Phone).Select(m => m.Department).FirstOrDefault(),
                    Patient_Phone = item.Patient_Phone,
                    Patient_Name = _context.Patients.Where(m => m.Phone == item.Patient_Phone).Select(m => m.FName).FirstOrDefault() + " " + _context.Patients.Where(m => m.Phone == item.Patient_Phone).Select(m => m.LName).FirstOrDefault(),
                    Date = item.Date,
                    Time = item.Time,
                    Am_Pm = item.Am_Pm,
                    Diagnosis = item.Diagnosis,
                    DrugListUrl = item.DrugListUrl,
                    RayListUrl = item.RayListUrl,
                    AnalysistListUrl = item.AnalysistListUrl
                };

                allChecks.Add(ch);
            }

            return allChecks;
        }

        #endregion

        #region Get Check By Numbre

        public async Task<Check> GetCheckByNumbre(int numbre)
        {
            var check = _context.Checks.Find(numbre);

            return check;
        }

        #endregion

    }
}
