using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //api/activites
    public class BaseApiController:ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??=HttpContext.RequestServices.GetService<IMediator>(); //if _mediator is null assign Mediator=right of ??=
}
}