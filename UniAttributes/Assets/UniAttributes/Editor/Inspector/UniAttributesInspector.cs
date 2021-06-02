using UniAttributes.Editor.Inspector.Buttons;
using UnityEditor;
using UnityEngine;

namespace UniAttributes.Editor.Inspector
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
