using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vulder.School.Form.Core.Models;

namespace Vulder.School.Form.Api.Controllers.Form;

[ApiController]
[Route("/form/[controller]")]
public class SubmitSchoolFormController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public SubmitSchoolFormController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> SubmitSchoolForm([FromBody] SchoolFormModel schoolFormModel)
    {
        await _mediator.Send(
            _mapper.Map<Core.ProjectAggregate.Form.Form>(schoolFormModel)
            );

        return Ok();
    }
}