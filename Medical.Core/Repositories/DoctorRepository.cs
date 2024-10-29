using AutoMapper;
using Medical.Core.Dtos;
using Medical.Core.Interfaces;
using Medical.Core.Models;
using Medical.EF;
using Medical.EF.Data;
using System.IdentityModel.Tokens.Jwt;


namespace Medical.Core.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IAuthoRepository _authoRepository;
        private readonly IMapper _mapper;
        private readonly IImageRepository _imageRepository;

        public DoctorRepository(ApplicationDbContext context,
                               IAuthoRepository authoRepository,
                               IMapper mapper,
                               IImageRepository imageRepository)
        {
            _context = context;
            _authoRepository = authoRepository;
            _mapper = mapper;
            _imageRepository = imageRepository;
        }

        public async Task<AuthModel> AddDoctorAsync(DoctorDto doctor)
        {
            var authModel = new AuthModel();
            if (doctor is null)
            {
                var deleted = await DeleteUser(doctor.Phone);
                if (deleted != "ok")
                { authModel.Message = deleted; }
                authModel.Message = authModel.Message + " Please Insert Data to be Add";
                return authModel;
            }
            var user = _context.Users.Where(x => x.PhoneNumber == doctor.Phone).FirstOrDefault();
            if (user is null)
            {
                var deleted = await DeleteUser(doctor.Phone);
                if (deleted != "ok")
                { authModel.Message = deleted; }
                authModel.Message = authModel.Message + " Wrong Phone number";
                return authModel;
            }
            var imageUrl =await _imageRepository.AddImageAsync(doctor.image, doctor.Phone, "UsersImages");
            var newDoctor = _mapper.Map<Doctor>(doctor);
            newDoctor.ImageUrl = imageUrl;
            var jwtSecurityToken = await _authoRepository.CreateJwtToken(user);
            if (jwtSecurityToken is null)
            {
                var deleted = await DeleteUser(doctor.Phone);
                if (deleted != "ok")
                { authModel.Message = deleted; }
                authModel.Message = authModel.Message + " Token didn't been created";
                return authModel;
            }
            _context.Doctors.Add(newDoctor);
            _context.SaveChanges();
            return new AuthModel
            {
                Phone = user.PhoneNumber,
                //Expiration = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Role = "Doctor",
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Message = "Token Created Succesfully"
            };
        }

        private async Task<string> DeleteUser(string phone)
        {
            var user = await _authoRepository.GetUser(phone);
            if (user is null)
                return "phone number not found";
            var deleted = await _authoRepository.DeleteUser(user);
            if (deleted != "ok")
                return "can't delete this account";
            return deleted;

        }

        public async Task<IEnumerable<Doctor>> GetAllClinicDoctors(string clinicName)
        {
            var doctors = _context.Doctors.Where(m => m.Department == clinicName).ToList();

            return doctors;
        }

        public async Task<IEnumerable<DoctorDto>> GetAllDoctors()
        {
            var doctors = _context.Doctors.ToList();
            List<DoctorDto> all = new List<DoctorDto>(); 

            foreach(var doctor in doctors)
            {
                bool check = _context.Users.Where(m => m.PhoneNumber == doctor.Phone).Select(m => m.EmailConfirmed).SingleOrDefault();

                var doc = new DoctorDto
                {
                    Phone = doctor.Phone,
                    Name = doctor.Name,
                    Governrate = doctor.Governrate,
                    City = doctor.City,
                    Adreess = doctor.Adreess,
                    Department = doctor.Department,
                    ScienceDegree = doctor.ScienceDegree,
                    FromDay = doctor.FromDay,
                    ToDay = doctor.ToDay,
                    FromHour = doctor.FromHour,
                    ToHour = doctor.ToHour,
                    NewCheckPrie = doctor.NewCheckPrie,
                    ReCheckPrie = doctor.ReCheckPrie,
                    IsActive = check
                };

                all.Add(doc);
            }

            return all;
        }

        public async Task<double> GetDoctorCheckPrice(string doctorPhone, string checkType)
        {
            if(checkType == "newCheck")
                return _context.Doctors.Where(m => m.Phone == doctorPhone).Select(m => m.NewCheckPrie).FirstOrDefault();
            else
                return _context.Doctors.Where(m => m.Phone == doctorPhone).Select(m => m.ReCheckPrie).FirstOrDefault();
        }

        public async Task<string> GetDoctorName(string doctorPhone)
        {
            return _context.Doctors.Where(m => m.Phone == doctorPhone).Select(m => m.Name).FirstOrDefault() +" - "+ DateTime.Now.ToString("yyyy-MM-dd"); ; 
        }
    }
}
