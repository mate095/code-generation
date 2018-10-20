using CodeGeneration.DSL;
using Microsoft.VisualStudio.Modeling;

namespace CodeGeneration.TestDataCreator
{
    /// <summary>
    /// Class for creat test data for code generation
    /// </summary>
    public class TestDataCreator
    {
        Store store;

        public IWorld CreatWorld()
        {
            store = new Store(typeof(DSLDomainModel));
            World world;
            using (Transaction t = store.TransactionManager.BeginTransaction("Create test model"))
            {
                world = new World(store);
                Animal animal = new Animal(store);
                animal.Name = "Tiger";

                world.Animals.Add(animal);

                t.Commit();
            }

            return world;
        }
    }
}
