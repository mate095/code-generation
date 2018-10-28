namespace CodeGeneratin.RoslynGenerator
{
    using System.Linq;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.Text;
    using Microsoft.CodeAnalysis.MSBuild;
    using System;
    using CodeGeneration.DSL;
    using Microsoft.CodeAnalysis.Editing;
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    /// <summary> 
    /// Generator class for animal classes
    /// </summary>
    public class AnimalGenerator
    {
        private IAnimal animal;

        /// <summary> 
        /// Constructor
        /// </summary>
        public AnimalGenerator(IAnimal animal)
        {
            this.animal = animal;
        }

        /// <summary> 
        /// Create a class for the given animal.
        /// </summary>
        public void CreateAnimal()
        {
            var @namespace = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName("CodeGeneration.GenerationResult.Roslyn")).NormalizeWhitespace();

            //  Create a class: (class Animal.Name)
            var classDeclaration = SyntaxFactory.ClassDeclaration(animal.Name);

            // Add the public modifier: (public class)
            classDeclaration = classDeclaration.AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));

            var constructor = CreateConstructor();
            var nameProperty = CreateNameProperty();
            var legProperty = CreateNumberOfLegProperty();
            
            if (animal is IPredator)
            {
                var preysField = CreatePreysField();
                var preyProperty = CreatePreysProperty();
                classDeclaration = classDeclaration.AddMembers(preysField, constructor, nameProperty, legProperty, preyProperty);

                var genericUsing = CreateUsingForSystemGeneric();
                @namespace  = @namespace.AddUsings(genericUsing);
            } 
            else
            {
                classDeclaration = classDeclaration.AddMembers(constructor, nameProperty, legProperty);
            }

            // Add the class to the namespace.
            @namespace = @namespace.AddMembers(classDeclaration);

            var fileName = $"{animal.Name}.cs";

            CreateCodeFile(@namespace, fileName);
        }

        private ConstructorDeclarationSyntax CreateConstructor()
        {
            List<ParameterSyntax> parameterList = new List<ParameterSyntax>
            {
                SyntaxFactory.Parameter(SyntaxFactory.Identifier("name")).WithType(SyntaxFactory.ParseTypeName("string"))
            };

            var syntax = SyntaxFactory.ParseStatement("Name = name;");

            var construcorBlock = SyntaxFactory.Block(syntax);

            var constructor = SyntaxFactory.ConstructorDeclaration(animal.Name).AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddParameterListParameters(parameterList.ToArray()).WithBody(construcorBlock);
            return constructor;
        }

        private PropertyDeclarationSyntax CreateNameProperty()
        {
            return SyntaxFactory.PropertyDeclaration(SyntaxFactory.ParseTypeName("string"), "Name")
                            .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                            .AddAccessorListAccessors(
                                SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                                SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)));
        }

        private PropertyDeclarationSyntax CreateNumberOfLegProperty()
        {
            return SyntaxFactory.PropertyDeclaration(SyntaxFactory.ParseTypeName("int"), "NumberOfLegs")
                            .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                            .WithExpressionBody(
                                SyntaxFactory.ArrowExpressionClause(
                                    SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(animal.NumberOfLegs))))
                            .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        }

        private UsingDirectiveSyntax CreateUsingForSystemGeneric()
        {
            return SyntaxFactory.UsingDirective(
            SyntaxFactory.QualifiedName(
                SyntaxFactory.QualifiedName(
                    SyntaxFactory.IdentifierName("System"),
                    SyntaxFactory.IdentifierName("Collections")),
                SyntaxFactory.IdentifierName("Generic")));
        }
        
        private FieldDeclarationSyntax CreatePreysField()
        {
            return SyntaxFactory.FieldDeclaration(SyntaxFactory
                .VariableDeclaration(SyntaxFactory.GenericName(SyntaxFactory.Identifier("IEnumerable"))
                .WithTypeArgumentList(
                    SyntaxFactory.TypeArgumentList(
                        SyntaxFactory.SingletonSeparatedList<TypeSyntax>(
                            SyntaxFactory.PredefinedType(
                                SyntaxFactory.Token(SyntaxKind.IntKeyword))))))
                .WithVariables(
                    SyntaxFactory.SingletonSeparatedList(
                        SyntaxFactory.VariableDeclarator(
                            SyntaxFactory.Identifier("preyIds")))))
                .WithModifiers(
                    SyntaxFactory.TokenList(
                        SyntaxFactory.Token(SyntaxKind.PrivateKeyword)));
        }

        private PropertyDeclarationSyntax CreatePreysProperty()
        {
            var initList = CreatePreysInitializer();

            return SyntaxFactory.PropertyDeclaration(SyntaxFactory.ParseTypeName("IEnumerable<int>"), "Preys")
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .WithExpressionBody(
                    SyntaxFactory.ArrowExpressionClause(
                        SyntaxFactory.BinaryExpression(
                            SyntaxKind.CoalesceExpression, SyntaxFactory.IdentifierName("preyIds"), SyntaxFactory.ParenthesizedExpression(
                                SyntaxFactory.AssignmentExpression(
                                    SyntaxKind.SimpleAssignmentExpression,
                                    SyntaxFactory.IdentifierName("preyIds"),
                                    SyntaxFactory.ObjectCreationExpression(
                                        SyntaxFactory.GenericName(
                                            SyntaxFactory.Identifier("List"))
                                            .WithTypeArgumentList(SyntaxFactory.TypeArgumentList(
                                                SyntaxFactory.SingletonSeparatedList<TypeSyntax>(
                                            SyntaxFactory.PredefinedType(
                                                SyntaxFactory.Token(SyntaxKind.IntKeyword))))))
                                            .WithInitializer(initList))))))
                .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        }

        private InitializerExpressionSyntax CreatePreysInitializer()
        {
            var preys = new List<SyntaxNodeOrToken>();

            foreach(var prey in ((IPredator)animal).Preys)
            {
                preys.Add(SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(prey.Id)));
            }

            return SyntaxFactory.InitializerExpression(
                SyntaxKind.CollectionInitializerExpression, 
                SyntaxFactory.SeparatedList<ExpressionSyntax>(preys.ToArray()));
        }

        private void CreateCodeFile(SyntaxNode newSyntaxNode, string fileName)
        {
            using (var workspace = MSBuildWorkspace.Create())
            {
                workspace.WorkspaceFailed += (s, e) => { Console.WriteLine(e.Diagnostic); };
                var solution = workspace.OpenSolutionAsync("..\\..\\CodeGeneration.sln").Result;
                var project = solution.Projects.Single(x => x.Name == "GenerationResult");

                var filePath = GetFilePath(project.FilePath, fileName);
                var document = project.Documents.SingleOrDefault(x => x.FilePath == filePath);
                

                if(document != null)
                {
                    var documentEditor = DocumentEditor.CreateAsync(document).Result;
                    var oldSyntaxNode = document.GetSyntaxRootAsync().Result;
                    documentEditor.ReplaceNode(oldSyntaxNode, newSyntaxNode.NormalizeWhitespace());
                    var modifiedDocument = documentEditor.GetChangedDocument();
                    workspace.TryApplyChanges(modifiedDocument.Project.Solution);
                }
                else
                {
                    // Normalize and get code as string.
                    var code = newSyntaxNode.NormalizeWhitespace().ToFullString();
                    var sourceText = SourceText.From(code);

                    var folders = new string[] { "_Generated", "Roslyn" };

                    var newDocument = project.AddDocument(fileName, sourceText, folders, project.FilePath);
                    workspace.TryApplyChanges(newDocument.Project.Solution);
                }
            }
        }

        private string GetFilePath(string projectFielPath, string fileName)
        {
            var items = projectFielPath.Split('\\');
            var projectFiel = items.Last();
            projectFielPath = projectFielPath.Remove(projectFielPath.Length - projectFiel.Length, projectFiel.Length);

            return $"{projectFielPath}_Generated\\Roslyn\\{fileName}";
        }
    }
}
