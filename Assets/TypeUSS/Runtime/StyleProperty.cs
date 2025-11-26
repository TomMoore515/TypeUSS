namespace TypeUSS
{
    /// <summary>
    /// Represents a single USS property name-value pair.
    /// </summary>
    public readonly struct StyleProperty
    {
        public string Name { get; }
        public string Value { get; }

        public StyleProperty(string name, string value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Converts to USS property declaration (e.g., "width: 100px;")
        /// </summary>
        public string ToUSS() => $"{Name}: {Value};";

        public override string ToString() => ToUSS();
    }
}
