using APIShell.Domain.Repository;
using APIShell.Domain.Shell.Model;

namespace APIShell.Domain.Shell.Contracts
{
    public interface IShellRepository : IRepository<ShellModel>
    {
        ShellModel GetCustomerInfoById(int id);
        ShellModel GetCustomerInfoByName(string name);
    }
}
