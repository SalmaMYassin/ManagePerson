using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ManagePerson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        #region Property
        private IMediator _mediator;
        #endregion
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
