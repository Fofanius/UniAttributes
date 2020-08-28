using System;
using System.Collections.Generic;
using System.Reflection;

namespace UniAttributes.Runtime.Scripts
{
    public static class ReflectionUtility
    {
        public const BindingFlags INSTANCE_FLAGS = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        public static IDictionary<TAttribute, MethodInfo> GetMethodsWithAttribute<TTarget, TAttribute>(TTarget target, Func<MethodInfo, bool> rule = default) where TAttribute : Attribute
        {
            var type = target.GetType();
            
            var methods = type.GetMethods(INSTANCE_FLAGS);
            var result = new Dictionary<TAttribute, MethodInfo>();

            foreach (var methodInfo in methods)
            {
                var attribute = methodInfo.GetCustomAttribute<TAttribute>(true);
                if(attribute == default || rule != default && rule(methodInfo)) continue;
                
                result.Add(attribute, methodInfo);
            }
            
            return result;
        }
    }
}