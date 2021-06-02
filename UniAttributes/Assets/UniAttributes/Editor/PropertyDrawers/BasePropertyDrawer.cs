using UnityEditor;

namespace UniAttributes.Editor.PropertyDrawers
{
    public class BasePropertyDrawer : PropertyDrawer
    {
        public float GetPropertyHeight(SerializedProperty property) => EditorGUI.GetPropertyHeight(property, true);

        public bool IsSpecialProperty(string propertyName)
        {
            return propertyName switch
            {
                "m_Script" => true,
                _ => false
            };
        }
    }
}
