using Microsoft.Extensions.Configuration.EnvironmentVariables;
using System.Data.Common;
using System.Diagnostics;

namespace TestDep70
{
    public class TestClass2
    {
        public static string GetTypeName()
        {
            return typeof(EnvironmentVariablesConfigurationProvider).AssemblyQualifiedName;
        }
    }
}
