using System.Collections.Generic;


namespace CodeGeneration.DSL
{
    public interface IPredator : IAnimal
    {
        IEnumerable<IAnimal> Preys { get; }
    }
}
