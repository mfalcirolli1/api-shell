using APIShell.Domain.Shell.Model;

namespace APIShell.Domain.Shell.Contracts
{
    public interface IShellService
    {
        ShellModel GetAllCustumerInfo(int id);
        void InsertCustumer(string name, string email);
    }
}
