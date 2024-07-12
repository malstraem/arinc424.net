namespace Arinc424.Attributes;

internal class IdentifierAttribute(int start, int end, Supplement supplement = Supplement.None) : RangeAttribute(start, end, supplement);

internal class PortAttribute(int start, int end, Supplement supplement = Supplement.None) : RangeAttribute(start, end, supplement);

internal class IcaoAttribute(int start, int end, Supplement supplement = Supplement.None) : RangeAttribute(start, end, supplement);
