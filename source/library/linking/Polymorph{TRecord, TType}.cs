using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Arinc424.Linking;

using Diagnostics;

internal sealed class Polymorph<TRecord, TForeign, TType>(PropertyInfo property, TypeAttribute typeAttribute, in KeyInfo info)
    : Link<TRecord>(property, in info)
        where TRecord : Record424
        where TForeign : IPolymorphForeign
        where TType : class
{
    private readonly TypeAttribute typeAttribute = typeAttribute;

    private readonly Action<TRecord, TType> set = property.GetSetMethod()!.CreateDelegate<Action<TRecord, TType>>();

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
            diagnostic = new InvalidLink(record, property, in info, LinkError.NoPrimary);
            return false;
        }

        if (TForeign.TryGetKey(@string, in info, primary.Value, type, out string? key))
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
            diagnostic = new InvalidLink(record, property, in info, LinkError.NoOneFound) { Type = type };
            return false;
        }
        if (!records.TryGetValue(key, out var referenced))
        {
            diagnostic = new InvalidLink(record, property, in info, LinkError.KeyNotFound)
            {
                Key = key,
                Type = type
            };
            return false;
        }
        if (referenced is not TType @ref)
        {
            diagnostic = new InvalidLink(record, property, in info, LinkError.WrongType)
            {
                Type = type
            };
            return false;
        }
        set(record, @ref);
        return true;
    }
}
