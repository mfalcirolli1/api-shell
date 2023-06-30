using APIShell.Domain.Error.Contracts;
using APIShell.Domain.Shell.Contracts;
using APIShell.Domain.Shell.Model;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
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
            try
            {
                if (id == 0)
                {
                    errorService.Errors("GetAllCustumerInfo", $"Insira um ID válido!", "ShellService");
                    return null;
                }

                var client = shellRepository.GetCustomerInfoById(id);
                if (client == null)
                {
                    errorService.Errors("GetAllCustumerInfo", $"Não existe cliente cadastrado para este ID!", "ShellService");
                    return null;
                }

                return client;
            }
            catch (Exception ex)
            {
                errorService.Errors("GetAllCustumerInfo", $"Exception: {ex.Message} \n StackTrace: {ex.StackTrace}", "ShellService");
                throw ex;
            }
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

                var newCustomer = new Faker<ShellModel>()
                .RuleFor(x => x.Nome, f => name)
                .RuleFor(x => x.Email, f => email)
                .RuleFor(x => x.CEP, f => f.Address.ZipCode())
                .RuleFor(x => x.Endereco, f => f.Address.StreetAddress())
                .RuleFor(x => x.Cidade, f => f.Address.City())
                .RuleFor(x => x.Estado, f => f.Address.State())
                .RuleFor(x => x.Telefone, f => "11 00000-0000")
                .RuleFor(x => x.Idade, f => f.Random.Number(18, 90).ToString())
                .RuleFor(x => x.DataCadastro, f => DateTime.Now)
                .RuleFor(x => x.Observacao, f => $"Cliente {name}"
                );

                var result = newCustomer.Generate(1);

                if (result.Any())
                {
                    foreach (var _newCustomer in result)
                    {
                        shellRepository.Insert(_newCustomer);
                    }
                }
            }
            catch (Exception ex)
            {
                errorService.Errors("InsertCustumer", $"Exception: {ex.Message} \n StackTrace: {ex.StackTrace}", "ShellService");
                throw ex;
            }
        }
    }
}
