using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UIElements;

namespace TypeUSS
{
    public class StyleBuilder
    {
        private readonly List<StyleProperty> _properties = new();

        internal IReadOnlyList<StyleProperty> Build() => _properties;

        // Escape hatch for properties not yet wrapped
        public StyleBuilder Prop(string name, string value)
        {
            _properties.Add(new StyleProperty(name, value));
            return this;
        }

        // Layout - Sizing
        public StyleBuilder Width(Length length) => Prop("width", length.ToUSS());
        public StyleBuilder Height(Length length) => Prop("height", length.ToUSS());
        public StyleBuilder MinWidth(Length length) => Prop("min-width", length.ToUSS());
        public StyleBuilder MinHeight(Length length) => Prop("min-height", length.ToUSS());
        public StyleBuilder MaxWidth(Length length) => Prop("max-width", length.ToUSS());
        public StyleBuilder MaxHeight(Length length) => Prop("max-height", length.ToUSS());

        // Layout - Flexbox
        public StyleBuilder FlexDirection(FlexDirection direction)
            => Prop("flex-direction", direction.ToUSS());

        public StyleBuilder FlexWrap(Wrap wrap)
            => Prop("flex-wrap", wrap.ToUSS());

        public StyleBuilder FlexGrow(float value)
            => Prop("flex-grow", value.ToString(CultureInfo.InvariantCulture));

        public StyleBuilder FlexShrink(float value)
            => Prop("flex-shrink", value.ToString(CultureInfo.InvariantCulture));

        public StyleBuilder FlexBasis(Length length)
            => Prop("flex-basis", length.ToUSS());

        public StyleBuilder AlignItems(Align align)
            => Prop("align-items", align.ToUSS());

        public StyleBuilder AlignSelf(Align align)
            => Prop("align-self", align.ToUSS());

        public StyleBuilder AlignContent(Align align)
            => Prop("align-content", align.ToUSS());

        public StyleBuilder JustifyContent(Justify justify)
            => Prop("justify-content", justify.ToUSS());

        // Spacing - Padding
        public StyleBuilder Padding(float all)
            => Prop("padding", $"{all}px");

        public StyleBuilder Padding(float vertical, float horizontal)
            => Prop("padding", $"{vertical}px {horizontal}px");

        public StyleBuilder Padding(float top, float right, float bottom, float left)
            => Prop("padding", $"{top}px {right}px {bottom}px {left}px");

        public StyleBuilder PaddingTop(Length length) => Prop("padding-top", length.ToUSS());
        public StyleBuilder PaddingRight(Length length) => Prop("padding-right", length.ToUSS());
        public StyleBuilder PaddingBottom(Length length) => Prop("padding-bottom", length.ToUSS());
        public StyleBuilder PaddingLeft(Length length) => Prop("padding-left", length.ToUSS());

        // Spacing - Margin
        public StyleBuilder Margin(float all) => Prop("margin", $"{all}px");
        public StyleBuilder Margin(float vertical, float horizontal) => Prop("margin", $"{vertical}px {horizontal}px");
        public StyleBuilder Margin(float top, float right, float bottom, float left) => Prop("margin", $"{top}px {right}px {bottom}px {left}px");

        public StyleBuilder MarginTop(Length length) => Prop("margin-top", length.ToUSS());
        public StyleBuilder MarginRight(Length length) => Prop("margin-right", length.ToUSS());
        public StyleBuilder MarginBottom(Length length) => Prop("margin-bottom", length.ToUSS());
        public StyleBuilder MarginLeft(Length length) => Prop("margin-left", length.ToUSS());

        // Position
        public StyleBuilder Position(Position position) => Prop("position", position.ToUSS());

        public StyleBuilder Top(Length length) => Prop("top", length.ToUSS());
        public StyleBuilder Right(Length length) => Prop("right", length.ToUSS());
        public StyleBuilder Bottom(Length length) => Prop("bottom", length.ToUSS());
        public StyleBuilder Left(Length length) => Prop("left", length.ToUSS());

        // Background
        public StyleBuilder BackgroundImage(string value)
            => Prop("background-image", value);

        public StyleBuilder UnityFontDefinition(string value)
            => Prop("-unity-font-definition", value);

        public StyleBuilder UnityBackgroundImageTintColor(Color color)
            => Prop("-unity-background-image-tint-color", ColorToUSS(color));

        public StyleBuilder UnityBackgroundImageTintColor(string hexColor)
            => Prop("-unity-background-image-tint-color", hexColor);

        public StyleBuilder UnityBackgroundScaleMode(string mode)
            => Prop("-unity-background-scale-mode", mode);

        // Colors
        public StyleBuilder BackgroundColor(Color color)
            => Prop("background-color", ColorToUSS(color));

        public StyleBuilder Color(Color color)
            => Prop("color", ColorToUSS(color));

