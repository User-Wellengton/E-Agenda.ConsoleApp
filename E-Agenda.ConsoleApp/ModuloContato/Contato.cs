using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Agenda.ConsoleApp.Compartilhado;

namespace E_Agenda.ConsoleApp.ModuloContato
{
    public class Contato : EntidadeBase
    {
        public string nome;
        public string email;
        public string telefone;
        public string empresa;
        public string cargoDaPessoa;

        public string Nome { get; set; }

        public Contato(string nome, string email, string telefone, string empresa, string cargoDaPessoa)
        {
            this.nome = nome;
            this.email = email;
            this.telefone = telefone;
            this.empresa = empresa;
            this.cargoDaPessoa = cargoDaPessoa;
        }

        public override string ToString()
        {
            return "Número: " + numero + Environment.NewLine +
                "Nome: " + nome + Environment.NewLine +
                "Email: " + email + Environment.NewLine +
                "Telefone: " + telefone + Environment.NewLine +
                "Empresa: " + empresa + Environment.NewLine +
                "Cargo: " + cargoDaPessoa + Environment.NewLine;
        }








    }
}
