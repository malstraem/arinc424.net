using System.Collections.Frozen;

namespace Arinc424.Attributes;

/// <summary>
/// Specifies the range of the foreign key part to establish a relationship.
/// </summary>
/// <inheritdoc/>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
internal class ForeignAttribute(int start, int end) : RangeAttribute(start, end);

[AttributeUsage(AttributeTargets.Property)]
internal class TypedForeignAttribute : ForeignAttribute
{
    internal TypedForeignAttribute(int start, int end, params Type[] types) : base(start, end) => Types = types.ToFrozenSet();

    internal FrozenSet<Type> Types { get; }
}

internal class ForeignAttribute<T>(int start, int end) : TypedForeignAttribute(start, end, typeof(T));

internal class ForeignAttribute<T1, T2>(int start, int end) : TypedForeignAttribute(start, end, typeof(T1), typeof(T2));

internal class ForeignAttribute<T1, T2, T3>(int start, int end) : TypedForeignAttribute(start, end, typeof(T1), typeof(T2), typeof(T3));

internal class ForeignAttribute<T1, T2, T3, T4>(int start, int end) : TypedForeignAttribute(start, end, typeof(T1), typeof(T2), typeof(T3), typeof(T4));
