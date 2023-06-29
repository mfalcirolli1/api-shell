using APIShell.Domain.Shell.Model;

namespace APIShell.Domain.Shell.Contracts
{
    public interface IShellRepository
    {
        ShellModel GetCustomerInfoById(int id);
        ShellModel GetCustomerInfoByName(string name);
    }
}
