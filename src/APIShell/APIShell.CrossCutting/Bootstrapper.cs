using APIShell.Domain.Core.Notifications;
using APIShell.Domain.Shell.Contracts;
using APIShell.Services.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace APIShell.CrossCutting
{
    public static class Bootstrapper
    {
        public static void Initialize(IServiceCollection services)
        {
            // Context
            
            // MediatR
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Services
            services.AddScoped<IShellService, ShellService>();

            // Utils

            // Repository
        }
    }
}
