namespace CodeGeneration.CodeDOMGenerator
{
    using CodeGeneration.Generator.Logic;
    using System;
    using System.CodeDom;
    using System.CodeDom.Compiler;
    using System.IO;

    /// <summary>
    /// InterfaceGenerator creates a graph using a CodeCompileUnit and  
    /// generates source code for the graph using the CSharpCodeProvider.
    /// </summary>
    public class InterfaceGenerator
    {
        private InterfaceTemplateData intefaceTemplate;

        private CodeCompileUnit targetUnit;
        CodeNamespace codeNamespace;
        private CodeTypeDeclaration targetClass;

        /// <summary>
        /// Constructor
        /// </summary>
        public InterfaceGenerator(InterfaceTemplateData intefaceTemplate, CodeCompileUnit targetUnit)
        {
            this.intefaceTemplate = intefaceTemplate;
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
            InitInterface();
            AddProperties();
        }
        
        private void InitInterface()
        {
            targetClass = new CodeTypeDeclaration(intefaceTemplate.Name);
            targetClass.IsInterface = true;
            codeNamespace = new CodeNamespace("CodeGeneration.GenerationResult.CodeDOM");
            codeNamespace.Types.Add(targetClass);
            targetUnit.Namespaces.Add(codeNamespace);
        }

        private void AddProperties()
        {
            foreach(var propertyTemplate in intefaceTemplate.Properties)
            {
                CodeMemberProperty property = new CodeMemberProperty();
                property.Attributes = MemberAttributes.Public;
                property.Name = propertyTemplate.Name;
                property.HasGet = true;
                property.HasSet = !propertyTemplate.IsReadOnly;
                property.Type = new CodeTypeReference(TypeResolver(propertyTemplate.Type));
                targetClass.Members.Add(property);
            }
        }

        private Type TypeResolver(string typeName)
        {
            switch (typeName)
            {
                case "int":
                    return typeof(int);
                case "string":
                    return typeof(string);
                default:
                    return typeof(object);
            }
        }
    }
}
