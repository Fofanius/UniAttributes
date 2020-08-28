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
        private IDictionary<ButtonAttribute, MethodInfo> _methods;

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

        private void LoadMethod(ref IDictionary<ButtonAttribute, MethodInfo> list)
        {
            list = ReflectionUtility.GetMethodsWithAttribute<MonoBehaviour, ButtonAttribute>(target as MonoBehaviour);
        }

        private void DrawButtons()
        {
            foreach (var method in _methods)
            {
                GUI.enabled = !method.Key.OnlyInPlayMode || EditorApplication.isPlaying;
                {
                    GUI.color = method.Key.ButtonColor;
                    {
                        var actionName = string.IsNullOrWhiteSpace(method.Key.Name) ? method.Key.Name : method.Value.Name;

                        if (GUILayout.Button(actionName))
                        {
                            var action = (Action) Delegate.CreateDelegate(typeof(Action), target, method.Value);
                            action.Invoke();
                        }
                    }
                    GUI.color = Color.white;
                }
                GUI.enabled = true;
            }
        }
    }
}