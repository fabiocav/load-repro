Console.WriteLine(TestDep.TestClass.GetTypeName());

Console.WriteLine("Press enter to run load type with dependency on System.Diagnosics.DiagnosticSource 7.0 ...");
Console.ReadLine();

Console.WriteLine(TestDep70.TestClass2.GetTypeName());

//var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(@"C:\Users\facaval\source\repos\Loader\Worker\bin\System.Diagnostics.DiagnosticSource.dll");
//var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(@"C:\Program Files\dotnet\shared\Microsoft.NETCore.App\7.0.5\System.Diagnostics.DiagnosticSource.dll");

//Console.WriteLine(assembly.FullName);