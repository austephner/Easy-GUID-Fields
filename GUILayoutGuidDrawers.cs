using System;
using UnityEngine;

namespace EasyGuidFields
{
    public static class GUILayoutGuidDrawers
    {
        /// <summary>
        /// Draws a basic GUID field. 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static string GuidField(string label, string guid)
        {
            return GuidField(new GUIContent(label), guid);
        }
        
        public static string GuidField(GUIContent label, string guid)
        {
            using (new GUILayout.HorizontalScope())
            {
                GUILayout.Label(label, GUILayout.ExpandWidth(false));

                GUILayout.Space(15);
                
                guid = GUILayout.TextField(guid);
                
                if (GUILayout.Button(new GUIContent("R", "Randomize"), GUILayout.ExpandWidth(false)))
                {
                    guid = Guid.NewGuid().ToString();
                }
            }

            return guid;
        }
        
#if UNITY_EDITOR

        public static string EditorGuidField(GUIContent label, string guid)
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
        
#endif
    }
}