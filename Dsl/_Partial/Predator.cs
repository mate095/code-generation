using System;
using System.Collections.Generic;

namespace CodeGeneration.DSL
{
    internal partial class Predator : IPredator
    {
        IEnumerable<IAnimal> IPredator.Preys => Preys;
    }
}
