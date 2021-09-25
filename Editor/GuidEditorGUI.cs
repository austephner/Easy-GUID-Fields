using System;
using UnityEditor;
using UnityEngine;

namespace EasyGuidFields.Editor
{
    public static class GuidEditorGUI
    {
        public static string DrawGUID(Rect position, GUIContent label, string guid)
        {
            position.width -= 30;

            guid = EditorGUI.TextField(position, label, guid);

            position.x += position.width;
            position.width = 30;

            if (GUI.Button(position, new GUIContent("R", "Randomize this GUID value")))
            {
                EditorGUI.FocusTextInControl(null);
                guid = Guid.NewGuid().ToString();
            }
            
            return guid;
        }
        
        public static string DrawGUID(Rect position, GUIContent label, string guid, ref bool locked)
        {
            var beforeDrawEnabledStatus = GUI.enabled;
            GUI.enabled = !locked;
            
            position.width -= 100;

            guid = EditorGUI.TextField(position, label, guid);

            position.x += position.width;
            position.width = 30;

            if (GUI.Button(position, new GUIContent("R", "Randomize this GUID value")))
            {
                EditorGUI.FocusTextInControl(null);
                guid = Guid.NewGuid().ToString();
            }

            GUI.enabled = beforeDrawEnabledStatus;
            
            position.x += 35;
            position.width = 30;

            if (GUI.Button(position, new GUIContent("C", "Copy to clipboard")))
            {
                EditorGUIUtility.systemCopyBuffer = guid;
            }
            
            position.x += 35;
            position.width = 30;
            
            var lockedContent = EditorGUIUtility.IconContent(locked ? "LockIcon-On" : "LockIcon");
    
            lockedContent.tooltip =
                locked
                    ? "Unlock this GUID for editing."
                    : "Lock this GUID so that it can't be edited.";

            if (GUI.Button(position, lockedContent))
            {
                locked = locked != true;
            }
            
            return guid;
        }
        
        public static string EditorGUILayoutGuidField(GUIContent label, string guid)
        {
            using (new GUILayout.HorizontalScope())
            {
                guid = UnityEditor.EditorGUILayout.TextField(label, guid);

                if (GUILayout.Button(new GUIContent("R", "Randomize"), GUILayout.ExpandWidth(false)))
                {
                    guid = Guid.NewGuid().ToString();
                }
            }

            return guid;
        }
    }
}