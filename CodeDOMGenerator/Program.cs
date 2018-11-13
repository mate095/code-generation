namespace CodeGeneration.CodeDOMGenerator
{
    using System.CodeDom;
    using CodeGeneration.Generator.Logic;

    class Program
    {
        static void Main(string[] args)
        {
            var collector = new ClassTemplateDataCollector();
            var classTemplates = collector.ClassTemplates;
            var interfaceTemplates = collector.InterfaceTemplates;


            foreach (var classTemplate in classTemplates)
            {
                ClassGenerator generator = new ClassGenerator(classTemplate, new CodeCompileUnit());
                string outputPath = $"..\\..\\GenerationResult\\_Generated\\CodeDOM\\{classTemplate.Name}.cs";
                generator.GenerateCSharpCode(outputPath);
            }

            foreach (var interfaceTemplate in interfaceTemplates)
            {
                InterfaceGenerator generator = new InterfaceGenerator(interfaceTemplate, new CodeCompileUnit());
                string outputPath = $"..\\..\\GenerationResult\\_Generated\\CodeDOM\\{interfaceTemplate.Name}.cs";
                generator.GenerateCSharpCode(outputPath);
            }
        }
    }
}
