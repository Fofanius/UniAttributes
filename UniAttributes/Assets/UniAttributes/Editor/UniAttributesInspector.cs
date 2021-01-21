using UnityEditor;
using UnityEngine;

namespace UniAttributes.Editor
{
    [CustomEditor(typeof(MonoBehaviour), true)]
    public class UniAttributesInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            ButtonsEditorUtility.DrawButtons(target);
        }
    }
}
