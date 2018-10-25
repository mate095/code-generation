using CodeGeneration.DSL;
using Microsoft.VisualStudio.Modeling;
using System;

namespace CodeGeneration.TestDataCreator
{
    /// <summary>
    /// Class for creat test data for code generation
    /// </summary>
    public class TestDataCreator : IDisposable
    {
        Store store;

        public IWorld CreatWorld()
        {
            store = new Store(typeof(DSLDomainModel));
            World world;
            using (Transaction t = store.TransactionManager.BeginTransaction("Create test model"))
            {
                world = new World(store);
                Predator predator = new Predator(store);
                predator.Name = "Tiger";
                predator.NumberOfLegs = 4;
                predator.AnimalId = 1;

                Animal prey = new Animal(store);
                prey.Name = "Buffallo";
                prey.NumberOfLegs = 4;
                prey.AnimalId = 2;
                
                predator.Preys.Add(prey);

                world.Animals.Add(predator);
                world.Animals.Add(prey);

                t.Commit();
            }

            return world;
        }

        public void Dispose()
        {
            store.Dispose();
        }
    }
}
