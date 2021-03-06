using System.Diagnostics.CodeAnalysis;

[assembly:
    SuppressMessage("Microsoft.Design", "CA1007:UseGenericsWhereAppropriate", Scope = "member",
        Target = "HCEngine.IConstantReader.#Try(System.String,System.Object&)")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Scope = "type",
        Target = "HCEngine.DefaultImplementations.ScriptExecution")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "1",
        Scope = "member",
        Target = "HCEngine.HCEngineException.#.ctor(System.String,HCEngine.ISourceReader,System.String)")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Scope = "type",
        Target = "HCEngine.IScriptExecution")]
// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc.
//
// To add a suppression to this file, right-click the message in the 
// Code Analysis results, point to "Suppress Message", and click 
// "In Suppression File".
// You do not need to add suppressions to this file manually.