using API_Folhas.Models;

namespace API_FOlhas.IteratorFuncionario
{
    //Iterator
    public interface IAbstractIterator
    {
        Funcionario First();
        Funcionario Next();
        bool IsDone { get; }
    }
}