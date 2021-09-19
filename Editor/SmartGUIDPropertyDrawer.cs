using UnityEditor;
using UnityEngine;

namespace QuickGUIDs.Editor
{
    [CustomPropertyDrawer(typeof(SmartGUID))]
    public class SmartGUIDPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var valueProperty = property.FindPropertyRelative("_value");
            var lockedProperty = property.FindPropertyRelative("_locked");
            var value = valueProperty.stringValue;
            var locked = lockedProperty.boolValue;

            value = GUIDEditorGUI.DrawGUID(position, label, value, ref locked);

            valueProperty.stringValue = value;
            lockedProperty.boolValue = locked;
        }
    }
}