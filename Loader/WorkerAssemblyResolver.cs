using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Loader;

namespace Loader
{
    internal class WorkerAssemblyResolver
    {
        private static AssemblyDependencyResolver? _resolver;
        private static bool _initialized;

        public static void Initialize(AssemblyLoadContext context, string workerAssemblyPath)
        {
            if (_initialized)
            {
                throw new InvalidOperationException($"{nameof(WorkerAssemblyResolver)} already initialized");
            }

            _initialized = true;
            _resolver = new AssemblyDependencyResolver(workerAssemblyPath);

            context.Resolving += ResolveWorkerAssembly;
            context.ResolvingUnmanagedDll += ResolveWorkerUnmanagedDll;
        }

        private static IntPtr ResolveWorkerUnmanagedDll(Assembly arg1, string unmanagedDllName)
        {
            string? unmanagedDllPath = _resolver!.ResolveUnmanagedDllToPath(unmanagedDllName);

            if (unmanagedDllPath != null)
            {
                return NativeLibrary.Load(unmanagedDllPath);
            }

            return IntPtr.Zero;
        }

        private static Assembly? ResolveWorkerAssembly(AssemblyLoadContext context, AssemblyName assemblyName)
        {
            string? assemblyPath = _resolver!.ResolveAssemblyToPath(assemblyName);

            if (assemblyPath != null)
            {
                return context.LoadFromAssemblyPath(assemblyPath);
            }

            return null;
        }
    }
}
