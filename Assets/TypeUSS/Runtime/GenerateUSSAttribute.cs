using System;

namespace TypeUSS
{
    /// <summary>
    /// Marks a class for USS generation. The generator will scan for static TypeStyle fields
    /// and generate a USS file at the specified path.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class GenerateUSSAttribute : Attribute
    {
        /// <summary>
        /// Path relative to Assets/ folder where the USS file will be generated.
        /// </summary>
        public string OutputPath { get; }

        /// <summary>
        /// Optional header comment to add to the generated file.
        /// </summary>
        public string Header { get; set; }

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
