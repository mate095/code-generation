namespace CodeGeneration.CodeDOMGenerator
{
    using System.CodeDom;
    using CodeGeneration.TestDataCreator;

    class Program
    {
        static void Main(string[] args)
        {
            var creator = new TestDataCreator();
            var world = creator.CreatWorld();

            foreach(var animal in world.Animals)
            {
                AnimalGenerator generator = new AnimalGenerator(animal, new CodeCompileUnit());
                string outputPath = $"..\\..\\GenerationResult\\_Generated\\CodeDOM\\{animal.Name}.cs";
                generator.GenerateCSharpCode(outputPath);
            }
        }
    }
}
