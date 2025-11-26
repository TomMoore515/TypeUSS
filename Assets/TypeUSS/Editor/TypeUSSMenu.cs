using UnityEditor;
using UnityEngine;

namespace TypeUSS.Editor
{
    /// <summary>
    /// Editor menu items for TypeUSS.
    /// </summary>
    public static class TypeUSSMenu
    {
        [MenuItem("TypeUSS/Regenerate All USS")]
        public static void RegenerateAll()
        {
            var files = USSGenerator.GenerateAll();

            if (files.Count == 0)
            {
                Debug.Log("[TypeUSS] No [GenerateUSS] classes found.");
            }
            else
            {
                Debug.Log($"[TypeUSS] Generated {files.Count} USS file(s).");
                AssetDatabase.Refresh();
            }
        }

        [MenuItem("TypeUSS/Regenerate All USS", true)]
        private static bool RegenerateAllValidate()
        {
            // Only enable when not playing
            return !EditorApplication.isPlaying;
        }
    }
}
