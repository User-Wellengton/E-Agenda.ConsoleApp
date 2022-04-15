using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace E_Agenda.ConsoleApp.Compartilhado
{
    public static class Notificador
    {
                
        public static void ApresentarMensagem(string mensagem, string tipoMensagem)
        {
            switch (tipoMensagem)
            {
                case "sucesso":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case "atenção":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;

                case "erro":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                default:
                    break;
            }

            Console.WriteLine();
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadLine();
        }


    }
}
