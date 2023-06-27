using APIShell.Domain.Core.Notifications;
using MediatR;
using System.Threading;

namespace APIShell.Domain.Core.Commands
{
    public abstract class CommandsHandler
    {
        private readonly DomainNotificationHandler notifications;

        protected CommandsHandler(INotificationHandler<DomainNotification> notifications)
        {
            this.notifications = (DomainNotificationHandler)notifications;
        }

        protected void NotifyValidationError<T>(Command<T> message)
        {
            foreach (var error in message.ValidationResult.Errors)
                notifications.Handle(new DomainNotification(error.PropertyName, error.ErrorMessage), CancellationToken.None).Wait();
        }

        protected void NotifyValidationError(Commands message, string group = null)
        {
            foreach (var error in message.ValidationResult.Errors)
                notifications.Handle(new DomainNotification(error.PropertyName, error.ErrorMessage, group), CancellationToken.None).Wait();
        }

        protected void NotifyErrors(string key, string message, string group = null, string result = null)
        {
            notifications.Handle(new DomainNotification(key, message, group, result), CancellationToken.None).Wait();
        }
    }
}
