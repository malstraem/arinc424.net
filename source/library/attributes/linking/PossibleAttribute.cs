namespace Arinc424.Attributes;

/// <summary>
/// Specifies possible types for the possible types of links that are likely to be found.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
internal abstract class PossibleAttribute(params Type[] types) : Attribute
{
    internal Type[] Types { get; } = types;
}

/// <inheritdoc />
internal class PossibleAttribute<T>() : PossibleAttribute(typeof(T))
    where T : Record424;

/// <inheritdoc />
internal class PossibleAttribute<T, T2>() : PossibleAttribute(typeof(T), typeof(T2))
    where T : Record424
    where T2 : Record424;