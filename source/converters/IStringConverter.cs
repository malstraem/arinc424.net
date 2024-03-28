namespace Arinc.Spec424.Converters;

/// <summary>
/// Converter that decodes string to the type representing an associated term according to the specification.
/// </summary>
internal interface IStringConverter
{
    static abstract object Convert(string @string);
}
