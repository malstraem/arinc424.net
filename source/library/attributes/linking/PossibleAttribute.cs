namespace Arinc424.Attributes;

/// <summary>
/// Specifies the possible types of related entities that are likely to be found.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
internal abstract class PossibleAttribute(params Type[] types) : Attribute
{
    internal Type[] Types { get; } = types;
}

/// <inheritdoc />
internal class PossibleAttribute<T, T2>() : PossibleAttribute(typeof(T), typeof(T2))
    where T : Record424
    where T2 : Record424;
