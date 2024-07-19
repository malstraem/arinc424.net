namespace Arinc424.Attributes;

[AttributeUsage(AttributeTargets.Property)]
internal abstract class PossibleAttribute(params Type[] types) : Attribute
{
    internal Type[] Types { get; } = types;
}

internal class PossibleAttribute<T>() : PossibleAttribute(typeof(T))
    where T : Record424;

internal class PossibleAttribute<T, T2>() : PossibleAttribute(typeof(T), typeof(T2))
    where T : Record424
    where T2 : Record424;
