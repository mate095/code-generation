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
            

            foreach(var animal in world.Animals)
            {
                AnimalGenerator generator = new AnimalGenerator(animal);
                generator.CreateAnimal();
            }
            
            // Wait to exit.
            Console.Read();
        }

        
    }
}
