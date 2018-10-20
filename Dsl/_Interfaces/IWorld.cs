using System.Collections.Generic;

namespace CodeGeneration.DSL
{
    public interface IWorld
    {
        IEnumerable<IAnimal> Animals { get; }
    }
}
