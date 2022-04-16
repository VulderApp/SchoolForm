using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vulder.School.Form.Core.Models;

namespace Vulder.School.Form.Api.Controllers.Form;

[Authorize]
[ApiController]
[Route("/form/approve")]
public class ApproveSchoolFormController : ControllerBase
{
    private readonly IMediator _mediator;

    public ApproveSchoolFormController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPut]
    public async Task<IActionResult> ApproveForm([FromBody] SchoolFormApproveModel approveModel)
    {
        await _mediator.Send(new SchoolFormApproveRequestModel
        {
            FormId = approveModel.FormId,
            AdminId = Guid.Parse(User.FindFirst(ClaimTypes.PrimarySid)?.Value!)
        });

        return Ok();
    }
}