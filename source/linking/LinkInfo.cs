using System.Reflection;

using Arinc.Spec424.Attributes;

namespace Arinc.Spec424.Linking;

internal class LinkInfo(PropertyInfo property, ForeignAttribute foreignAttribute, Type[] possibleTypes)
{
    internal Range KeyRange { get; } = foreignAttribute.Range;

    internal PropertyInfo Property { get; } = property;

    internal Type[] PossibleTypes { get; } = possibleTypes;
}
