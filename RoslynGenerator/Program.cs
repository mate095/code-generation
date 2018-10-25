namespace CodeGeneratin.RoslynGenerator
{
    using System;
    using CodeGeneration.TestDataCreator;

    class Program
    {
        public static void Main(string[] args)
        {

            var creator = new TestDataCreator();
            var world = creator.CreatWorld();
            AnimalGenerator generator = new AnimalGenerator();

            foreach(var animal in world.Animals)
            {
                generator.CreateAnimal(animal);
            }
            
            // Wait to exit.
            Console.Read();
        }

        
    }
}
