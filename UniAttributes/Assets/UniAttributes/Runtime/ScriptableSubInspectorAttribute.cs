using System;
using UnityEngine;

namespace UniAttributes
{
    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public class ScriptableSubInspectorAttribute : PropertyAttribute { }
}