        public StyleBuilder BorderColor(Color color)
            => Prop("border-color", ColorToUSS(color));

        public StyleBuilder BorderTopColor(Color color)
            => Prop("border-top-color", ColorToUSS(color));

        public StyleBuilder BorderRightColor(Color color)
            => Prop("border-right-color", ColorToUSS(color));

        public StyleBuilder BorderBottomColor(Color color)
            => Prop("border-bottom-color", ColorToUSS(color));

        public StyleBuilder BorderLeftColor(Color color)
            => Prop("border-left-color", ColorToUSS(color));

        // Borders - Width
        public StyleBuilder BorderWidth(float all)
            => Prop("border-width", $"{all}px");

        public StyleBuilder BorderTopWidth(float px)
            => Prop("border-top-width", $"{px}px");

        public StyleBuilder BorderRightWidth(float px)
            => Prop("border-right-width", $"{px}px");

        public StyleBuilder BorderBottomWidth(float px)
            => Prop("border-bottom-width", $"{px}px");

        public StyleBuilder BorderLeftWidth(float px)
            => Prop("border-left-width", $"{px}px");

        // Borders - Radius
        public StyleBuilder BorderRadius(float all)
            => Prop("border-radius", $"{all}px");

        public StyleBuilder BorderRadius(float topLeftBottomRight, float topRightBottomLeft)
            => Prop("border-radius", $"{topLeftBottomRight}px {topRightBottomLeft}px");

        public StyleBuilder BorderRadius(float topLeft, float topRight, float bottomRight, float bottomLeft)
            => Prop("border-radius", $"{topLeft}px {topRight}px {bottomRight}px {bottomLeft}px");

        public StyleBuilder BorderTopLeftRadius(float px)
            => Prop("border-top-left-radius", $"{px}px");

        public StyleBuilder BorderTopRightRadius(float px)
            => Prop("border-top-right-radius", $"{px}px");

        public StyleBuilder BorderBottomRightRadius(float px)
            => Prop("border-bottom-right-radius", $"{px}px");

        public StyleBuilder BorderBottomLeftRadius(float px)
            => Prop("border-bottom-left-radius", $"{px}px");

        // Display & Visibility
        public StyleBuilder Display(DisplayStyle display)
            => Prop("display", display.ToUSS());

        public StyleBuilder Visibility(Visibility visibility)
            => Prop("visibility", visibility.ToUSS());

        public StyleBuilder Overflow(Overflow overflow)
            => Prop("overflow", overflow.ToUSS());

        public StyleBuilder TextOverflow(TextOverflow textOverflow) => textOverflow switch
        {
            UnityEngine.UIElements.TextOverflow.Clip => Prop("text-overflow", "clip"),
            UnityEngine.UIElements.TextOverflow.Ellipsis => Prop("text-overflow", "ellipsis"),
            _ => Prop("text-overflow", "clip")
        };

        public StyleBuilder Opacity(float value)
            => Prop("opacity", value.ToString(CultureInfo.InvariantCulture));

        // Text
        public StyleBuilder WhiteSpace(WhiteSpace whiteSpace) => whiteSpace switch
        {
            UnityEngine.UIElements.WhiteSpace.Normal => Prop("white-space", "normal"),
            UnityEngine.UIElements.WhiteSpace.NoWrap => Prop("white-space", "nowrap"),
            _ => Prop("white-space", "normal")
        };

        // Typography
        public StyleBuilder FontSize(int size) => Prop("font-size", $"{size}px");
        public StyleBuilder FontSize(float size) => Prop("font-size", $"{size}px");
        public StyleBuilder LetterSpacing(float value) => Prop("letter-spacing", $"{value.ToString(CultureInfo.InvariantCulture)}px");

        public StyleBuilder UnityFontStyleAndWeight(FontStyle style) => style switch
        {
            FontStyle.Normal => Prop("-unity-font-style", "normal"),
            FontStyle.Bold => Prop("-unity-font-style", "bold"),
            FontStyle.Italic => Prop("-unity-font-style", "italic"),
            FontStyle.BoldAndItalic => Prop("-unity-font-style", "bold-and-italic"),
            _ => Prop("-unity-font-style", "normal")
        };

        public StyleBuilder UnityTextAlign(TextAnchor anchor) => anchor switch
        {
            TextAnchor.UpperLeft => Prop("-unity-text-align", "upper-left"),
            TextAnchor.UpperCenter => Prop("-unity-text-align", "upper-center"),
            TextAnchor.UpperRight => Prop("-unity-text-align", "upper-right"),
            TextAnchor.MiddleLeft => Prop("-unity-text-align", "middle-left"),
            TextAnchor.MiddleCenter => Prop("-unity-text-align", "middle-center"),
            TextAnchor.MiddleRight => Prop("-unity-text-align", "middle-right"),
            TextAnchor.LowerLeft => Prop("-unity-text-align", "lower-left"),
            TextAnchor.LowerCenter => Prop("-unity-text-align", "lower-center"),
            TextAnchor.LowerRight => Prop("-unity-text-align", "lower-right"),
            _ => Prop("-unity-text-align", "middle-left")
        };

