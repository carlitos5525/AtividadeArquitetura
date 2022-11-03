using API_Folhas.Models;

namespace API_FOlhas.IteratorFuncionario
{
    //ConcreteIterator
    public class Iterator : IAbstractIterator
    {
        private int current = 0;
        private int step = 1;
        private ConcreteCollection collection;
        public Iterator(ConcreteCollection collection)
        {
            this.collection = collection;
        }
        // Retorna o primeiro item
        public Funcionario First()
        {
            current = 0;
            return collection.GetFuncionario(current);
        }
        // Retorna o proximo item
        public Funcionario Next()
        {
            current += step;
            if (!IsDone)
            {
                return collection.GetFuncionario(current);
            }
            else
            {
                return null;
            }
        }

        Funcionario IAbstractIterator.First()
        {
            throw new System.NotImplementedException();
        }

        Funcionario IAbstractIterator.Next()
        {
            throw new System.NotImplementedException();
        }

        // Verifica se a iteração terminou
        public bool IsDone
        {
            get { return current >= collection.Count; }
        }
    }
}