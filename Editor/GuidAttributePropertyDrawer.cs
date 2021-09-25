using UnityEditor;
using UnityEngine;

namespace EasyGuidFields.Editor
{
    [CustomPropertyDrawer(typeof(GuidAttribute))]
    public class GuidAttributePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            property.stringValue = GuidEditorGUI.DrawGUID(position, label, property.stringValue);
        }
    }
}