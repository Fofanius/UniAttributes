using UnityEditor;
using UnityEngine;

namespace UniAttributes.Editor
{
    public static class ButtonsEditorUtility
    {
        public static void DrawButtons(Object target)
        {
            var methods = ReflectionUtility.GetMethodsWithAttribute<MonoBehaviour, ButtonAttribute>(target as MonoBehaviour);

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            {
                foreach (var method in methods)
                {
                    var isSimpleAction = ReflectionUtility.IsSimpleAction(method.Key);

                    GUI.enabled = (!method.Value.OnlyInPlayMode || EditorApplication.isPlaying) && isSimpleAction;
                    {
                        var current = GUI.color;
                        GUI.color = isSimpleAction ? current : Color.red;
                        {
                            var actionName = string.IsNullOrWhiteSpace(method.Value.Name) ? method.Key.Name : method.Value.Name;
                            var content = isSimpleAction ? new GUIContent(actionName) : new GUIContent(actionName, "Метод должен иметь сигнатуру делегата Action.");

                            if (GUILayout.Button(content))
                            {
                                ReflectionUtility.InvokeSimpleAction(method.Key, target);
                            }
                        }
                        GUI.color = current;
                    }
                    GUI.enabled = true;
                }
            }
            EditorGUILayout.EndHorizontal();
        }
    }
}
