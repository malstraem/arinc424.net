using System.Reflection;

namespace Arinc424.Attributes;

using Linking;

/**<summary>
Specifies <c>Airport/Heliport</c> identifier range.
</summary>*/
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
internal class PortAttribute(int left, int right) : RangeAttribute(left, right)
{
    internal Link<TRecord> GetLink<TRecord>(PropertyInfo property, IcaoAttribute icao, Supplement supplement)
        where TRecord : Record424
    {
        LinkInfo info = new()
        {
            Icao = property.GetCustomAttributes<IcaoAttribute>().BySupplement(supplement)?.Range ?? icao.Range,
            Identifier = Range
        };

        return (Link<TRecord>)Activator
            .CreateInstance(typeof(Port<>)
                .MakeGenericType(typeof(TRecord)), info, property)!;
    }
}
