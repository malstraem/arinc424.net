namespace Arinc424.Attributes;

internal abstract class SupplementAttribute(Supplement supplement) : Attribute
{
    internal Supplement Supplement { get; } = supplement;
}
