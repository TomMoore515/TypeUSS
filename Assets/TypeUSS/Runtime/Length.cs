namespace TypeUSS
{
    public enum LengthUnit
    {
        Pixel,
        Percent,
        Auto,
        None
    }

    public readonly struct Length
    {
        public float Value { get; }
        public LengthUnit Unit { get; }

        public Length(float value, LengthUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        // Special values
        public static Length Auto => new(0, LengthUnit.Auto);
        public static Length None => new(0, LengthUnit.None);
        public static Length Zero => new(0, LengthUnit.Pixel);

        // Factory methods
        public static Length Percent(float value) => new(value, LengthUnit.Percent);
        public static Length Px(float value) => new(value, LengthUnit.Pixel);

        // Implicit conversion from numeric types (defaults to pixels)
        public static implicit operator Length(float px) => new(px, LengthUnit.Pixel);
        public static implicit operator Length(int px) => new(px, LengthUnit.Pixel);

        // Convert to USS string
        public string ToUSS()
        {
            return Unit switch
            {
                LengthUnit.Pixel => $"{Value}px",
                LengthUnit.Percent => $"{Value}%",
                LengthUnit.Auto => "auto",
                LengthUnit.None => "none",
                _ => $"{Value}px"
            };
        }

        public override string ToString() => ToUSS();
    }

    public static class LengthExtensions
    {
        public static Length Px(this int value) => new(value, LengthUnit.Pixel);
        public static Length Px(this float value) => new(value, LengthUnit.Pixel);
        public static Length Percent(this int value) => new(value, LengthUnit.Percent);
        public static Length Percent(this float value) => new(value, LengthUnit.Percent);
    }
}
