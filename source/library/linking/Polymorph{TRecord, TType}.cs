using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Arinc424.Linking;

using Diagnostics;

internal sealed class Polymorph<TRecord, TType>(PropertyInfo property, TypeAttribute typeAttribute, ref readonly KeyInfo info)
    : Link<TRecord>(property, in info)
        where TRecord : Record424
        where TType : class
{
    private readonly TypeAttribute typeAttribute = typeAttribute;

    private readonly Action<TRecord, TType> set = property.GetSetMethod()!.CreateDelegate<Action<TRecord, TType>>();

    private BadSection BadSection(TRecord record, Section section, int index, int subIndex) => new()
    {
        Error = LinkError.BadSection,
        Info = info,
        Property = property,
        Record = record,
        Section = section,
        Index = index,
        SubIndex = subIndex
    };

    private bool TryGetType
    (
        TRecord record,
        Meta424 meta,
        Section section,
        [NotNullWhen(true)] out (Type, KeyInfo)? typeInfo,
        [NotNullWhen(false)] out Diagnostic? diagnostic
    )
    {
        if (!meta.Types.TryGetValue(section, out var type))
        {
            diagnostic = BadSection(record, section, 0, 0); //todo indices
            typeInfo = null;
            return false;
        }

        var primary = meta.TypeInfo[type].Primary;

        if (primary is null)
        {
            diagnostic = BadSection(record, section, 0, 0); //todo indices
            typeInfo = null;
            return false;
        }
        typeInfo = (type, primary.Value);
        diagnostic = null;
        return true;
    }

    private bool TryGetReference
    (
        TRecord record,
        Unique unique,
        Type type,
        ref readonly KeyInfo primary,
        [NotNullWhen(true)] out TType? reference,
        [NotNullWhen(false)] out Diagnostic? diagnostic
    )
    {
        if (!info.TryGetKey(record.Source, in primary, out string? key))
        {
            reference = null;
            diagnostic = BadLink(LinkError.Null, record, type);
            return false;
        }

        if (!unique.TryGetRecords(type, out var records))
        {
            diagnostic = BadLink(LinkError.KeyNotFound, record, type, key);
            reference = null;
            return false;
        }

        if (!records.TryGetValue(key, out var @ref)
         && !records.TryGetValue(info.GetKeyWithoutPort(record.Source, in primary, out key), out @ref))
        {
            diagnostic = BadLink(LinkError.KeyNotFound, record, type, key);
            reference = null;
            return false;
        }

        if (@ref is not TType)
        {
            diagnostic = BadLink(LinkError.WrongType, record, type);
            reference = null;
            return false;
        }
        reference = Unsafe.As<TType>(@ref);
        diagnostic = null;
        return true;
    }

    internal override bool TryLink(TRecord record, Unique unique, [NotNullWhen(false)] out Diagnostic? diagnostic)
    {
        ReadOnlySpan<char> source = record.Source!;

        var (index, subindex) = typeAttribute;

        Section section = new(source[index], source[subindex]);

        if (section.IsWhiteSpace())
        {
            if (source[info.Id].IsWhiteSpace())
            {
                if (nullState == NullabilityState.NotNull)
                {
                    diagnostic = BadLink(LinkError.Null, record);
                    return false;
                }
                else
                {
                    diagnostic = null;
                    return true;
                }
            }
        }

        if (!TryGetType(record, unique.meta, section, out var typeInfo, out diagnostic))
            return false;

        var (type, primary) = typeInfo.Value;

        if (TryGetReference(record, unique, type, in primary, out var reference, out diagnostic))
        {
            set(record, reference);
            return true;
        }
        return false;
    }
}
