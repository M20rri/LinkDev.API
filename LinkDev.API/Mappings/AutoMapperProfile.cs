using AutoMapper;
using LinkDev.API.Dto;
using LinkDev.API.Models;

namespace LinkDev.API.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Vacancy, VacancyDto>()
           .ForMember(dest => dest.Id, target => target.MapFrom(src => src.Id))
           .ForMember(dest => dest.Name, target => target.MapFrom(src => src.Name))
           .ForMember(dest => dest.Description, target => target.MapFrom(src => src.Description))
           .ForMember(dest => dest.Responsibilities, target => target.MapFrom(src => src.Responsibilities))
           .ForMember(dest => dest.Skills, target => target.MapFrom(src => src.Skills))
           .ForMember(dest => dest.MaxApplicants, target => target.MapFrom(src => src.MaxApplicants))
           .ForMember(dest => dest.ValidFrom, target => target.MapFrom(src => src.ValidFrom))
           .ForMember(dest => dest.ValidTo, target => target.MapFrom(src => src.ValidTo)).ReverseMap();

            CreateMap<Applicant, ApplicantDto>()
           .ForMember(dest => dest.Id, target => target.MapFrom(src => src.Id))
           .ForMember(dest => dest.Name, target => target.MapFrom(src => src.Name))
           .ForMember(dest => dest.Email, target => target.MapFrom(src => src.Email))
           .ForMember(dest => dest.Mobile, target => target.MapFrom(src => src.Mobile)).ReverseMap();


            CreateMap<AppliedVacancy, AppliedVacancyDto>()
           .ForMember(dest => dest.VacancyId, target => target.MapFrom(src => src.VacancyId))
           .ForMember(dest => dest.ApplicantId, target => target.MapFrom(src => src.ApplicantId)).ReverseMap();

        }
    }
}
