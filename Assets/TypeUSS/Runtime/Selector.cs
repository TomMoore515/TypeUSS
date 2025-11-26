using System;

namespace TypeUSS
{
    /// <summary>
    /// Represents a USS selector with support for combinators and pseudo-classes.
    /// </summary>
    public class Selector
    {
        /// <summary>
        /// The full selector string (e.g., ".btn:hover > .icon")
        /// </summary>
        public string SelectorString { get; }

        /// <summary>
        /// The class name if this is a simple class selector, otherwise null.
        /// Used for AddToClassList() integration.
        /// </summary>
        public string ClassName { get; }

        internal Selector(string selectorString, string className = null)
        {
            SelectorString = selectorString;
            ClassName = className;
        }

        /// <summary>
        /// Implicit conversion to string for AddToClassList() compatibility.
        /// Returns ClassName if available, otherwise the full SelectorString.
        /// </summary>
        public static implicit operator string(Selector s) => s.ClassName ?? s.SelectorString;

        // Pseudo-class modifiers
        public Selector Hover() => new($"{SelectorString}:hover");
        public Selector Active() => new($"{SelectorString}:active");
        public Selector Focus() => new($"{SelectorString}:focus");
        public Selector Checked() => new($"{SelectorString}:checked");
        public Selector Disabled() => new($"{SelectorString}:disabled");
        public Selector Enabled() => new($"{SelectorString}:enabled");
        public Selector Root() => new($"{SelectorString}:root");

        // Combinators

        /// <summary>
        /// Child combinator: parent > child
        /// </summary>
        public static Selector operator >(Selector parent, Selector child)
            => new($"{parent.SelectorString} > {child.SelectorString}");

        /// <summary>
        /// Required by C# when defining operator >. Not meaningful for selectors.
        /// </summary>
        public static Selector operator <(Selector a, Selector b)
            => throw new NotSupportedException("Use > for child combinator");

        /// <summary>
        /// Adjacent sibling combinator: a + b
        /// </summary>
        public static Selector operator +(Selector a, Selector b)
            => new($"{a.SelectorString} + {b.SelectorString}");

        /// <summary>
        /// Descendant combinator: ancestor descendant
        /// </summary>
        public Selector Descendant(Selector descendant)
            => new($"{SelectorString} {descendant.SelectorString}");

        /// <summary>
        /// Combines selectors without space: Button.my-class
        /// </summary>
        public Selector And(Selector other)
            => new($"{SelectorString}{other.SelectorString}");

        /// <summary>
        /// Creates a TypeStyle from this selector with the specified styles.
        /// </summary>
        public TypeStyle Style(Action<StyleBuilder> configure)
        {
            var builder = new StyleBuilder();
            configure(builder);
            return new TypeStyle(this, builder.Build());
        }

        public override string ToString() => SelectorString;
    }
}
