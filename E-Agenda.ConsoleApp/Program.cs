using System;
using E_Agenda.ConsoleApp.Compartilhado;
using E_Agenda.ConsoleApp.ModuloTarefa;

namespace E_Agenda.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {


            TelaMenuPrincipal telaMenuPrincipal = new TelaMenuPrincipal();

            while (true)
            {
                TelaBase telaSelecionada = telaMenuPrincipal.ObterTela();

                if (telaSelecionada is null)
                    break;

                string opcaoSelecionada = telaSelecionada.MostrarOpcoes();

                if (telaSelecionada is ITela)
                {
                    ITela telaCadastroBasico = (ITela)telaSelecionada;

                    if (opcaoSelecionada == "1")
                        telaCadastroBasico.InserirRegistro();

                    if (opcaoSelecionada == "2")
                        telaCadastroBasico.EditarRegistro();

                    if (opcaoSelecionada == "3")
                        telaCadastroBasico.ExcluirRegistro();

                    if (opcaoSelecionada == "4")
                        telaCadastroBasico.VisualizarRegistro("Tela");

                }

                if (telaSelecionada is TelaCadastroTarefa)
                {
                    TelaCadastroTarefa telaCadastroTarefa = (TelaCadastroTarefa)telaSelecionada;
                   
                    if (opcaoSelecionada == "5")
                        telaCadastroTarefa.ChamarConcluitItens();


                }

            }




        }




    }
}
