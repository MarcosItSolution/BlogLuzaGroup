using System.Net;
using System.Security.Claims;
using Blog.Intenal.Domains.Core.Results;
using Blog.Internal.Applications.Core.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Blog.External.Presentations.Api.Controllers
{
    //[Authorize]
    [ApiController]
    [Produces("application/json")] 
    [Route("v{version:apiVersion}/[controller]")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public abstract class BaseController<TEntity> : ControllerBase where TEntity : class
    {
        internal ILogger _logger;
        internal Dispatcher _dispatcher;

        public BaseController(ILogger<TEntity> logger, Dispatcher dispatcher)
        {
            _logger = logger;
            _dispatcher = dispatcher;
        }

        #region - Padronização dos ResponseCode da API -
        protected IActionResult ResponseApi(CustomResult custom)
            => ResponseResult(custom);
        #endregion

        #region - Result API -
        private static JsonResult ResponseBase(
            HttpStatusCode statusCode, object? result)
        {
            var jsonResult = new JsonResult(result) { StatusCode = (int)statusCode };

            return jsonResult;
        }

        private static JsonResult ResponseResult(CustomResult custom)
            => ResponseBase(custom.StatusCode, custom.Data);

        #endregion


    }
}
