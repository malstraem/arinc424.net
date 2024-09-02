namespace Arinc424.Attributes;

/// <summary>
/// Specifies <c>Airport/Heliport</c> identifier range.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
internal class PortAttribute(int left, int right, Supplement start = Supplement.V18) : RangeAttribute(left, right, start);

/// <summary>
/// Specifies <c>ICAO Code</c> range.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
internal class IcaoAttribute(int left, int right, Supplement start = Supplement.V18) : RangeAttribute(left, right, start);

/// <summary>
/// Specifies that the property is one-to-many and relationships will be established after parsing.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
internal class ManyAttribute : Attribute;

/// <summary>
/// Specifies that the property is one-to-one and relationship will be established after parsing.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
internal class OneAttribute : Attribute;
