using UnityEditor;
using UnityEngine;

namespace EasyGuidFields.Editor
{
    [CustomPropertyDrawer(typeof(SmartGuid))]
    public class SmartGuidPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var valueProperty = property.FindPropertyRelative("_value");
            var lockedProperty = property.FindPropertyRelative("_locked");
            var value = valueProperty.stringValue;
            var locked = lockedProperty.boolValue;

            value = GuidEditorGUI.DrawGUID(position, label, value, ref locked);

            valueProperty.stringValue = value;
            lockedProperty.boolValue = locked;
        }
    }
}