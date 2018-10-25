namespace CodeGeneration.CodeDOMGenerator
{
    using System.IO;
    using System.CodeDom;
    using System.CodeDom.Compiler;
    using CodeGeneration.DSL;
    using System.Collections.Generic;

    /// <summary>
    /// AnimalGenerator creates a graph using a CodeCompileUnit and  
    /// generates source code for the graph using the CSharpCodeProvider.
    /// </summary>
    public class AnimalGenerator
    {
        private IAnimal animal;

        private CodeCompileUnit targetUnit;
        CodeNamespace codeNamespace;
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
            AddAnimalProperties();
            AddConstructor();

            if(animal is IPredator)
            {
                AddPredarorSpecifcPart();
            }
        }
        
        private void InitClass()
        {
            targetClass = new CodeTypeDeclaration(animal.Name);
            codeNamespace = new CodeNamespace("CodeGeneration.GenerationResult.CodeDOM");
            codeNamespace.Types.Add(targetClass);
            targetUnit.Namespaces.Add(codeNamespace);
        }

        private void AddConstructor()
        {
            CodeConstructor constructor = new CodeConstructor();
            constructor.Attributes = MemberAttributes.Public;

            constructor.Parameters.Add(new CodeParameterDeclarationExpression(typeof(string), "name"));

            var nameReference = new CodePropertyReferenceExpression();
            nameReference.PropertyName = "Name";
            constructor.Statements.Add(new CodeAssignStatement(nameReference, new CodeArgumentReferenceExpression("names")));

            targetClass.Members.Add(constructor);
        }

        private void AddAnimalProperties()
        {
            CodeMemberProperty nameProperty = new CodeMemberProperty();
            nameProperty.Attributes = MemberAttributes.Public;
            nameProperty.Name = "Name";
            nameProperty.HasGet = true;
            nameProperty.HasSet = true;
            nameProperty.Type = new CodeTypeReference(typeof(string));
            nameProperty.Comments.Add(new CodeCommentStatement("Name of the animal"));
            targetClass.Members.Add(nameProperty);

            CodeMemberProperty legsProperty = new CodeMemberProperty();
            legsProperty.Attributes = MemberAttributes.Public;
            legsProperty.Name = "NumberOfLegs";
            legsProperty.HasGet = true;
            legsProperty.GetStatements.Add(new CodeMethodReturnStatement(
                new CodePrimitiveExpression(animal.NumberOfLegs)));
            legsProperty.HasSet = false;
            targetClass.Members.Add(legsProperty);
        }

        private void AddPredarorSpecifcPart()
        {

            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));

            CodeMemberField preysValueField = new CodeMemberField();
            preysValueField.Attributes = MemberAttributes.Private;
            preysValueField.Name = "preyIds";
            preysValueField.Type = new CodeTypeReference(typeof(IEnumerable<int>));
            var initialiseExpression = new CodeArrayCreateExpression(
            new CodeTypeReference(typeof(int)));

            foreach(var prey in ((IPredator)animal).Preys)
            {
                initialiseExpression.Initializers.Add(new CodePrimitiveExpression(prey.Id));
            }
            preysValueField.InitExpression = initialiseExpression;
            targetClass.Members.Add(preysValueField);

            CodeMemberProperty preysProperty = new CodeMemberProperty();
            preysProperty.Attributes = MemberAttributes.Public;
            preysProperty.Name = "PreyIds";
            preysProperty.HasGet = true;
            preysProperty.GetStatements.Add(new CodeMethodReturnStatement(
                new CodeFieldReferenceExpression(
                new CodeThisReferenceExpression(), "preyIds")));
            preysProperty.HasSet = false;
            targetClass.Members.Add(preysProperty);
        }
    }
}