using UnityEngine.UIElements;

namespace TypeUSS
{
    /// <summary>
    /// Factory class for creating USS selectors.
    /// </summary>
    public static class Sel
    {
        /// <summary>
        /// Creates a class selector: .class-name
        /// </summary>
        public static Selector Class(string name)
            => new($".{name}", className: name);

        /// <summary>
        /// Creates an ID selector: #element-id
        /// </summary>
        public static Selector Id(string name)
            => new($"#{name}");

        /// <summary>
        /// Creates a type selector by name: TypeName
        /// </summary>
        public static Selector Type(string typeName)
            => new(typeName);

        /// <summary>
        /// Creates a type selector from a VisualElement type: TypeName
        /// </summary>
        public static Selector Type<T>() where T : VisualElement
            => new(typeof(T).Name);

        /// <summary>
        /// Escape hatch for complex selectors that can't be expressed with the builder API.
        /// </summary>
        public static Selector Raw(string selectorString)
            => new(selectorString);

        /// <summary>
        /// Universal selector: *
        /// </summary>
        public static Selector All => new("*");
    }
}
