#region Using directives

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.ConstrainedExecution;

#endregion

//
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
//
[assembly: AssemblyTitle(@"")]
[assembly: AssemblyDescription(@"")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(@"")]
[assembly: AssemblyProduct(@"CodeGeneration")]
[assembly: AssemblyCopyright("")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: System.Resources.NeutralResourcesLanguage("en")]

//
// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:

[assembly: AssemblyVersion(@"1.0.0.0")]
[assembly: ComVisible(false)]
[assembly: CLSCompliant(true)]
[assembly: ReliabilityContract(Consistency.MayCorruptProcess, Cer.None)]

//
// Make the Dsl project internally visible to the DslPackage assembly
//
[assembly: InternalsVisibleTo(@"CodeGeneration.DSL.DslPackage, PublicKey=0024000004800000940000000602000000240000525341310004000001000100A9DE7BB36F4CC37F4EDCCF3A227217CD438A6153CAB93273E4866DBE50153B65588A40C5D172D0668AEB91CB5BAFB4E78A64908C57DB471B703A7E6773B3884737669035A62B217C7F982B6B343BBC466F952151E4FD2DF7C5487299AF671FF865D7D614D1A971EF06313E4408DE46E9E030834FC2CEC696B12E7A48F3EDE0C6")]
[assembly: InternalsVisibleTo(@"CodeGeneration.TestDataCreator, PublicKey=0024000004800000940000000602000000240000525341310004000001000100A9DE7BB36F4CC37F4EDCCF3A227217CD438A6153CAB93273E4866DBE50153B65588A40C5D172D0668AEB91CB5BAFB4E78A64908C57DB471B703A7E6773B3884737669035A62B217C7F982B6B343BBC466F952151E4FD2DF7C5487299AF671FF865D7D614D1A971EF06313E4408DE46E9E030834FC2CEC696B12E7A48F3EDE0C6")]
