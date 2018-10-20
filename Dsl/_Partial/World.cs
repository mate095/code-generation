using System.Collections.Generic;

namespace CodeGeneration.DSL
{
    internal partial class World : IWorld
    {
        IEnumerable<IAnimal> IWorld.Animals => Animals;
    }
}
