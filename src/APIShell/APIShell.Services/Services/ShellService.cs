using APIShell.Domain.Error.Contracts;
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
        private readonly IErrorService errorService;

        public ShellService(IShellRepository shellRepository, IErrorService errorService)
        {
            this.shellRepository = shellRepository;
            this.errorService = errorService;
        }

        public ShellModel GetAllCustumerInfo(int id)
        {
            var client = shellRepository.GetCustomerInfoById(id);
            return client;
        }

        public void InsertCustumer(string name, string email)
        {
            try
            {
                var customer = shellRepository.GetCustomerInfoByName(name);

                if (customer != null)
                {
                    errorService.Errors("InsertCustumer", "Cliente já possui registro no Banco de Dados. Confira o nome e tente novamente", "ShellService");
                    return;
                }

                customer.Nome = name;
                customer.Email = email;
                customer.CEP = "";
                customer.Telefone = "";

                shellRepository.Insert(customer);
            }
            catch (Exception ex)
            {
                errorService.Errors("InsertCustumer", $"Exception: {ex.Message} \n StackTrace: {ex.StackTrace}", "ShellService");
                throw ex;
            }
        }
    }
}
