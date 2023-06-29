using APIShell.Domain.Shell.Contracts;
using APIShell.Domain.Shell.Model;
using APIShell.Infrastructure.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APIShell.Infrastructure.Repositories
{
    public class ShellRepository : Repository<ShellContext, ShellModel>, IShellRepository
    {
        public ShellRepository(ShellContext context) : base(context)
        {

        }

        public ShellModel GetCustomerInfoById(int id)
        {
            return _context.ShellRepository.FirstOrDefault(x => x.ID == id);
        }

        public ShellModel GetCustomerInfoByName(string name)
        {
            return _context.ShellRepository.FirstOrDefault(x => x.Nome == name);
        }
    }
}
