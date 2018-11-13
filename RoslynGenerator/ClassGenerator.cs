namespace CodeGeneratin.RoslynGenerator
{
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using CodeGeneration.Generator.Logic;

    /// <summary> 
    /// Generator class for classes
    /// </summary>
    public class ClassGenerator : GeneratorBase
    {
        private ClassTemplateData classTemplate;

        /// <summary> 
        /// Constructor
        /// </summary>
        public ClassGenerator(ClassTemplateData classTemplate)
        {
            this.classTemplate = classTemplate;
        }

        /// <summary> 
        /// Create a class for the given template.
        /// </summary>
        public void CreateClass()
        {
            var headerComment = CreateHeaderComment();

            var @namespace = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName("CodeGeneration.GenerationResult.Roslyn"))
                 .WithNamespaceKeyword(headerComment).NormalizeWhitespace();

            var classDeclaration = SyntaxFactory.ClassDeclaration(classTemplate.Name);

            classDeclaration = classDeclaration.AddModifiers(SyntaxFactory.Token(SyntaxKind.InternalKeyword), SyntaxFactory.Token(SyntaxKind.PartialKeyword));

            classDeclaration = AddBaseListTypes(classDeclaration);

            foreach (var property in classTemplate.PropertiesWithSetter)
            {
                classDeclaration = classDeclaration.AddMembers(CreateFieldForProperty(property));
            }

            var constructor = CreateConstructor();
            classDeclaration = classDeclaration.AddMembers(constructor);

            foreach (var propetyTemplate in classTemplate.ReadOnlyPropertiesWithOutDefaultValue)
            {
                classDeclaration = classDeclaration.AddMembers(CreateReadOnlyProperty(propetyTemplate));
            }

            foreach (var propetyTemplate in classTemplate.ReadOnlyPropertiesWithDefaultValue)
            {
                classDeclaration = classDeclaration.AddMembers(CreateReadOnlyPropertyWithDefultValue(propetyTemplate));
            }

            foreach (var property in classTemplate.PropertiesWithSetter)
            {
                classDeclaration = classDeclaration.AddMembers(CreatePropertyWithSetter(property));
            }

            @namespace = @namespace.AddMembers(classDeclaration);

            var fileName = $"{classTemplate.Name}.cs";

            CreateCodeFile(@namespace, fileName);
        }

        private ClassDeclarationSyntax AddBaseListTypes(ClassDeclarationSyntax classDeclaration)
        {
            if (classTemplate.HasBase)
            {
                return classDeclaration.AddBaseListTypes(
                    SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(classTemplate.BaseClassName)),
                    SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(classTemplate.InterfaceName)));
            }
            else
            {
                return classDeclaration.AddBaseListTypes(SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(classTemplate.InterfaceName)));
            }
        }
        
        private ConstructorDeclarationSyntax CreateConstructor()
        {
            List<ParameterSyntax> parameterList = new List<ParameterSyntax>();
      
            foreach (var paramter in classTemplate.ConstructorParamters)
            {
                parameterList.Add(SyntaxFactory.Parameter(SyntaxFactory.Identifier(paramter.NameStartWithLowerCase))
                    .WithType(SyntaxFactory.ParseTypeName(paramter.Type)));
            };

            var construcorBlock = SyntaxFactory.Block();

            foreach (var property in classTemplate.ReadOnlyPropertiesWithOutDefaultValue)
            {
                var syntax = SyntaxFactory.ParseStatement($"{property.Name} = {property.NameStartWithLowerCase};");
                construcorBlock = construcorBlock.AddStatements(syntax);
            }

            ConstructorDeclarationSyntax constructor;

            if (classTemplate.HasBase)
            {
                List<ArgumentSyntax> arguments = new List<ArgumentSyntax>();
                foreach(var argument in classTemplate.BeseReadOnlyPropertiesWithOutDefaultValue)
                {
                    arguments.Add(SyntaxFactory.Argument(SyntaxFactory.IdentifierName(argument.NameStartWithLowerCase)));
                }

                constructor = SyntaxFactory.ConstructorDeclaration(classTemplate.Name).AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddParameterListParameters(parameterList.ToArray()).WithBody(construcorBlock)
                .WithInitializer(SyntaxFactory.ConstructorInitializer(SyntaxKind.BaseConstructorInitializer)
                .AddArgumentListArguments(arguments.ToArray()));
            }
            else
            {
                constructor = SyntaxFactory.ConstructorDeclaration(classTemplate.Name).AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddParameterListParameters(parameterList.ToArray()).WithBody(construcorBlock);
            }

            return constructor;
        }

        private PropertyDeclarationSyntax CreateReadOnlyProperty(PropertyTemplateData propertyTemplate)
        {
            return SyntaxFactory.PropertyDeclaration(SyntaxFactory.ParseTypeName(propertyTemplate.Type), propertyTemplate.Name)
                            .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                            .AddAccessorListAccessors(
                                SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)));
        }

        private PropertyDeclarationSyntax CreateReadOnlyPropertyWithDefultValue(PropertyTemplateData propertyTemplate)
        {
            return SyntaxFactory.PropertyDeclaration(SyntaxFactory.ParseTypeName(propertyTemplate.Type), propertyTemplate.Name)
                            .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                            .WithExpressionBody(
                                SyntaxFactory.ArrowExpressionClause(
                                    SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(propertyTemplate.DefaultValue))))
                            .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        }

        
        private FieldDeclarationSyntax CreateFieldForProperty(PropertyTemplateData propertyTemplate)
        {
            return SyntaxFactory.FieldDeclaration(SyntaxFactory
                .VariableDeclaration(SyntaxFactory.ParseTypeName(propertyTemplate.Type)).AddVariables(SyntaxFactory.VariableDeclarator(propertyTemplate.NameStartWithLowerCase)))
                .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PrivateKeyword)));
        }

        private PropertyDeclarationSyntax CreatePropertyWithSetter(PropertyTemplateData propertyTemplate)
        {
            return SyntaxFactory.PropertyDeclaration(SyntaxFactory.ParseTypeName(propertyTemplate.Type), propertyTemplate.Name)
                            .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                            .AddAccessorListAccessors(
                                SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                                .WithBody(SyntaxFactory.Block(SyntaxFactory.ParseStatement($"return {propertyTemplate.NameStartWithLowerCase};"))),
                                SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                                .WithBody(SyntaxFactory.Block(SyntaxFactory.ParseStatement($"{propertyTemplate.NameStartWithLowerCase} = value;"))));
        }

        
    }
}
