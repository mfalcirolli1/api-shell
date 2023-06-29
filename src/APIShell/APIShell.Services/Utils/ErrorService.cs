using APIShell.Domain.Core.Commands;
using APIShell.Domain.Core.Notifications;
using APIShell.Domain.Error.Contracts;
using MediatR;
using Newtonsoft.Json;
using RestSharp;

namespace APIShell.Services.Utils
{
    public class ErrorService : CommandsHandler, IErrorService
    {
        public ErrorService(INotificationHandler<DomainNotification> notifications) : base(notifications)
        {

        }

        public void Errors(string key, string message, string group)
        {
            NotifyErrors(
                $"{key}", 
                $"{message}", 
                $"{group}", 
                $"");
        }

        public void ErrorsRest(string key, string message, string group, IRestResponse result = null)
        {
            NotifyErrors(
                $"{key}", 
                $"{message}", 
                $"{group}", 
                $"{JsonConvert.DeserializeObject<object>(result.Content)}");
        }
    }
}
