using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Agenda.ConsoleApp.Compartilhado;

namespace E_Agenda.ConsoleApp.ModuloContato
{
    internal class TelaCadastroContato : TelaBase, ITela
    {
        private readonly RepositorioContato repositorioContato;
        

        public TelaCadastroContato(RepositorioContato repositorioContato) : base("Cadastro de Contato")
        {
            this.repositorioContato = repositorioContato;
            
        }

        public void InserirRegistro()
        {
            MostrarTitulo("Inserindo Contato");

            Contato contato = ObterContato();

            string statusValidacao = repositorioContato.Inserir(contato);

            if (statusValidacao == "REGISTRO_VALIDO")
                Notificador.ApresentarMensagem("Contato cadastrado com sucesso!", "sucesso");
            else
                Notificador.ApresentarMensagem(statusValidacao, "erro");
        }


        public void EditarRegistro()
        {
            MostrarTitulo("Editando Contato");

            bool temContatoCadastrados = VisualizarRegistro("Pesquisando");

            if (temContatoCadastrados == false)
            {
                Notificador.ApresentarMensagem("Nenhum Contato cadastrado .", "atencao");
                return;
            }

            Console.WriteLine("Digite o numeros do Contato que quer editar");
            int numeroContato = Convert.ToInt32(Console.ReadLine());

            Contato contatoAtualizado = ObterContato();

            bool conseguiuEditar = repositorioContato.Editar(x => x.numero == numeroContato, contatoAtualizado);

            if (!conseguiuEditar)
                Notificador.ApresentarMensagem("Não foi possível editar.", "erro");
            else
                Notificador.ApresentarMensagem("Contato editado com sucesso", "sucesso");

        }

        public void ExcluirRegistro()
        {
            MostrarTitulo("Excluido Contato");

            bool temContatoCadastrados = VisualizarRegistro("Pesquisando");

            if (temContatoCadastrados == false)
            {
                Notificador.ApresentarMensagem(
                    "Nenhum Contato cadastrado ", "atencao");
                return;
            }

            Console.WriteLine("Digite o numeros do Contato que quer excluir");
            int numeroContato = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = repositorioContato.Excluir(x => x.numero == numeroContato);

            if (!conseguiuExcluir)
                Notificador.ApresentarMensagem("Não foi possível excluir.", "erro");
            else
                Notificador.ApresentarMensagem("Contato excluído com sucesso!", "sucesso");
        }

        public bool VisualizarRegistro(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualizando Contato");

            List<Contato> contatos = repositorioContato.SelecionarTodos();

            if (contatos.Count == 0)
            {
                Notificador.ApresentarMensagem("Não há nenhum contato disponível.", "atencao");
                return false;
            }

            foreach (Contato contato in contatos)
                Console.WriteLine(contato.ToString());

            Console.ReadLine();

            return true;

        }

        private Contato ObterContato()
        {
            Console.Write("Digite o nome do contato: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o Email do contato: ");
            string email = Console.ReadLine();

            Console.Write("Digite o número do telefone do contato: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite a empresa do contato: ");
            string empresa = Console.ReadLine();

            Console.Write("Digite o cargo na empresa do contato: ");
            string cargo = Console.ReadLine();

            Contato contato = new Contato(nome, email, telefone, empresa, cargo);

            return contato;

        }

    }
}
