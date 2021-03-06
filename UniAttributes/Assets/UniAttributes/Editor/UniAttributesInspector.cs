﻿using UnityEditor;
using UnityEngine;

namespace UniAttributes.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(Object), true)]
    public class UniAttributesInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            this.DrawButtons();
        }
    }
}
