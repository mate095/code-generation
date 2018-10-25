namespace CodeGeneration.DSL
{
    using System.Collections.Generic;
    using System.Linq;

    internal partial class World : IWorld
    {
        IEnumerable<IAnimal> IWorld.Animals => Animals;

        IEnumerable<IPredator> IWorld.Predators => ((IWorld)this).Animals.Where(x => x is IPredator).Select(y => y as IPredator);

        IEnumerable<IAnimal> IWorld.Herbivores => ((IWorld)this).Animals.Where(x => !(x is IPredator));
    }
}
