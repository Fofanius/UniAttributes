﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace UniAttributes.Editor
{
    public static class ReflectionUtility
    {
        public const BindingFlags INSTANCE_FLAGS = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        public static IReadOnlyDictionary<MethodInfo, TAttribute> GetMethodsWithAttribute<TTarget, TAttribute>(TTarget target, Func<MethodInfo, bool> rule = default) where TAttribute : Attribute
        {
            if (target == null) throw new ArgumentNullException(nameof(target));
            var type = target.GetType();

            var methods = type.GetMethods(INSTANCE_FLAGS);
            var result = new Dictionary<MethodInfo, TAttribute>();

            foreach (var methodInfo in methods)
            {
                var attribute = methodInfo.GetCustomAttribute<TAttribute>(true);
                if (attribute == default || rule != default && rule(methodInfo)) continue;

                result.Add(methodInfo, attribute);
            }

            return result;
        }

        /// <summary>
        /// Определяет, является ли метод простым (имеет сигнатуру <see cref="Action"/>).
        /// </summary>
        /// <param name="methodInfo">Метод для проверки.</param>
        /// <returns>Является ли метод простым.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool IsAction(MethodInfo methodInfo)
        {
            if (methodInfo == default)
            {
                throw new ArgumentNullException(nameof(methodInfo));
            }

            return methodInfo.GetParameters().Length == 0 && methodInfo.ReturnType == typeof(void);
        }

        /// <summary>
        /// Попытка вызова простого метода у некоторого объекта.
        /// </summary>
        /// <param name="methodInfo">Метод для вызова.</param>
        /// <param name="target">Объект, у которого происходит вызов.</param>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ArgumentNullException"/>
        public static void InvokeAction(MethodInfo methodInfo, object target)
        {
            if (!IsAction(methodInfo))
            {
                throw new ArgumentException(nameof(methodInfo));
            }

            if (target == default)
            {
                throw new ArgumentNullException(nameof(target));
            }

            // var action = (Action) Delegate.CreateDelegate(typeof(Action), target, methodInfo);
            // action.Invoke();

            methodInfo.Invoke(target, null);
        }
    }
}
