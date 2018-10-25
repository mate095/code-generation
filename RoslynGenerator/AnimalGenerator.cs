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

            

            var fileName = $"{animal.Name}.cs";

            CreateCodeFile(@namespace, fileName);
        }

        public void CreateCodeFile(SyntaxNode @newSyntaxNode, string fileName)
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
                    var @oldSyntaxNode = document.GetSyntaxRootAsync().Result;
                    documentEditor.ReplaceNode(@oldSyntaxNode, @newSyntaxNode.NormalizeWhitespace());
                    var modifiedDocument = documentEditor.GetChangedDocument();
                    workspace.TryApplyChanges(modifiedDocument.Project.Solution);
                }
                else
                {
                    // Normalize and get code as string.
                    var code = @newSyntaxNode.NormalizeWhitespace().ToFullString();
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
