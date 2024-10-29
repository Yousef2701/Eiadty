using AutoMapper;
using Medical.Core.Dtos;
using Medical.Core.Models;
using Medical.EF.Models;

namespace Medical.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Doctor, DoctorDto>().ReverseMap();

            CreateMap<Patient, PatientDto>().ReverseMap();

            CreateMap<Post, PostDto>().ReverseMap();

            CreateMap<Post, GetPostDto>().ReverseMap();

            CreateMap<Post, PostWithoutDoctorDto>().ReverseMap();

            CreateMap<Comment, CommentDto>().ReverseMap();

            CreateMap<PatientDto, RegisterDTO>().ReverseMap();

            CreateMap<DoctorDto, RegisterDTO>().ReverseMap();

            CreateMap<Book, BookDto>().ReverseMap();

            CreateMap<Check, CheckDto>().ReverseMap();

            CreateMap<Check, AddCheckDto>().ReverseMap();

            CreateMap<Drug, DrugDto>().ReverseMap();

            CreateMap<Diseases, DiseasesDto>().ReverseMap();

            CreateMap<Operation, OperationDto>().ReverseMap();

            CreateMap<AdminRegisterDto, RegisterDTO>().ReverseMap();
        }

    }
}
