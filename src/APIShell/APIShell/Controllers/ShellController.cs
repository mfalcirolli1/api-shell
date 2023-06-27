using APIShell.Core;
using APIShell.Domain.Core.Notifications;
using APIShell.Domain.Response;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace APIShell.Controllers
{
    public class ShellController : ApiControllerBase
    {
        // private readonly IShellService shellService;

        public ShellController()
        {

        }

        [ProducesResponseType(typeof(SuccessResponse), 200)]
        [ProducesResponseType(typeof(DomainNotification), 400)]
        [ProducesResponseType(typeof(DomainNotification), 500)]
        [HttpGet("GetExemple")]
        public IActionResult GetExemple()
        {
            if (ModelState.IsValid)
            {
                return new OkObjectResult("");
            }
            else
            {
                #region | Error Models

                var error = new List<ModelErrorDataResponse>();

                foreach (var item in ModelState)
                {
                    error.Add(new ModelErrorDataResponse
                    {
                        Key = item.Key,
                        Erro = item.Value.Errors.FirstOrDefault().ErrorMessage.ToString()
                    });
                }
                return BadRequest(error); 

                #endregion
            }
        }
    }
}
