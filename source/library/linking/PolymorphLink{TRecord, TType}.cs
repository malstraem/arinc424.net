using System.Diagnostics.CodeAnalysis;
using System.Reflection;

using Arinc424.Diagnostics;

namespace Arinc424.Linking;

internal sealed class PolymorphLink<TRecord, TType>(KeyInfo ranges, PropertyInfo property, TypeAttribute typeAttribute)
    : Link<TRecord, TType>(ranges, property)
        where TRecord : Record424
        where TType : class
{
    private (int Section, int Subsection) indexes = (typeAttribute.SectionIndex, typeAttribute.SubsectionIndex);

    private bool TryGetReference(TRecord record, Meta424 meta, [NotNullWhen(true)] out (string, Type, Section)? reference, out Diagnostic? diagnostic)
    {
        reference = null;
        diagnostic = null;

        string @string = record.Source!;

        var (index, subindex) = indexes;

        char sectionChar = @string[index];
        char subsectionChar = @string[subindex];

        Section section = new(sectionChar, subsectionChar);

        if (char.IsWhiteSpace(sectionChar) && char.IsWhiteSpace(subsectionChar))
            return false;

        if (!meta.Types.TryGetValue(section, out var type))
        {
            diagnostic = new InvalidSection(record, property, index, subindex);
            Debug.WriteLine(diagnostic);
            return false;
        }

        var primary = meta.TypeInfo[type].Primary;

        if (primary is null)
        {
            diagnostic = new InvalidLink(record, property, foreign.Info, LinkError.NoPrimary);
            Debug.WriteLine(diagnostic);
            return false;
        }
        if (foreign.TryGetKey(@string, primary, out string? key))
        {
            reference = (key, type, section);
            return true;
        }
        return false;
    }

    internal override bool TryLink(TRecord record, Unique unique, Meta424 meta, [NotNullWhen(false)] out Diagnostic? diagnostic)
    {
        if (!TryGetReference(record, meta, out var reference, out diagnostic))
            return diagnostic is null;

        (string key, var type, var section) = reference.Value;

        if (!unique.TryGetRecords(type, out var records))
        {
            diagnostic = new InvalidLink(record, property, foreign.Info, LinkError.NoOneFound);
            Debug.WriteLine(diagnostic);
            return false;
        }
        if (!records.TryGetValue(key, out var referenced))
        {
            diagnostic = new InvalidLink(record, property, foreign.Info, LinkError.KeyNotFound) { Key = key };
            Debug.WriteLine(diagnostic);
            return false;
        }
        if (referenced is not TType @ref)
        {
            diagnostic = new InvalidLink(record, property, foreign.Info, LinkError.WrongType) { WrongType = type };
            Debug.WriteLine(diagnostic);
            return false;
        }
        set(record, @ref);

        meta.TypeInfo[type].Relations.Process(type, referenced, record);

        return true;
    }
}
