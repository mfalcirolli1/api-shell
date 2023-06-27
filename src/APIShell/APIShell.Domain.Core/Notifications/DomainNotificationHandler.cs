using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace APIShell.Domain.Core.Notifications
{
    public class DomainNotificationHandler : IDisposable, INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> notifications;

        public DomainNotificationHandler()
        {
            notifications = new List<DomainNotification>();
        }

        public void Dispose()
        {
            notifications = new List<DomainNotification>();
        }

        #pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        #pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            notifications.Add(notification);
        }

        public async Task<IEnumerable<DomainNotification>> GetNotifications()
        {
            return await Task.FromResult(notifications);
        }

        public async Task<bool> HasNotifications()
        {
            return await Task.FromResult(GetNotifications().Result.Any());
        }
    }
}
