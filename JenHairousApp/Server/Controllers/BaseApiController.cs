using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JenHairousApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController<T> : ControllerBase
    {
        private IMediator       _mediatorInstance;
        private ILogger<T>      _loggerInstance;

        protected IMediator     _mediator   => _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();
        protected ILogger<T>    _logger     => _loggerInstance ??= HttpContext.RequestServices.GetService<ILogger<T>>();
    }
}
