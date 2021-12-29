namespace WhatsNew.New.Net8_10.Ten;

internal class ConstantInterpolateString
{
    const string author = "Mother Theresa";
    const string dontWorry = "Never worry about numbers.";
    const string instead = "Help one person at a time and always " +
        "start with the person nearest you.";
    const string quote = $"{ dontWorry } { instead } - { author }";

    [Obsolete($"Use {nameof(ConstantInterpolateString)} instead.")]
    public string DisplayQoute() => quote;
}
