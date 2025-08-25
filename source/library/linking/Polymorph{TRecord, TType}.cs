using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Arinc424.Linking;

internal sealed class Polymorph<TRecord, TType>(PropertyInfo property, TypeAttribute typeAttribute, KeyInfo info)
    : Link<TRecord>(property, info, true)
        where TRecord : Record424
        where TType : class
{
    private readonly TypeAttribute typeAttribute = typeAttribute;

    private readonly Action<TRecord, TType> set = property.GetSetMethod()!.CreateDelegate<Action<TRecord, TType>>();

    private BadPolymorph Bad
    (
        LinkError error, TRecord record, Section section,
        Type? type = null, string? key = null
    )
    => new()
    {
        Info = info,
        Property = property,
        Error = error,
        Record = record,
        Section = section,
        Indices = (typeAttribute.index, typeAttribute.subIndex),
        Type = type,
        Key = key
    };

    internal override bool TryLink(TRecord record, Unique unique, [NotNullWhen(false)] out Diagnostic? diagnostic)
    {
        ReadOnlySpan<char> source = record.Source;

        var section = typeAttribute.GetSection(source);

        if (section.IsWhiteSpace() && source[info.Id].IsWhiteSpace())
        {
            if (nullState == NullabilityState.NotNull)
            {
                diagnostic = Bad(LinkError.Null, record, section);
                return false;
            }
            else
            {
                diagnostic = null;
                return true;
            }
        }

        if (!unique.meta.TryType(section, out var type, out var primary))
        {
            diagnostic = Bad(LinkError.WrongType, record, section, type);
            return false;
        }

        if (!info.TryGetKey(source, primary, out string? key))
        {
            diagnostic = Bad(LinkError.Null, record, section, type);
            return false;
        }

        if (!(unique.TryGetRecords(type, out var records)
          && (records.TryGetValue(key, out var @ref)
          || records.TryGetValue(info.GetKeyWithoutPort(source, primary, out key), out @ref))))
        {
            diagnostic = Bad(LinkError.KeyNotFound, record, section, type, key);
            return false;
        }

        if (@ref is not TType)
        {
            diagnostic = Bad(LinkError.WrongType, record, section, type, key);
            return false;
        }
        set(record, Unsafe.As<TType>(@ref));
        diagnostic = null;
        return true;
    }
}
