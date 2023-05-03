using Microsoft.Extensions.Configuration.EnvironmentVariables;
using System;
using System.Diagnostics;

namespace TestDep
{
    public class TestClass
    {
        public static string GetTypeName()
        {
            return typeof(EnvironmentVariablesConfigurationProvider).AssemblyQualifiedName;
        }
    }
}
