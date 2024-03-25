using System.Collections.Frozen;

namespace Arinc.Spec424.Attributes;

[AttributeUsage(AttributeTargets.Property)]
internal class ExceptAttribute : Attribute
{
    internal ExceptAttribute(params Type[] types)
    {
        Types = types.ToFrozenSet();
    }

    internal FrozenSet<Type> Types { get; }
}

internal class ExceptAttribute<TType> : ExceptAttribute
{
    internal ExceptAttribute() : base(typeof(TType)) { }
}
