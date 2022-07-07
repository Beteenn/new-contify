using Rentfy.Application.SeedWork;
using Microsoft.AspNetCore.Mvc;

namespace Rentfy.Api.Controllers
{
    public abstract class BaseApiController : ControllerBase
    {
        protected IActionResult ResultRequest<T>(Result<T> result)
            where T : class
        {
            if (!result.Success)
                return BadRequest(result);

            if (result.Data == null)
                return Ok();

            return Ok(result.Data);
        }

        protected IActionResult ResultRequest(Result result, string mensagemStatusOK = "")
        {
            if (!result.Success)
                return BadRequest(result);

            return Ok(mensagemStatusOK);
        }

    }
}
