using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;

namespace Loader
{
    internal class WorkerLoader
    {
        public static int LoadWorker(string workerAssemblyPath)
        {            
            // Initialize the assembly resolver to ensure we can load worker dependencies
            WorkerAssemblyResolver.Initialize(AssemblyLoadContext.Default, workerAssemblyPath);

            Assembly customerAssembly = Assembly.LoadFrom(workerAssemblyPath);

            MethodInfo? entryPoint = customerAssembly.EntryPoint
                ?? throw new MissingMethodException($"Assembly ('{customerAssembly.FullName}') missing entry point.");

            var parameters = entryPoint.GetParameters().Length > 0 ? new object[] { Environment.GetCommandLineArgs() } : null;

            object? result = entryPoint.Invoke(null, BindingFlags.DoNotWrapExceptions, null, parameters, null);

            int exitCode = 0;
            if (result is not null)
            {
                exitCode = (int)result;
            }

            return exitCode;
        }
    }
}
