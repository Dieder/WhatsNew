namespace WhatsNew.New.Net8_10
{
    internal class SwitchExample
    {
        public static ConsoleColor GetKnownColor(KnownColors color)
        {
            var rgbColor = color switch
            {
                KnownColors.Red => ConsoleColor.Red,
                KnownColors.Green => ConsoleColor.Green,
                KnownColors.Blue => ConsoleColor.Blue,
                _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(KnownColors)),
            };
            return rgbColor;    
        }
    }
}
