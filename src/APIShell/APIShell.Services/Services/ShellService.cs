using APIShell.Domain.Shell.Contracts;
using APIShell.Domain.Shell.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIShell.Services.Services
{
    public class ShellService : IShellService
    {
        private readonly IShellRepository shellRepository;

        public ShellService(IShellRepository shellRepository)
        {
            this.shellRepository = shellRepository;
        }

        public ShellModel ShellTest(int id)
        {
            var client = shellRepository.GetCustomerInfoById(id);
            return client;
        }
    }
}
