using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Agenda.ConsoleApp.Compartilhado;

namespace E_Agenda.ConsoleApp.ModuloTarefa
{
    public class Tarefa : EntidadeBase
    {
        

        public string titulo;
        public DateTime dataCriacao;
        public DateTime dataConclusao;
        public decimal percentual;
        public Prioridade tipoprioridade;
        List<Item> listaDeItens;
        public bool concluida;



        public Tarefa(string titulo, DateTime dataCriacao, DateTime dataConclusao, decimal percentual, Prioridade tipoprioridade)
        {
            this.titulo = titulo;
            this.dataCriacao = dataCriacao;
            this.dataConclusao = dataConclusao;
            this.percentual = percentual;
            this.tipoprioridade = tipoprioridade;
            listaDeItens = new List<Item>();
            

        }

       
         
        public override string ToString()
        {
            return "Número: " + numero + Environment.NewLine +
                "Titulo: " + titulo + Environment.NewLine +
                "prioridade: " + tipoprioridade + Environment.NewLine +
                "Data de criação: " + dataCriacao + Environment.NewLine +
                "Data de conclusão: " + dataConclusao + Environment.NewLine +
                "Pecentual Completo: " + percentual + Environment.NewLine +
                "Tarefas: " + ToStringDeitens();


        }
        public string ToStringDeitens()
        {
            StringBuilder si = new StringBuilder();

            foreach (Item item in listaDeItens)
            {
                si.AppendLine(item.descricao);
            }

            return si.ToString();
        }
        public void InserirItensNaTarefa(Item items)
        {
            listaDeItens.Add(items);
        }

        public void ConcluirItem(int numeroItem)
        {
            if (this.listaDeItens[numeroItem].itemConcluido == true)
            {
                Notificador.ApresentarMensagem("Item ja concluido", "erro");
                return;
            }

            this.listaDeItens[numeroItem].itemConcluido = true;

            AtualizarPercentual();

        }
        
        public void AtualizarPercentual()
        {
            int quantiaItensTotais = listaDeItens.Count;
            int contador = 0;
            foreach(Item item in listaDeItens)
            {
                if (item.itemConcluido == true)
                {
                    contador++; 
                }
            }

            if (contador == 0)
            {
                return;
            }

            decimal totalPercentual = contador *100 / quantiaItensTotais;

            this.percentual = totalPercentual;
        }





    }
    public enum Prioridade
    {
        Baixa = 1,
        Media = 2,
        Alta = 3,
    }
}
