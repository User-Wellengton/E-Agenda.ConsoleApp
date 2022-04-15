using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Agenda.ConsoleApp.Compromisso;
using E_Agenda.ConsoleApp.ModuloContato;
using E_Agenda.ConsoleApp.ModuloTarefa;

namespace E_Agenda.ConsoleApp.Compartilhado
{
    public class TelaMenuPrincipal
    {

        private string opcaoSelecionada;

        private  RepositorioCompromisso repositorioCompromisso;
        private  TelaCadastroCompromisso telaCadastroCompromisso;

        private  RepositorioContato repositorioContato;
        private  TelaCadastroContato telaCadastroContato;

        private  RepositorioTarefa repositorioTarefa;
        private  TelaCadastroTarefa telaCadastroTarefa;
        public TelaMenuPrincipal()
        {            

            repositorioContato = new RepositorioContato();
            telaCadastroContato = new TelaCadastroContato(repositorioContato);

            repositorioTarefa = new RepositorioTarefa();
            telaCadastroTarefa = new TelaCadastroTarefa(repositorioTarefa);

            repositorioCompromisso = new RepositorioCompromisso();
            telaCadastroCompromisso = new TelaCadastroCompromisso( telaCadastroContato,
             repositorioCompromisso, repositorioContato);



        }
            public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("E-Agenda");

            Console.WriteLine();

            Console.WriteLine("Menu gestão Compromisso digite 1...");
            Console.WriteLine("Menu gestão Contato digite 2...");
            Console.WriteLine("Menu gestão Tarefa digite 3...");
            Console.WriteLine("Para Sair digite S");

            opcaoSelecionada = Console.ReadLine();

            return opcaoSelecionada;
        }

        public TelaBase ObterTela()
        {
            string opcaoSelecionada = MostrarOpcoes();

            TelaBase tela = null;

            if (opcaoSelecionada == "1")
                tela = telaCadastroCompromisso;

            else if (opcaoSelecionada == "2")
                tela = telaCadastroContato;

            else if (opcaoSelecionada == "3")
                tela = telaCadastroTarefa;
            
            return tela;

        }

    }
}
