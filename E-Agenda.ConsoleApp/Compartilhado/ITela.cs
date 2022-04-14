using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Agenda.ConsoleApp.Compartilhado
{
    public  interface ITela
    {
        public void InserirRegistro();
        public void EditarRegistro();
        public void ExcluirRegistro();
        public bool VisualizarRegistro(string tipo);

    }
}


