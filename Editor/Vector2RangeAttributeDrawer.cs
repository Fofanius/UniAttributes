using UnityEditor;
using UnityEngine;

namespace UniAttributes.Editor
{
    [CustomPropertyDrawer(typeof(Vector2RangeAttribute))]
    public class Vector2RangeAttributeDrawer : PropertyDrawer
    {
        private Vector2RangeAttribute RangeAttribute => (Vector2RangeAttribute)attribute;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var previousColor = GUI.color;

            GUI.color = !IsValid(property) ? Color.red : Color.white;
            {
                var textFieldPosition = position;

                textFieldPosition.width = position.width;
                textFieldPosition.height = position.height;

                EditorGUI.BeginChangeCheck();
                {
                    var value = EditorGUI.Vector2Field(textFieldPosition, label, property.vector2Value);

                    if (EditorGUI.EndChangeCheck())
                    {
                        var rangeAttribute = RangeAttribute;
                        if (rangeAttribute.Clamp)
                        {
                            value.x = Mathf.Clamp(value.x, rangeAttribute.MinX, rangeAttribute.MaxX);
                            value.y = Mathf.Clamp(value.y, rangeAttribute.MinY, rangeAttribute.MaxY);
                        }

                        property.vector2Value = value;
                    }
                }

                var helpPosition = position;

                helpPosition.y += 16;
                helpPosition.height = 16;

                DrawHelpBox(helpPosition, property);
            }
            GUI.color = previousColor;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (!IsValid(property))
            {
                return 32;
            }

            return base.GetPropertyHeight(property, label);
        }

        private void DrawHelpBox(Rect position, SerializedProperty prop)
        {
            if (IsValid(prop)) return;

            EditorGUI.HelpBox(position, $"Invalid Range X [{RangeAttribute.MinX}]-[{RangeAttribute.MaxX}] Y [{RangeAttribute.MinY}]-[{RangeAttribute.MaxY}]", MessageType.Error);
        }

        private bool IsValid(SerializedProperty prop)
        {
            var vector = prop.vector2Value;
            return vector.x >= RangeAttribute.MinX && vector.x <= RangeAttribute.MaxX && vector.y >= RangeAttribute.MinY && vector.y <= RangeAttribute.MaxY;
        }
    }
}
