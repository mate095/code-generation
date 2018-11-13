namespace CodeGeneratin.RoslynGenerator
{
    using CodeGeneration.Generator.Logic;
    using System;

    class Program
    {
        public static void Main(string[] args)
        {
            var collector = new ClassTemplateDataCollector();
            var classTemplates = collector.ClassTemplates;
            var interfaceTemplates = collector.InterfaceTemplates;


            foreach (var classTemplate in classTemplates)
            {
                ClassGenerator generator = new ClassGenerator(classTemplate);
                generator.CreateClass();
            }

            foreach (var interfaceTemplate in interfaceTemplates)
            {
                InterfaceGenerator generator = new InterfaceGenerator(interfaceTemplate);
                generator.CreateInterface();
            }

            // Wait to exit.
            Console.Read();
        }

        
    }
}
