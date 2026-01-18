using System;

namespace TypeUSS
{
    /// <summary>
    /// Specifies which USS files should be auto-populated into this StyleSheet[] field
    /// based on their output path. Only USS files whose paths start with one of the
    /// specified path prefixes will be included.
    /// </summary>
    /// <example>
    /// <code>
    /// // Only include stylesheets from the StarUI folder
    /// [StyleSheetPath("Scripts/Client/UI/StarUI/")]
    /// [SerializeField] private StyleSheet[] styleSheets;
    ///
    /// // Include from multiple paths
    /// [StyleSheetPath("Scripts/Client/UI/StarUI/", "Scripts/Shared/UI/")]
    /// [SerializeField] private StyleSheet[] styleSheets;
    /// </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class StyleSheetPathAttribute : Attribute
    {
        /// <summary>
        /// Path prefixes to match against USS output paths.
        /// Paths are relative to Assets/ and use forward slashes.
        /// </summary>
        public string[] PathPrefixes { get; }

        /// <summary>
        /// Creates a new StyleSheetPath attribute with the specified path prefixes.
        /// </summary>
        /// <param name="pathPrefixes">One or more path prefixes to match.
        /// USS files whose output path starts with any of these prefixes will be included.</param>
        public StyleSheetPathAttribute(params string[] pathPrefixes)
        {
            PathPrefixes = pathPrefixes ?? Array.Empty<string>();
        }
    }
}
