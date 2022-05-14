using AutoMapper;
using MediatR;
using Vulder.School.Form.Core.Models;
using Vulder.School.Form.Core.ProjectAggregate.Form.Dtos;
using Vulder.School.Form.Infrastructure.Database.Interfaces;

namespace Vulder.School.Form.Application.Form.GetSchoolForms;

public class GetSchoolFormsRequestHandler : IRequestHandler<SchoolFormCollectionModel, FormsDto>
{
    private readonly IFormRepository _formRepository;
    private readonly IMapper _mapper;

    public GetSchoolFormsRequestHandler(IFormRepository formRepository, IMapper mapper)
    {
        _formRepository = formRepository;
        _mapper = mapper;
    }

    public async Task<FormsDto> Handle(SchoolFormCollectionModel request, CancellationToken cancellationToken)
    {
        var pages = await _formRepository.GetSchoolFormDocumentsPagesCount();
        var forms = await _formRepository.GetFormList(request.Page);

        return new FormsDto
        {
            Pages = pages,
            Forms = _mapper.Map<List<ShortFormDto>>(forms)
        };
    }
}