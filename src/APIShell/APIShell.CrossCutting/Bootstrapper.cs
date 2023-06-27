using APIShell.Domain.Shell.Contracts;
using APIShell.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace APIShell.CrossCutting
{
    public static class Bootstrapper
    {
        public static void Initialize(IServiceCollection service)
        {
            //service.AddScoped(IShellService, ShellService);
        }
    }
}
