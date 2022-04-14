using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Agenda.ConsoleApp.Compartilhado;


namespace E_Agenda.ConsoleApp.ModuloTarefa
{
    public class TelaCadastroTarefa : TelaBase, ITela
    {

        private readonly RepositorioTarefa repositorioTarefa;
        private readonly Notificador notificador;

        
        public TelaCadastroTarefa(RepositorioTarefa repositorioTarefa, Notificador notificador) : base("Cadastro de tarefa")
        {
            this.repositorioTarefa = repositorioTarefa;
            this.notificador = notificador;
        }

        public void InserirRegistro()
        {
            MostrarTitulo("Inserindo tarefa");

            Tarefa tarefa = ObterTarefa();

            Console.WriteLine("Quantos intens deseja criar?");
            int quantidadeDeItens = Convert.ToInt32(Console.ReadLine());
            int contador = 0;

            do
            {
                Item itens = ObterItens();
                tarefa.InserirItensNaTarefa(itens);
                contador++;

            } while (contador != quantidadeDeItens);



            string statusValidacao = repositorioTarefa.Inserir(tarefa);



            if (statusValidacao == "REGISTRO_VALIDO")
                notificador.ApresentarMensagem("tarefa cadastrada com sucesso!", "sucesso");
            else
                notificador.ApresentarMensagem(statusValidacao, "erro");
        }



        public void EditarRegistro()
        {
            MostrarTitulo("Editando Tarefa");

            bool temContatoCadastrados = VisualizarRegistro("Pesquisando");

            if (temContatoCadastrados == false)
            {
                notificador.ApresentarMensagem("Nenhuma tarefa cadastrada.", "atencao");
                return;
            }

            Console.WriteLine("Digite o numeros da tarefa que quer editar");
            int numeroTarefa = Convert.ToInt32(Console.ReadLine());

            Tarefa tarefaAtualizado = ObterTarefa();

            bool conseguiuEditar = repositorioTarefa.Editar(x => x.numero == numeroTarefa, tarefaAtualizado);

            if (!conseguiuEditar)
                notificador.ApresentarMensagem("Não foi possível editar.", "erro");
            else
                notificador.ApresentarMensagem("Tarefa editada com sucesso", "sucesso");

        }

        public void ExcluirRegistro()
        {
            MostrarTitulo("Excluido Contato");

            bool temTarefaCadastrados = VisualizarRegistro("Pesquisando");

            if (temTarefaCadastrados == false)
            {
                notificador.ApresentarMensagem(
                    "Nenhuma Tarefa  para  excluir", "atencao");
                return;
            }

            Console.WriteLine("Digite o numeros da Tarefa que quer excluir");
            int numeroTarefa = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = repositorioTarefa.Excluir(x => x.numero == numeroTarefa);

            if (!conseguiuExcluir)
                notificador.ApresentarMensagem("Não foi possível excluir.", "erro");
            else
                notificador.ApresentarMensagem("Tarefa excluído com sucesso!", "sucesso");
        }

        public bool VisualizarRegistro(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualizando Tarefa");

            List<Tarefa> tarefas = repositorioTarefa.SelecionarTodos();

            if (tarefas.Count == 0)
            {
                notificador.ApresentarMensagem("Não tem nenhuma Tarefa.", "atencao");
                return false;
            }

            foreach (Tarefa tarefa in tarefas)
                Console.WriteLine(tarefa.ToString());

            Console.ReadLine();

            return true;

        }

        private Tarefa ObterTarefa()
        {
            Console.Write("Digite o titulo da tarefa: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a data de criação da tarefa:  (dd/mm/aaaa)");
            DateTime dataCriacao = DateTime.Parse(Console.ReadLine());

            Console.Write("Digite a data de conclusão: ");
            DateTime dataConclusao = DateTime.Parse(Console.ReadLine());

            Console.Write("Digite a de prioridade:");
            Console.WriteLine("1 - Baixa");
            Console.WriteLine("2 - Media");
            Console.WriteLine("3 - Alta");
            int prioridade = Convert.ToInt32(Console.ReadLine());
            Prioridade prioridadeEscolhida = Prioridade.Baixa;
            if (prioridade == 2)
                prioridadeEscolhida = Prioridade.Media;
            else if (prioridade == 3)
                prioridadeEscolhida = Prioridade.Alta;

            int porcentagem = 0;

            Tarefa tarefa = new Tarefa(titulo, dataCriacao, dataConclusao, porcentagem, prioridadeEscolhida);

            return tarefa;

        }

        private Item ObterItens()
        {

            Console.Write("Digite a descrição do item: ");
            string descricao = Console.ReadLine();

            Item item = new Item(descricao);

            return item;
        }
    }
}
