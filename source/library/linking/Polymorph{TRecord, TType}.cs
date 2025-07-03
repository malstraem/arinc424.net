using System.Diagnostics.CodeAnalysis;
using System.Reflection;

using Arinc424.Diagnostics;

namespace Arinc424.Linking;

internal sealed class Polymorph<TRecord, TType>(LinkInfo info, PropertyInfo property, TypeAttribute typeAttribute)
    : Known<TRecord, TType>(info, property)
        where TRecord : Record424
        where TType : class
{
    private readonly TypeAttribute typeAttribute = typeAttribute;

    private bool TryGetReference(TRecord record, Meta424 meta, [NotNullWhen(true)] out (string, Type, Section)? reference, out Diagnostic? diagnostic)
    {
        reference = null;
        diagnostic = null;

        string @string = record.Source!;

        var (index, subindex) = typeAttribute;

        Section section = new(@string[index], @string[subindex]);

        if (section.IsWhiteSpace())
            return false;

        if (!meta.Types.TryGetValue(section, out var type))
        {
            diagnostic = new InvalidSection(record, property, index, subindex);
            return false;
        }
        var primary = meta.TypeInfo[type].Primary;

        if (primary is null)
        {
            diagnostic = new InvalidLink(record, property, foreign.Info, LinkError.NoPrimary);
            return false;
        }

        if (foreign.TryGetKey(@string, primary, out string? key))
        {
            reference = (key, type, section);
            return true;
        }
        return false;
    }

    internal override bool TryLink(TRecord record, Unique unique, [NotNullWhen(false)] out Diagnostic? diagnostic)
    {
        if (!TryGetReference(record, unique.meta, out var reference, out diagnostic))
            return diagnostic is null;

        (string key, var type, var section) = reference.Value;

        if (!unique.TryGetRecords(type, out var records))
        {
            diagnostic = new InvalidLink(record, property, foreign.Info, LinkError.NoOneFound);
            return false;
        }
        if (!records.TryGetValue(key, out var referenced))
        {
            diagnostic = new InvalidLink(record, property, foreign.Info, LinkError.KeyNotFound)
            {
                Key = key,
                Type = unique.meta.Types[section]
            };
            return false;
        }
        if (referenced is not TType @ref)
        {
            diagnostic = new InvalidLink(record, property, foreign.Info, LinkError.WrongType)
            {
                Type = type
            };
            return false;
        }
        set(record, @ref);

        unique.meta.TypeInfo[type].Relations?.Process(referenced, record);

        return true;
    }
}
