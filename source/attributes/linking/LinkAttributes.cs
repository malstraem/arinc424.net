namespace Arinc424.Attributes;

internal class IdentifierAttribute(int start, int end) : RangeAttribute(start, end);

internal class PortAttribute(int start, int end) : RangeAttribute(start, end);

internal class IcaoAttribute(int start, int end) : RangeAttribute(start, end);
