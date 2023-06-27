using System;
using System.Collections.Generic;
using System.Text;

namespace APIShell.Services.Services
{
    public class ShellService
    {
        public string ShellTest(int id)
        {
            return $"API Shell Test: {id}";
        }
    }
}
