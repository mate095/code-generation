namespace CodeGeneratin.RoslynGenerator
{
    using CodeGeneration.Generator.Logic;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    /// <summary> 
    /// Generator class for interfaces
    /// </summary>
    class InterfaceGenerator : GeneratorBase
    {

        private InterfaceTemplateData interfaceTemplate;

        /// <summary> 
        /// Constructor
        /// </summary>
        public InterfaceGenerator(InterfaceTemplateData interfaceTemplate)
        {
            this.interfaceTemplate = interfaceTemplate;
        }

        /// <summary> 
        /// Create an interface for the given template.
        /// </summary>
        public void CreateInterface()
        {
            var headerComment = CreateHeaderComment();

            var @namespace = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName("CodeGeneration.GenerationResult.Roslyn"))
                 .WithNamespaceKeyword(headerComment).NormalizeWhitespace();

            var interfaceDeclaration = SyntaxFactory.InterfaceDeclaration(interfaceTemplate.Name);

            interfaceDeclaration = interfaceDeclaration.AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));

            foreach (var propertyTemplate in interfaceTemplate.Properties)
            {
                interfaceDeclaration = interfaceDeclaration.AddMembers(CreateProperty(propertyTemplate));
            }

            @namespace = @namespace.AddMembers(interfaceDeclaration);

            var fileName = $"{interfaceTemplate.Name}.cs";

            CreateCodeFile(@namespace, fileName);
        }

        private PropertyDeclarationSyntax CreateProperty(PropertyTemplateData propertyTemplate)
        {
            var propertyDeclaration = SyntaxFactory.PropertyDeclaration(SyntaxFactory.ParseTypeName(propertyTemplate.Type), propertyTemplate.Name)
                            .AddAccessorListAccessors(
                                SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)));

            if (!propertyTemplate.IsReadOnly)
            {
                propertyDeclaration = propertyDeclaration
                    .AddAccessorListAccessors(SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)));
            }

            return propertyDeclaration;
        }
    }
}
