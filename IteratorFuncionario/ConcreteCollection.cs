 using System.Collections.Generic;
using API_Folhas.Models;

namespace API_FOlhas.IteratorFuncionario
{
    //ConcreteAggregate
    public class ConcreteCollection : IAbstractCollection
    {
        private List<Funcionario> listaFuncionarios;

        public ConcreteCollection(List<Funcionario> listaFuncionarios)
        {
            this.listaFuncionarios = listaFuncionarios;
        }
        
        //Cria o Iterator
        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }

         // Conta os itens
        public int Count
        {
            get { return listaFuncionarios.Count; }
        }

        //Adiciona itens na coleção
        public void AddFuncionario(Funcionario funcionario)
        {
            listaFuncionarios.Add(funcionario);
        }

        //Retorna um item da coleção
        public Funcionario GetFuncionario(int posicao)
        {
            return listaFuncionarios[posicao];
        }
        
    }
}