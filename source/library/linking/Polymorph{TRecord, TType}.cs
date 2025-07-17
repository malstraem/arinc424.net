using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Arinc424.Linking;

using System.Runtime.CompilerServices;

using Diagnostics;

internal sealed class Polymorph<TRecord, TForeign, TType>(PropertyInfo property, TypeAttribute typeAttribute, ref readonly KeyInfo info)
    : Link<TRecord>(property, in info)
        where TRecord : Record424
        where TForeign : IPolymorphForeign
        where TType : class
{
    private readonly TypeAttribute typeAttribute = typeAttribute;

    private readonly Action<TRecord, TType> set = property.GetSetMethod()!.CreateDelegate<Action<TRecord, TType>>();

    private BadSection BadSection(TRecord record, Section section, int index, int subIndex) => new()
    {
        Property = property,
        Section = section,
        Record = record,
        Index = index,
        SubIndex = subIndex
    };

    private bool TryGetType
    (
        TRecord record,
        Meta424 meta,
        [NotNullWhen(true)] out (Type, Section, KeyInfo)? typeInfo,
        out Diagnostic? diagnostic
    )
    {
        typeInfo = null;
        diagnostic = null;

        string @string = record.Source!;

        var (index, subindex) = typeAttribute;

        Section section = new(@string[index], @string[subindex]);

        if (section.IsWhiteSpace())
            return false;

        if (!meta.Types.TryGetValue(section, out var type))
        {
            diagnostic = BadSection(record, section, index, subindex);
            return false;
        }

        var primary = meta.TypeInfo[type].Primary;

        if (primary is null)
        {
            diagnostic = BadLink(record, type, LinkError.NoPrimary);
            return false;
        }
        typeInfo = (type, section, primary.Value);
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
            diagnostic = null; // todo
            return false;
        }

        if (!unique.TryGetRecords(type, out var records))
        {
            diagnostic = BadLink(record, type, LinkError.KeyNotFound, key);
            reference = null;
            return false;
        }

        if (!records.TryGetValue(key, out var @ref)
         && !records.TryGetValue(info.GetKeyWithoutPort(record.Source, in primary, out key), out @ref))
        {
            diagnostic = BadLink(record, type, LinkError.KeyNotFound, key);
            reference = null;
            return false;
        }

        if (@ref is not TType)
        {
            diagnostic = BadLink(record, type, LinkError.WrongType);
            reference = null;
            return false;
        }
        reference = Unsafe.As<TType>(@ref);
        diagnostic = null;
        return true;
    }

    internal override bool TryLink(TRecord record, Unique unique, [NotNullWhen(false)] out Diagnostic? diagnostic)
    {
        if (!TryGetType(record, unique.meta, out var typeInfo, out diagnostic))
        {
            return false; // todo
        }

        var (type, section, primary) = typeInfo.Value;

        if (!TryGetReference(record, unique, type, in primary, out var reference, out diagnostic))
            return diagnostic is null; // todo

        set(record, reference);
        return true;
    }
}
