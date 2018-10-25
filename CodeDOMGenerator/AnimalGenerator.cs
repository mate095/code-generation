namespace CodeGeneration.CodeDOMGenerator
{
    using System.IO;
    using System.CodeDom;
    using System.CodeDom.Compiler;
    using CodeGeneration.DSL;

    /// <summary>
    /// AnimalGenerator creates a graph using a CodeCompileUnit and  
    /// generates source code for the graph using the CSharpCodeProvider.
    /// </summary>
    public class AnimalGenerator
    {
        private IAnimal animal;

        private CodeCompileUnit targetUnit;
        private CodeTypeDeclaration targetClass;

        /// <summary>
        /// Constructor
        /// </summary>
        public AnimalGenerator(IAnimal animal, CodeCompileUnit targetUnit)
        {
            this.animal = animal;
            this.targetUnit = targetUnit;
        }

        /// <summary>
        /// Generate CSharp source code from the compile unit.
        /// </summary>
        public void GenerateCSharpCode(string fileName)
        {
            CreateGraph();

            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.BracingStyle = "C";
            using (StreamWriter sourceWriter = new StreamWriter(fileName))
            {
                provider.GenerateCodeFromCompileUnit(
                    targetUnit, sourceWriter, options);
            }
        }

        private void CreateGraph()
        {
            InitClass();
        }
        
        private void InitClass()
        {
            targetClass = new CodeTypeDeclaration(animal.Name);
            CodeNamespace codeNamespace = new CodeNamespace("CodeGeneration.GenerationResult.CodeDOM");
            codeNamespace.Types.Add(targetClass);
            targetUnit.Namespaces.Add(codeNamespace);
        }
    }
}