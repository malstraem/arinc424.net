using System.Collections.Frozen;

namespace Arinc424.Attributes;

[AttributeUsage(AttributeTargets.Property)]
internal class ForeignExceptAttribute : ForeignAttribute
{
    internal ForeignExceptAttribute(int start, int end, params Type[] types) : base(start, end) => Types = types.ToFrozenSet();

    internal FrozenSet<Type> Types { get; }
}

internal class ForeignExceptAttribute<T>(int start, int end) : ForeignExceptAttribute(start, end, typeof(T));

internal class ForeignExceptAttribute<T1, T2>(int start, int end) : ForeignExceptAttribute(start, end, typeof(T1), typeof(T2));

internal class ForeignExceptAttribute<T1, T2, T3>(int start, int end) : ForeignExceptAttribute(start, end, typeof(T1), typeof(T2), typeof(T3));

internal class ForeignExceptAttribute<T1, T2, T3, T4>(int start, int end) : ForeignExceptAttribute(start, end, typeof(T1), typeof(T2), typeof(T3), typeof(T4));
