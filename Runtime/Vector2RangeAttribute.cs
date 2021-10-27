using System;
using UnityEngine;

namespace UniAttributes
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public class Vector2RangeAttribute : PropertyAttribute
    {
        public float MinX { get; }
        public float MaxX { get; }
        public float MinY { get; }
        public float MaxY { get; }

        public bool Clamp { get; }

        public Vector2RangeAttribute(float minX, float maxX, float minY, float maxY, bool clamp = true)
        {
            MinX = minX;
            MaxX = maxX;
            MinY = minY;
            MaxY = maxY;
            Clamp = clamp;
        }
    }
}
