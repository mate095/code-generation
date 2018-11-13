﻿namespace CodeGeneratin.RoslynGenerator
{
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.Editing;
    using Microsoft.CodeAnalysis.MSBuild;
    using Microsoft.CodeAnalysis.Text;
    using System;
    using System.Linq;

    public abstract class GeneratorBase
    {
        protected void CreateCodeFile(SyntaxNode newSyntaxNode, string fileName)
        {
            using (var workspace = MSBuildWorkspace.Create())
            {
                workspace.WorkspaceFailed += (s, e) => { Console.WriteLine(e.Diagnostic); };
                var solution = workspace.OpenSolutionAsync("..\\..\\CodeGeneration.sln").Result;
                var project = solution.Projects.Single(x => x.Name == "GenerationResult");

                var filePath = GetFilePath(project.FilePath, fileName);
                var document = project.Documents.SingleOrDefault(x => x.FilePath == filePath);


                if (document != null)
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

        protected string GetFilePath(string projectFielPath, string fileName)
        {
            var items = projectFielPath.Split('\\');
            var projectFiel = items.Last();
            projectFielPath = projectFielPath.Remove(projectFielPath.Length - projectFiel.Length, projectFiel.Length);

            return $"{projectFielPath}_Generated\\Roslyn\\{fileName}";
        }

        protected SyntaxToken CreateHeaderComment()
        {
            return SyntaxFactory.Token(
                SyntaxFactory.TriviaList(
                    new[]{
                        SyntaxFactory.Comment("//------------------------------------------------------------------------------"),
                        SyntaxFactory.Comment("// <auto-generated>"),
                        SyntaxFactory.Comment("//    This code was generated by Roslyn code generator."),
                        SyntaxFactory.Comment("//"),
                        SyntaxFactory.Comment("//    Manual changes to this file may cause unexpected behavior in your application."),
                        SyntaxFactory.Comment("//    Manual changes to this file will be overwritten if the code is regenerated."),
                        SyntaxFactory.Comment("// </auto-generated>"),
                        SyntaxFactory.Comment("//------------------------------------------------------------------------------")}),
                SyntaxKind.NamespaceKeyword,
                SyntaxFactory.TriviaList());
        }
    }
}