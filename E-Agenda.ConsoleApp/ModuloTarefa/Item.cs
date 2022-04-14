using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Agenda.ConsoleApp.Compartilhado;

namespace E_Agenda.ConsoleApp.ModuloTarefa
{
    public class Item : EntidadeBase
    {
        public string descricao;
        public bool itemConcluido;

        public Item(string descricao)
        {
            this.descricao = descricao;
            this.itemConcluido = false;
        }


        public override string ToString()
        {

            string Estatus = itemConcluido ? "Concluido" : "pendente";

            return "Número: " + numero + Environment.NewLine +
                "Descrição: " + descricao + Environment.NewLine +
                Estatus;

        }


    }
}
