using UnityEditor;
using System.Linq;

namespace TypeUSS.Editor
{
    /// <summary>
    /// Triggers USS generation when C# scripts are modified.
    /// </summary>
    public class TypeUSSPostprocessor : AssetPostprocessor
    {
        private static void OnPostprocessAllAssets(
            string[] importedAssets,
            string[] deletedAssets,
            string[] movedAssets,
            string[] movedFromAssetPaths)
        {
            // Check if any C# files were modified
            bool scriptsChanged = importedAssets
                .Concat(movedAssets)
                .Any(path => path.EndsWith(".cs"));

            if (scriptsChanged)
            {
                // Delay to ensure compilation is complete
                EditorApplication.delayCall += RunGeneration;
            }
        }

        private static void RunGeneration()
        {
            EditorApplication.delayCall -= RunGeneration;

            var generatedFiles = USSGenerator.GenerateAll();

            if (generatedFiles.Count > 0)
            {
                // Refresh to import the new/modified USS files
                AssetDatabase.Refresh();
            }
        }
    }
}
