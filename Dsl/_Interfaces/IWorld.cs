using System.Collections.Generic;

namespace CodeGeneration.DSL
{
    public interface IWorld
    {
        IEnumerable<IAnimal> Animals { get; }

        IEnumerable<IPredator> Predators { get; }

        IEnumerable<IAnimal> Herbivores { get; }
    }
}
