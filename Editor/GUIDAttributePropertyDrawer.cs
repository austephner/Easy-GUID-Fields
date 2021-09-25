using UnityEditor;
using UnityEngine;

namespace EasyGuidFields.Editor
{
    [CustomPropertyDrawer(typeof(GUIDAttribute))]
    public class GuidAttributePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            property.stringValue = GUIDEditorGUI.DrawGUID(position, label, property.stringValue);
        }
    }
}