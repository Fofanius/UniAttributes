using UnityEditor;
using UnityEngine;

namespace UniAttributes.Editor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(ScriptableSubInspectorAttribute))]
    public class SubInspectorPropertyDrawer : BasePropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUILayout.PropertyField(property, label);

            EditorGUI.indentLevel++;
            {
                if (property.objectReferenceValue is ScriptableObject so)
                {
                    property.isExpanded = EditorGUILayout.Foldout(property.isExpanded, $"Edit: {label.text}");
                    EditorGUI.indentLevel++;
                    {
                        if (property.isExpanded)
                        {
                            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                            {
                                var serializedObject = new SerializedObject(so);
                                {
                                    using var propertyIterator = serializedObject.GetIterator();
                                    while (propertyIterator.NextVisible(true))
                                    {
                                        if (IsSpecialProperty(propertyIterator.name)) continue;

                                        var soProperty = serializedObject.FindProperty(propertyIterator.name);
                                        EditorGUILayout.PropertyField(soProperty);
                                    }
                                }
                                serializedObject.ApplyModifiedProperties();
                            }
                            EditorGUILayout.EndVertical();
                        }
                    }
                    EditorGUI.indentLevel--;
                }
                else if (property.objectReferenceValue != null)
                {
                    EditorGUILayout.LabelField($"Can draw sub inspector only for {nameof(ScriptableObject)}");
                }
            }
            EditorGUI.indentLevel--;
        }
    }
}
