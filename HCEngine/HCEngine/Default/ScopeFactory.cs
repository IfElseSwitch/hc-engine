using System;
using System.Reflection;

namespace HCEngine.Default
{
    /// <summary>
    /// Default scope factory. Uses reflection to find all the exposed types and calls in all loaded assemblies.
    /// </summary>
    public class ScopeFactory : IScopeFactory
    {
        /// <summary>
        /// Creates the default scope and fills its with all Exposed calls and types in the loaded assemblies.
        /// </summary>
        /// <returns>Initialized default scope</returns>
        public IExecutionScope MakeScope()
        {
            IExecutionScope scope = new ExecutionScope();

            Assembly[] asms = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var assembly in asms)
            {
                ExploreAssembly(assembly, ref scope);
            }

            return scope;
        }

        private void ExploreAssembly(Assembly assembly, ref IExecutionScope scope)
        {
            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                if (!type.IsPublic)
                    continue;
                ExploreType(type, ref scope);
            }
        }

        private void ExploreType(Type type, ref IExecutionScope scope)
        {
            TryExposedType(type, ref scope);
            var methods = type.GetMethods();
            foreach(var method in methods)
            {
                if (!method.IsPublic)
                    continue;
                if (!method.IsStatic)
                    continue;
                TryExposedCall(method, ref scope);
            }
        }

        private void TryExposedCall(MethodInfo method, ref IExecutionScope scope)
        {
            var candidate = Attribute.GetCustomAttribute(method, typeof(ExposedCallAttribute));
            ExposedCallAttribute exposed = candidate as ExposedCallAttribute;
            if (exposed == null)
                return;
            string name = "";
            if (string.IsNullOrEmpty(exposed.NameOverride))
            {
                name = string.Format("{0}{1}", char.ToLower(method.Name[0]), method.Name.Substring(1));
            }
            else
            {
                name = exposed.NameOverride;
            }
            scope[name] = method;
        }

        private void TryExposedType(Type type, ref IExecutionScope scope)
        {
            var candidate = Attribute.GetCustomAttribute(type, typeof(ExposedTypeAttribute));
            ExposedTypeAttribute exposed = candidate as ExposedTypeAttribute;
            if (exposed == null)
                return;
            if (exposed.LinkToType != null)
            {
                AddType(exposed.LinkToType, exposed, ref scope);
                return;
            }
            AddType(type, exposed, ref scope);
        }

        private void AddType(Type type, ExposedTypeAttribute exposed, ref IExecutionScope scope)
        {
            string name = type.Name;
            if (!string.IsNullOrEmpty(exposed.NameOverride))
            {
                name = exposed.NameOverride;
            }
            else if (name.Contains("'"))
            {
                name = name.Split('\'')[0];
            }
            scope[name] = type;
            if (exposed.ConstantReaderType != null)
            {
                scope[string.Format("cr:{0}", name)] = ExposedTypeAttribute.ResolveConstantReader(exposed);
            }
        }
    }
}
