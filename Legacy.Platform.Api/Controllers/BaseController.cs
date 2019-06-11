using Legacy.Platform.Core.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Legacy.Platform.Api.Controllers
{
    // todo: implement authentication/authorization
    // [Authorize]
    [ApiController]
    [ApplicationExceptionFilter]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
    }

    public class ApplicationExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case BadRequestException e:
                    context.Result = new BadRequestObjectResult(e.Message);
                    return;
                case ConflictException e:
                    context.Result = new ConflictObjectResult(e.Message);
                    return;
                case EntityNotFoundException e:
                    context.Result = new NotFoundObjectResult(e.Message);
                    return;
                case ForbiddenException e:
                    context.Result = new ForbidResult();
                    return;
                case UnauthorizedException e:
                    context.Result = new UnauthorizedResult();
                    return;
            }
        }
    }
}