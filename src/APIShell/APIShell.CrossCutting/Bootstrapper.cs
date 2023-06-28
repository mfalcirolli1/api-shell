using APIShell.Domain.Core.Notifications;
using APIShell.Domain.Shell.Contracts;
using APIShell.Infrastructure.ORM;
using APIShell.Services.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace APIShell.CrossCutting
{
    public static class Bootstrapper
    {
        public static void Initialize(IServiceCollection services)
        {
            // Context
            services.AddScoped<ShellContext>();

            // MediatR
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Services
            services.AddScoped<IShellService, ShellService>();

            // Repository

            // Utils
        }
    }
}
