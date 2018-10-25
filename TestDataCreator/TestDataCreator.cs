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
                Animal animal1 = new Animal(store);
                animal1.Name = "Tiger";

                Animal animal2 = new Animal(store);
                animal2.Name = "Lion";

                world.Animals.Add(animal1);
                world.Animals.Add(animal2);

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
