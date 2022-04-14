using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace E_Agenda.ConsoleApp.Compartilhado
{
    public class RepositorioBase<T> where T : EntidadeBase
    {
        protected  List<T> registros;

        protected int contadorNumero;

        public RepositorioBase()
        {
            registros = new List<T>();
        }

        public virtual string Inserir (T entidade)
        {
                        entidade.numero = ++contadorNumero;

            registros.Add(entidade);
            return "REGISTRO_VALIDO";
        }

        public bool Editar (Predicate<T> condicao , T novaEnTidade)
        {
            foreach( T entidade in registros)
            {
                if (condicao(entidade))
                {
                    novaEnTidade.numero = entidade.numero;

                    int posicaoParaEditar = registros.IndexOf(entidade);

                    return true;
                }
                
            }
            return false;
        }
        
        public bool Excluir(Predicate<T> condicao)
        {
            foreach ( T entidade in registros)
            {
                if (condicao(entidade))
                {
                    registros.Remove(entidade);
                    return true;

                }
            }
            return false;

        }

        public T SelecionarRegistro(Predicate<T> condicao)
        {
            foreach (T entidade in registros)
            {
                if (condicao(entidade))
                    return entidade;
            }

            return null;
        }

        public List<T> SelecionarTodos()
        {

            return registros;
        }

        public List<T> Filtrar(Predicate<T> condicao)
        {
            return registros.FindAll(condicao);
        }
    }
}
