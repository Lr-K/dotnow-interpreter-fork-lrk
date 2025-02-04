﻿#if ROSLYNCSHARP
using System.Reflection;
using System.Threading.Tasks;
using dotnow;
using dotnow.Reflection;

namespace RoslynCSharp
{
    internal class InterpretedScriptPropertyDataProxy : IScriptDataProxy
    {
        // Private
        private ScriptType scriptType = null;
        private ScriptProxy scriptProxy = null;
        private bool isStatic = false;
        private bool throwOnError = true;

        // Properties
        public object this[string name]
        {
            get { return GetValue(name); }
            set { SetValue(name, value); }
        }

        // Constructor
        public InterpretedScriptPropertyDataProxy(ScriptType type, ScriptProxy proxy, bool isStatic, bool throwOnError)
        {
            this.scriptType = type;
            this.scriptProxy = proxy;
            this.isStatic = isStatic;
            this.throwOnError = throwOnError;
        }

        // Methods
        public virtual object GetValue(string name)
        {
            try
            {
                // Try to get a property with the specified name
                PropertyInfo info = scriptType.FindCachedProperty(name, isStatic);

                // Check for property not found
                if (info == null)
                    throw new TargetException(string.Format("Type '{0}' does not define a property called '{1}'", scriptType, name));

                // Select the target instance
                object instance = (scriptProxy != null)
                    ? scriptProxy.Instance
                    : null;

                // Support interop
                if ((info is CLRProperty) == false && instance.IsCLRInstance() == true)
                    instance = instance.Unwrap();

                // Attempt to get the property value
                return info.GetValue(instance);
            }
            catch
            {
                if (throwOnError == true)
                    throw;
            }
            return null;
        }

        public void SetValue(string name, object value)
        {
            try
            {
                // Try to get a property with the specified name
                PropertyInfo info = scriptType.FindCachedProperty(name, isStatic);

                // Check for property not found
                if (info == null)
                    throw new TargetException(string.Format("Type '{0}' does not define a property called '{1}'", scriptType, name));

                // Select the target instance
                object instance = (scriptProxy != null)
                    ? scriptProxy.Instance
                    : null;

                // Support interop
                if ((info is CLRProperty) == false && instance.IsCLRInstance() == true)
                    instance = instance.Unwrap();

                // Attempt to set the value
                info.SetValue(instance, value);
            }
            catch
            {
                // Check for safe handling
                if (throwOnError == true)
                    throw;
            }
        }
    }
}
#endif