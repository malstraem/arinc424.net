namespace Arinc.Spec424.Linking;

internal class Link(LinkInfo info, string key)
{
    internal string Key { get; } = key;

    internal LinkInfo Info { get; } = info;
}
