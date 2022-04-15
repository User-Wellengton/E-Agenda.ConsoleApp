using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Agenda.ConsoleApp.Compartilhado;
using E_Agenda.ConsoleApp.ModuloContato;


namespace E_Agenda.ConsoleApp.Compromisso
{
    internal class TelaCadastroCompromisso : TelaBase, ITela
    {
        private readonly TelaCadastroContato telaCadastroContato;
        private readonly RepositorioCompromisso repositorioCompromisso;
        private readonly RepositorioContato repositorioContato;
        

        public TelaCadastroCompromisso(TelaCadastroContato telaCadastroContato,
            RepositorioCompromisso repositorioCompromisso,
            RepositorioContato repositorioContato) : base("Cadastro de Compromisso")
        {
            this.telaCadastroContato = telaCadastroContato;
            this.repositorioCompromisso = repositorioCompromisso;
            this.repositorioContato = repositorioContato;
            
        }

        public void InserirRegistro()
        {
            MostrarTitulo("Inserindo Compromisso");

            Contato contatoselecionado = ObtemContato();

            Compromisso compromisso = ObterCompromisso(contatoselecionado);

            string statusValidacao = repositorioCompromisso.Inserir(compromisso);

            if (statusValidacao == "REGISTRO_VALIDO")
                Notificador.ApresentarMensagem("Compromisso cadastrado com sucesso!", "sucesso");
            else
                Notificador.ApresentarMensagem(statusValidacao, "erro");
        }

        public void EditarRegistro()
        {
            MostrarTitulo("Editando Compromisso");

            bool temCompromissoCadastrados = VisualizarRegistro("Pesquisando");

            if (temCompromissoCadastrados == false)
            {
                Notificador.ApresentarMensagem("Nenhum Compromisso cadastrado .", "atencao");
                return;
            }

            Console.WriteLine("Digite o numeros do compromisso que quer editar");
            int numeroCompromisso = Convert.ToInt32(Console.ReadLine());

            Contato contatoselecionado = ObtemContato();

            Compromisso compromissoAtualizado = ObterCompromisso(contatoselecionado);

            bool conseguiuEditar = repositorioCompromisso.Editar(x => x.numero == numeroCompromisso, compromissoAtualizado);

            if (!conseguiuEditar)
                Notificador.ApresentarMensagem("Não foi possível editar.", "erro");
            else
                Notificador.ApresentarMensagem("Compromisso editado com sucesso", "sucesso");

        }

       

        public void ExcluirRegistro()
        {
            MostrarTitulo("Excluido Compromisso");

            bool temCompromissoCadastrados = VisualizarRegistro("Pesquisando");

            if (temCompromissoCadastrados == false)
            {
                Notificador.ApresentarMensagem(
                    "Nenhum amigo Compromisso para poder excluir", "atencao");
                return;
            }

            Console.WriteLine("Digite o numeros do Compromisso que quer excluir");
            int numeroCompromisso = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = repositorioCompromisso.Excluir(x => x.numero == numeroCompromisso);

            if (!conseguiuExcluir)
                Notificador.ApresentarMensagem("Não foi possível excluir.", "erro");
            else
                Notificador.ApresentarMensagem("Compromisso excluído com sucesso!", "sucesso");
        }


        public bool VisualizarRegistro(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualizando Compromisso");

            List<Compromisso> compromissos = repositorioCompromisso.SelecionarTodos();

            if (compromissos.Count == 0)
            {
                Notificador.ApresentarMensagem("Não há nenhum compromisso disponível.", "atencao");
                return false;
            }

            foreach (Compromisso compromisso in compromissos)
                Console.WriteLine(compromisso.ToString());

            Console.ReadLine();

            return true;

        }


        private Compromisso ObterCompromisso(Contato contatoselecionado)
        {
            Console.Write("Digite o assunto do compromisso: ");
            string assunto = Console.ReadLine();

            Console.Write("Digite o local do compromisso: ");
            string local = Console.ReadLine();

            Console.Write("Digite a data do compromisso:  (dd/mm/aaaa)");
            DateTime dataCompromisso = DateTime.Parse(Console.ReadLine());

            Console.Write("Digite o horário de inicio do compromisso: ");
            DateTime horarioDeInicio = DateTime.Parse(Console.ReadLine());

            Console.Write("Digite o horário do termino do compromisso: ");
            DateTime horarioDoTermino = DateTime.Parse(Console.ReadLine());

            Compromisso compromisso = new Compromisso(contatoselecionado, assunto, local, dataCompromisso, horarioDeInicio , horarioDoTermino);

            return compromisso;

        }



        private Contato ObtemContato()
        {
            bool temContatoDisponiveis = telaCadastroContato.VisualizarRegistro("");

            if (!temContatoDisponiveis)
            {
                Notificador.ApresentarMensagem("Não há nenhuma contatos disponível para cadastrar revistas", "atenção");
                return null;
            }

            Console.Write("Digite o número do contato para adicionar: ");
            int numContatoSelecionado = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Contato contatoselecionado = repositorioContato.SelecionarRegistro(x => x.numero == numContatoSelecionado);

            return contatoselecionado;
        }


    }
}
