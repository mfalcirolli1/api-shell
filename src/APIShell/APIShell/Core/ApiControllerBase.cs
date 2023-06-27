using APIShell.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace APIShell.Core
{
    [Route("api/v1/[controller]")]
    public class ApiControllerBase : ControllerBase
    {
        private readonly DomainNotificationHandler notifications;
        protected IEnumerable<DomainNotification> Notifications => notifications.GetNotifications().Result;

        public ApiControllerBase(INotificationHandler<DomainNotification> notifications)
        {
            this.notifications = (DomainNotificationHandler)notifications;
        }

        private bool IsValidOperation()
        {
            return !notifications.HasNotifications().Result;
        }

        protected IActionResult CreateResponse<T>(Func<T> function)
        {
            try
            {
                var data = function.Invoke();

                return Response(data);
            }
            catch (Exception)
            {
                // RequestLog(ex, 500)

                return StatusCode(500, new
                {
                    success = false,
                    notifications = notifications.GetNotifications().Result,
                });
            }
        }

        protected IActionResult CreateResponse(Action action)
        {
            try
            {
                action.Invoke();

                return Response();
            }
            catch (Exception)
            {
                // RequestLog(ex, 500)

                return StatusCode(500, new
                {
                    success = false,
                    notifications = notifications.GetNotifications().Result,
                });
            }
        }

        private new IActionResult Response(object data = null)
        {
            if (IsValidOperation())
            {
                // RequestLog(ex, 500)

                return Ok(new
                {
                    success = true,
                    data
                });
            }

            // RequestLog(ex, 500)

            return BadRequest(new 
            {
                success = false,
                notifications = notifications.GetNotifications().Result
            });
        }
    }
}
