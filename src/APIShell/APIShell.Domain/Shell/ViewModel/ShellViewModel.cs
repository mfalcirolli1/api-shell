using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace APIShell.Domain.Shell.ViewModel
{
    public class ShellViewModel
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string email { get; set; }
    }
}
