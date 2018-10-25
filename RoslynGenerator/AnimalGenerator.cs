namespace CodeGeneratin.RoslynGenerator
{
    using System.Linq;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.Text;
    using Microsoft.CodeAnalysis.MSBuild;
    using System;
    using CodeGeneration.DSL;

    public class AnimalGenerator
    {
        /// Create a class for the given animal.
        /// </summary>
        public void CreateAnimal(IAnimal animal)
        {
            // Create a namespace: (namespace CodeGeneration.GenerationResult.Roslyn)
            var @namespace = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName("CodeGeneration.GenerationResult.Roslyn")).NormalizeWhitespace();

            // Add System using statement: (using System)
            @namespace = @namespace.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System")));

            //  Create a class: (class Animal.Name)
            var classDeclaration = SyntaxFactory.ClassDeclaration(animal.Name);

            // Add the public modifier: (public class)
            classDeclaration = classDeclaration.AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));
           
            // Add the class to the namespace.
            @namespace = @namespace.AddMembers(classDeclaration);

            // Normalize and get code as string.
            var code = @namespace
                .NormalizeWhitespace()
                .ToFullString();

            var fileName = $"{animal.Name}.cs";

            CreateCodeFileAsync(code, fileName);
        }

        public void CreateCodeFileAsync(string code, string fileName)
        {
            using (var workspace = MSBuildWorkspace.Create())
            {
                workspace.WorkspaceFailed += (s, e) => { Console.WriteLine(e.Diagnostic); };
                var solution = workspace.OpenSolutionAsync("..\\..\\CodeGeneration.sln").Result;
                var project = solution.Projects.Single(x => x.Name == "GenerationResult");

                var sourceText = SourceText.From(code);

                var folders = new string[] {"_Generated", "Roslyn" };
                
                var document = project.AddDocument(fileName, sourceText, folders, project.FilePath);

                var result = workspace.TryApplyChanges(document.Project.Solution);

            }
        }
    }
}
