using System.Collections.Generic;
using System.Text;

namespace TypeUSS
{
    /// <summary>
    /// Represents a complete USS style: selector + properties.
    /// </summary>
    public class TypeStyle
    {
        public Selector Selector { get; }
        public IReadOnlyList<StyleProperty> Properties { get; }

        internal TypeStyle(Selector selector, IReadOnlyList<StyleProperty> properties)
        {
            Selector = selector;
            Properties = properties;
        }

        /// <summary>
        /// Generates USS text for this style.
        /// </summary>
        public string ToUSS()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Selector.SelectorString} {{");

            foreach (var prop in Properties)
            {
                sb.AppendLine($"    {prop.ToUSS()}");
            }

            sb.Append("}");
            return sb.ToString();
        }

        public override string ToString() => ToUSS();
    }
}
