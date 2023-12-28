namespace Arinc.Spec424.Terms.Converters;

/// <summary>
/// Converter that transforms character to the type representing an associated term according to the specification.
/// </summary>
internal interface ICharConverter
{
    static abstract object Convert(char @char);
}
