using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace TypeUSS.Editor
{
    /// <summary>
    /// Ensures USS is regenerated before builds.
    /// </summary>
    public class TypeUSSBuildProcessor : IPreprocessBuildWithReport
    {
        public int callbackOrder => -100; // Run early

        public void OnPreprocessBuild(BuildReport report)
        {
            Debug.Log("[TypeUSS] Regenerating USS before build...");
            var files = USSGenerator.GenerateAll();
            Debug.Log($"[TypeUSS] Generated {files.Count} USS file(s) for build.");
        }
    }
}
