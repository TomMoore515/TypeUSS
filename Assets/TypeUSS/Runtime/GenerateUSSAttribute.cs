using System;

namespace TypeUSS
{
    /// <summary>
    /// Marks a class for USS generation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class GenerateUSSAttribute : Attribute
    {
        /// <summary>
        /// Path relative to Assets/ folder where the USS file will be generated.
        /// </summary>
        public string OutputPath { get; }

        /// <summary>
        /// Creates a new GenerateUSS attribute.
        /// </summary>
        /// <param name="outputPath">Path relative to Assets/ folder (e.g., "UI/Styles/Chat.uss")</param>
        public GenerateUSSAttribute(string outputPath)
        {
            OutputPath = outputPath;
        }
    }
}
