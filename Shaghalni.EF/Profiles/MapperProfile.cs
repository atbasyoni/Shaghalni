using AutoMapper;
using Shaghalni.Core.DTOs.Accounts;
using Shaghalni.Core.DTOs.Companies;
using Shaghalni.Core.DTOs.Jobs;
using Shaghalni.Core.Models.Accounts;
using Shaghalni.Core.Models.Companies;
using Shaghalni.Core.Models.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghalni.EF.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CompanyDTO, Company>();

            CreateMap<Job, JobDTO>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name))
                .ForMember(dest => dest.Logo, opt => opt.MapFrom(src => src.Company.Logo))
                .ForMember(dest => dest.JobCityName, opt => opt.MapFrom(src => src.City.Name))
                .ForMember(dest => dest.JobCountryName, opt => opt.MapFrom(src => src.Country.Name))
                .ForMember(dest => dest.JobTypeName, opt => opt.MapFrom(src => src.JobType.Name))
                .ForMember(dest => dest.ViewedApplication, opt => opt.MapFrom(src => src.ViewedApplication ?? 0))
                .ForMember(dest => dest.WithdrawnApplications, opt => opt.MapFrom(src => src.WithdrawnApplications ?? 0))
                .ForMember(dest => dest.AcceptedApplications, opt => opt.MapFrom(src => src.AcceptedApplications ?? 0))
                .ForMember(dest => dest.InConsiderationApplications, opt => opt.MapFrom(src => src.InConsiderationApplications ?? 0))
                .ForMember(dest => dest.RejectedApplications, opt => opt.MapFrom(src => src.RejectedApplications ?? 0))
                .ForMember(dest => dest.TotalApplications, opt => opt.MapFrom(src => src.TotalApplications ?? 0));

            CreateMap<JobDetails, JobDetailsDTO>()
                .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.Job.Title))
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Job.CompanyId))
                .ForMember(dest => dest.SalaryRateName, opt => opt.MapFrom(src => src.SalaryRate.Name))
                .ForMember(dest => dest.CareerLevelName, opt => opt.MapFrom(src => src.CareerLevel.Name))
                .ForMember(dest => dest.EducationLevelName, opt => opt.MapFrom(src => src.EducationLevel.Name))
                .ForMember(dest => dest.JobCategoryName, opt => opt.MapFrom(src => src.JobCategory.Name))
                .ForMember(dest => dest.SalaryCurrencyName, opt => opt.MapFrom(src => src.SalaryCurrency.Name))
                .ForMember(dest => dest.SalaryCurrencySymbol, opt => opt.MapFrom(src => src.SalaryCurrency.Symbol))
                .ForMember(dest => dest.SalaryCurrencyCode, opt => opt.MapFrom(src => src.SalaryCurrency.Code));

            CreateMap<ApplicationUser, RegisterRequestDTO>();
            CreateMap<RegisterRequestDTO, ApplicationUser>();
        }
    }
}
