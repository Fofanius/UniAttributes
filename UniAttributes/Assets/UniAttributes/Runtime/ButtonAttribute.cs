using System;

namespace UniAttributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class ButtonAttribute : Attribute
    {
        public string Name { get; set; }
        public bool OnlyInPlayMode { get; set; }

        public ButtonAttribute()
        {
            Name = string.Empty;
        }
    }
}
