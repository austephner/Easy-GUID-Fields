using System;
using UnityEditor;
using UnityEngine;

namespace uGUID.Editor
{
    [CustomPropertyDrawer(typeof(GUIDAttribute))]
    public class GuidAttributePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(property, label);
            if (GUILayout.Button(new GUIContent("R", "Randomize"), GUILayout.ExpandWidth(false)))
            {
                property.stringValue = Guid.NewGuid().ToString();
            }
            EditorGUILayout.EndHorizontal();
        }
    }
}