        public StyleBuilder UnityFontDefinition(Font font)
            => Prop("-unity-font-definition", font != null ? $"resource('Fonts/{font.name}')" : "none");

        // Background positioning
        public StyleBuilder BackgroundPosition(BackgroundPositionKeyword horizontal, BackgroundPositionKeyword vertical)
        {
            var h = horizontal switch
            {
                BackgroundPositionKeyword.Left => "left",
                BackgroundPositionKeyword.Center => "center",
                BackgroundPositionKeyword.Right => "right",
                BackgroundPositionKeyword.Top => "top",
                BackgroundPositionKeyword.Bottom => "bottom",
                _ => "center"
            };
            var v = vertical switch
            {
                BackgroundPositionKeyword.Left => "left",
                BackgroundPositionKeyword.Center => "center",
                BackgroundPositionKeyword.Right => "right",
                BackgroundPositionKeyword.Top => "top",
                BackgroundPositionKeyword.Bottom => "bottom",
                _ => "center"
            };
            return Prop("background-position", $"{h} {v}");
        }

        public StyleBuilder BackgroundRepeat(Repeat horizontal, Repeat vertical)
        {
            var h = horizontal switch
            {
                Repeat.NoRepeat => "no-repeat",
                Repeat.Repeat => "repeat",
                Repeat.Round => "round",
                Repeat.Space => "space",
                _ => "no-repeat"
            };
            var v = vertical switch
            {
                Repeat.NoRepeat => "no-repeat",
                Repeat.Repeat => "repeat",
                Repeat.Round => "round",
                Repeat.Space => "space",
                _ => "no-repeat"
            };
            return Prop("background-repeat", $"{h} {v}");
        }

        public StyleBuilder BackgroundSize(float width, float height)
            => Prop("background-size", $"{width}px {height}px");

        public StyleBuilder BackgroundSize(Length width, Length height)
            => Prop("background-size", $"{width.ToUSS()} {height.ToUSS()}");

        // Transform
        public StyleBuilder Rotate(float degrees)
            => Prop("rotate", $"{degrees}deg");

        private static string ColorToUSS(Color color)
        {
            int r = Mathf.RoundToInt(color.r * 255);
            int g = Mathf.RoundToInt(color.g * 255);
            int b = Mathf.RoundToInt(color.b * 255);

            if (Mathf.Approximately(color.a, 1f))
            {
                return $"rgb({r}, {g}, {b})";
            }

            return $"rgba({r}, {g}, {b}, {color.a.ToString(CultureInfo.InvariantCulture)})";
        }
    }

    internal static class EnumExtensions
    {
        public static string ToUSS(this FlexDirection value) => value switch
        {
            FlexDirection.Row => "row",
            FlexDirection.RowReverse => "row-reverse",
            FlexDirection.Column => "column",
            FlexDirection.ColumnReverse => "column-reverse",
            _ => "row"
        };

        public static string ToUSS(this Wrap value) => value switch
        {
            Wrap.NoWrap => "nowrap",
            Wrap.Wrap => "wrap",
            Wrap.WrapReverse => "wrap-reverse",
            _ => "nowrap"
        };

        public static string ToUSS(this Align value) => value switch
        {
            Align.Auto => "auto",
            Align.FlexStart => "flex-start",
            Align.Center => "center",
            Align.FlexEnd => "flex-end",
            Align.Stretch => "stretch",
            _ => "auto"
        };

        public static string ToUSS(this Justify value) => value switch
        {
            Justify.FlexStart => "flex-start",
            Justify.Center => "center",
            Justify.FlexEnd => "flex-end",
            Justify.SpaceBetween => "space-between",
            Justify.SpaceAround => "space-around",
            _ => "flex-start"
        };

        public static string ToUSS(this Position value) => value switch
        {
            Position.Relative => "relative",
            Position.Absolute => "absolute",
            _ => "relative"
        };

        public static string ToUSS(this DisplayStyle value) => value switch
        {
            DisplayStyle.Flex => "flex",
            DisplayStyle.None => "none",
            _ => "flex"
        };

        public static string ToUSS(this Visibility value) => value switch
        {
            Visibility.Visible => "visible",
            Visibility.Hidden => "hidden",
            _ => "visible"
        };

        public static string ToUSS(this Overflow value) => value switch
        {
            Overflow.Visible => "visible",
            Overflow.Hidden => "hidden",
            _ => "visible"
        };
    }
}
