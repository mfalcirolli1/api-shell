using System;
using System.Collections.Generic;
using System.Text;

namespace APIShell.Domain.Shell.Model
{
    public class ShellModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string Telefone { get; set; }
        public string Idade { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public string Observacao { get; set; }
    }
}
