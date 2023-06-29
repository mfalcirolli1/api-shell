using APIShell.Core;
using APIShell.Domain.Core.Notifications;
using APIShell.Domain.Response;
using APIShell.Domain.Shell.Contracts;
using APIShell.Domain.Shell.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace APIShell.Controllers
{
    public class ShellController : ApiControllerBase
    {
        private readonly IShellService shellService;

        public ShellController(INotificationHandler<DomainNotification> notifications, IShellService shellService) : base(notifications)
        {
            this.shellService = shellService;
        }

        [ProducesResponseType(typeof(SuccessResponse), 200)]
        [ProducesResponseType(typeof(DomainNotification), 400)]
        [ProducesResponseType(typeof(DomainNotification), 500)]
        [HttpGet("GetAllCustumerInfo")]
        public IActionResult GetAllCustumerInfo(int id)
        {
            if (ModelState.IsValid)
            {
                return CreateResponse(() => shellService.GetAllCustumerInfo(id));
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

        [ProducesResponseType(typeof(SuccessResponse), 200)]
        [ProducesResponseType(typeof(DomainNotification), 400)]
        [ProducesResponseType(typeof(DomainNotification), 500)]
        [HttpPost("InsertCustumer")]
        public IActionResult InsertCustumer([FromBody] ShellViewModel shellViewModel)
        {
            if (ModelState.IsValid)
            {
                return CreateResponse(() => shellService.InsertCustumer(shellViewModel.nome, shellViewModel.email));
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
