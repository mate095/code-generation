using System.IO;

namespace RunTimeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "..\\..\\GenerationResult\\_Generated\\T4\\RunTime";
            Animal animal = new Animal();
            string animalContent = animal.TransformText();
            File.WriteAllText(Path.Combine(path, "Animal.cs"), animalContent);
        }
    }
}
