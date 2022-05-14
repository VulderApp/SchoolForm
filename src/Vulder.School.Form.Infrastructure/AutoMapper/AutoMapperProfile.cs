using AutoMapper;
using Vulder.School.Form.Core.Models;
using Vulder.School.Form.Core.ProjectAggregate.Form.Dtos;

namespace Vulder.School.Form.Infrastructure.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<SchoolFormModel, Core.ProjectAggregate.Form.Form>()
            .ForMember(dest => dest.RequesterEmail, opt => opt.MapFrom(src => src.Email));
        CreateMap<Core.ProjectAggregate.Form.Form, ShortFormDto>();
    }
}