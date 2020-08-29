using System;
using System.Collections.Generic;
using System.Reflection;
using UniAttributes.Runtime.Scripts;
using UnityEditor;
using UnityEngine;

namespace UniAttributes.Editor
{
    [CustomEditor(typeof(MonoBehaviour), true)]
    public class UniAttributesInspector : UnityEditor.Editor
    {
        private IDictionary<MethodInfo, ButtonAttribute> _methods;

        private void OnEnable()
        {
            LoadMethod(ref _methods);
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.Space();

            DrawButtons();
        }

        private void LoadMethod(ref IDictionary<MethodInfo, ButtonAttribute> list)
        {
            list = ReflectionUtility.GetMethodsWithAttribute<MonoBehaviour, ButtonAttribute>(target as MonoBehaviour);
        }

        private void DrawButtons()
        {
            foreach (var method in _methods)
            {
                var isSimpleAction = ReflectionUtility.IsSimpleAction(method.Key);

                GUI.enabled = (!method.Value.OnlyInPlayMode || EditorApplication.isPlaying) && isSimpleAction;
                {
                    GUI.color = isSimpleAction ? Color.white : Color.red;
                    {
                        var actionName = string.IsNullOrWhiteSpace(method.Value.Name) ? method.Key.Name : method.Value.Name;
                        var content = isSimpleAction ? new GUIContent(actionName) : new GUIContent(actionName, "Метод должен иметь сигнатуру делегата Action.");

                        if (GUILayout.Button(content))
                        {
                            ReflectionUtility.InvokeSimpleAction(method.Key, target);
                        }
                    }
                    GUI.color = Color.white;
                }
                GUI.enabled = true;
            }
        }
    }
}