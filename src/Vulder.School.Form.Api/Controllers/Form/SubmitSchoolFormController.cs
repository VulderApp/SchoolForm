using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vulder.School.Form.Core.Models;

namespace Vulder.School.Form.Api.Controllers.Form;

[ApiController]
[Route("/form/[controller]")]
public class SubmitSchoolFormController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public SubmitSchoolFormController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> SubmitSchoolForm([FromBody] SchoolFormModel schoolFormModel)
    {
        await _mediator.Send(schoolFormModel);
        return Ok();
    }
}