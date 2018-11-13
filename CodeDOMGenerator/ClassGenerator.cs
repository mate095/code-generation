namespace CodeGeneration.CodeDOMGenerator
{
    using System.IO;
    using System.CodeDom;
    using System.CodeDom.Compiler;
    using CodeGeneration.Generator.Logic;
    using System;

    /// <summary>
    /// ClassGenerator creates a graph using a CodeCompileUnit and  
    /// generates source code for the graph using the CSharpCodeProvider.
    /// </summary>
    public class ClassGenerator
    {
        private ClassTemplateData classTemplate;

        private CodeCompileUnit targetUnit;
        CodeNamespace codeNamespace;
        private CodeTypeDeclaration targetClass;

        /// <summary>
        /// Constructor
        /// </summary>
        public ClassGenerator(ClassTemplateData classTemplate, CodeCompileUnit targetUnit)
        {
            this.classTemplate = classTemplate;
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
            AddConstructor();
            AddReadonylProperties();
            AddPropertiesWithSetter();
        }
        
        private void InitClass()
        {
            targetClass = new CodeTypeDeclaration(classTemplate.Name);
            codeNamespace = new CodeNamespace("CodeGeneration.GenerationResult.CodeDOM");
            if (classTemplate.HasBase)
            {
                targetClass.BaseTypes.Add(new CodeTypeReference(classTemplate.BaseClassName));
            }
            targetClass.BaseTypes.Add(new CodeTypeReference(classTemplate.InterfaceName));
            codeNamespace.Types.Add(targetClass);
            targetUnit.Namespaces.Add(codeNamespace);
        }

        private void AddConstructor()
        {
            CodeConstructor constructor = new CodeConstructor();
            constructor.Attributes = MemberAttributes.Public;

            foreach(var paramter in classTemplate.ConstructorParamters)
            {
                constructor.Parameters.Add(new CodeParameterDeclarationExpression(TypeResolver(paramter.Type), paramter.NameStartWithLowerCase));
            }

            if (classTemplate.HasBase)
            {
                foreach(var baseArg in classTemplate.BeseReadOnlyPropertiesWithOutDefaultValue)
                {
                    constructor.BaseConstructorArgs.Add(new CodeSnippetExpression(baseArg.NameStartWithLowerCase));
                }
            }

            foreach (var property in classTemplate.ReadOnlyPropertiesWithOutDefaultValue)
            {
                var nameReference = new CodePropertyReferenceExpression();
                nameReference.PropertyName = property.Name;
                constructor.Statements.Add(new CodeAssignStatement(nameReference, new CodeArgumentReferenceExpression(property.NameStartWithLowerCase)));
            }

            targetClass.Members.Add(constructor);
        }

        private void AddReadonylProperties()
        {
            foreach(var propertyTemplate in classTemplate.ReadOnlyPropertiesWithDefaultValue)
            {
                CodeMemberProperty property = new CodeMemberProperty();
                property.Attributes = MemberAttributes.Public;
                property.Name = propertyTemplate.Name;
                property.HasGet = true;
                property.GetStatements.Add(new CodeMethodReturnStatement(
                    new CodePrimitiveExpression(propertyTemplate.DefaultValue)));
                property.HasSet = false;
                property.Type = new CodeTypeReference(TypeResolver(propertyTemplate.Type));
                targetClass.Members.Add(property);
            }

            foreach (var propertyTemplate in classTemplate.ReadOnlyPropertiesWithOutDefaultValue)
            {
                CodeMemberProperty property = new CodeMemberProperty();
                property.Attributes = MemberAttributes.Public;
                property.Name = propertyTemplate.Name;
                property.HasGet = true;
                property.HasSet = false;
                property.Type = new CodeTypeReference(TypeResolver(propertyTemplate.Type));
                targetClass.Members.Add(property);
            }
        }

        private void AddPropertiesWithSetter()
        {
            foreach (var propertyTemplate in classTemplate.PropertiesWithSetter)
            {
                CodeMemberField valueField = new CodeMemberField();
                valueField.Attributes = MemberAttributes.Private;
                valueField.Name = propertyTemplate.NameStartWithLowerCase;
                valueField.Type = new CodeTypeReference(TypeResolver(propertyTemplate.Type));
                targetClass.Members.Add(valueField);

                CodeMemberProperty property = new CodeMemberProperty();
                property.Attributes = MemberAttributes.Public;
                property.Name = propertyTemplate.Name;
                property.HasGet = true;
                property.GetStatements.Add(new CodeMethodReturnStatement(
                    new CodeFieldReferenceExpression(
                    new CodeThisReferenceExpression(), propertyTemplate.NameStartWithLowerCase)));
                property.HasSet = true;
                property.SetStatements.Add(
                    new CodeAssignStatement(
                        new CodeFieldReferenceExpression(
                            new CodeThisReferenceExpression(), propertyTemplate.NameStartWithLowerCase), new CodePropertySetValueReferenceExpression()));
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