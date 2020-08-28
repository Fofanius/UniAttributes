using System;
using UnityEngine;

namespace UniAttributes.Runtime.Scripts
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class ButtonAttribute : Attribute
    {
        public string Name { get; set; }
        public Color ButtonColor { get; set; }
        public bool OnlyInPlayMode { get; set; }

        public ButtonAttribute()
        {
            Name = string.Empty;
            ButtonColor = Color.white;
        }
    }
}