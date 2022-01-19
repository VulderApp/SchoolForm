using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vulder.School.Form.Core.Models;
using Vulder.School.Form.Core.ProjectAggregate.Form.Dtos;

namespace Vulder.School.Form.Api.Controllers.Form;

[Authorize]
[ApiController]
[Route("/form/[controller]")]
public class GetSchoolFormsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public GetSchoolFormsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetSchoolForms([FromQuery] int page = 1)
    {
        var result = await _mediator.Send(new SchoolFormCollectionModel
        {
            Page = page
        });

        return Ok(_mapper.Map<List<ShortFormDto>>(result));
    }
}