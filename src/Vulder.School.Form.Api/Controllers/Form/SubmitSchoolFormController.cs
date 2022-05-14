using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vulder.School.Form.Core;
using Vulder.School.Form.Core.Models;

namespace Vulder.School.Form.Api.Controllers.Form;

[ApiController]
[Route("/form/submit")]
public class SubmitSchoolFormController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public SubmitSchoolFormController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> SubmitSchoolForm([FromBody] SchoolFormModel schoolFormModel)
    {
        var result = await _mediator.Send(
            _mapper.Map<Core.ProjectAggregate.Form.Form>(schoolFormModel)
        );

        if (Constants.UseSendGrid)
            await _mediator.Publish(result);

        return Ok(result);
    }
}