namespace Arinc.Spec424.Attributes;

internal abstract class PossibleAttribute(params Type[] types) : Attribute
{
    internal Type[] Types { get; } = types;
}

internal class PossibleAttribute<T>() : PossibleAttribute(typeof(T))
    where T : Record424;

internal class PossibleAttribute<T, T2>() : PossibleAttribute(typeof(T), typeof(T2))
    where T : Record424 where T2 : Record424;

internal class PossibleAttribute<T, T2, T3>() : PossibleAttribute(typeof(T), typeof(T2), typeof(T3))
    where T : Record424 where T2 : Record424 where T3 : Record424;
