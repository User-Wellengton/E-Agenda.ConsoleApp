using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Agenda.ConsoleApp.Compartilhado;
using E_Agenda.ConsoleApp.ModuloContato;

namespace E_Agenda.ConsoleApp.Compromisso
{
    public class Compromisso : EntidadeBase
    {
        public Contato contato;

        public string assunto;
        public string local;
        public DateTime dataCompromisso;
        public DateTime horaInicio;
        public DateTime horaTermino;


        public string Assunto => assunto;
        public string Local => local;
        public DateTime DataCompromisso => dataCompromisso;
        public DateTime HoraInicio => horaInicio;
        public DateTime HoraTermino => horaTermino;

        public Compromisso(Contato contato, string assunto, string local, DateTime dataCompromisso, DateTime horaInicio, DateTime horaTermino)
        {
            this.assunto = assunto;
            this.local = local;
            this.dataCompromisso = dataCompromisso;
            this.horaInicio = horaInicio;
            this.horaTermino = horaTermino;
            this.contato = contato;
        }

        public override string ToString()
        {
            return "Número: " + numero + Environment.NewLine +
             "Contato: " + contato.nome + Environment.NewLine +
                "Assunto : " + Assunto + Environment.NewLine +
                "Local :" + Local + Environment.NewLine +
                "Data Compromisso :" + DataCompromisso + Environment.NewLine +
                "Hora Inicio :" + HoraInicio + Environment.NewLine +
                "Hora Termino :" + HoraTermino + Environment.NewLine;


        }










    }
}
