using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class AppBaseController : ControllerBase
{
    protected readonly IMediator _mediatR;
    public AppBaseController(IMediator mediatR)
    {
        _mediatR = mediatR;
    }
}
