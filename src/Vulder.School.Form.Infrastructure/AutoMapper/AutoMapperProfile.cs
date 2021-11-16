using AutoMapper;
using Vulder.School.Form.Core.Models;

namespace Vulder.School.Form.Infrastructure.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<SchoolFormModel, Core.ProjectAggregate.Form.Form>();
    }
}