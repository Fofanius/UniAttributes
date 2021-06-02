using UnityEditor;
using UnityEngine;

namespace UniAttributes.Editor.Inspector.Buttons
{
    public static class ButtonsEditorUtility
    {
        public static void DrawButtons(this UnityEditor.Editor editor)
        {
            if (!editor || !editor.target) return;
            DrawButtons(editor.target);
        }

        public static void DrawButtons(Object target)
        {
            var methods = ReflectionUtility.GetMethodsWithAttribute<Object, ButtonAttribute>(target);

            foreach (var method in methods)
            {
                var isSimpleAction = ReflectionUtility.IsAction(method.Key);

                var guiState = GUI.enabled;
                GUI.enabled = (!method.Value.OnlyInPlayMode || EditorApplication.isPlaying) && isSimpleAction;
                {
                    var current = GUI.color;
                    GUI.color = isSimpleAction ? current : Color.red;
                    {
                        var actionName = string.IsNullOrWhiteSpace(method.Value.Name) ? method.Key.Name : method.Value.Name;
                        var content = isSimpleAction ? new GUIContent(actionName) : new GUIContent(actionName, "Method should have signature of Action delegate.");

                        if (GUILayout.Button(content))
                        {
                            ReflectionUtility.InvokeAction(method.Key, target);
                        }
                    }
                    GUI.color = current;
                }
                GUI.enabled = guiState;
            }
        }
    }
}
