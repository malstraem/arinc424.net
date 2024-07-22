namespace Arinc424.Converters;

/// <summary>
/// Converter that decodes string to <typeparamref name="TType"/> according to the specification.
/// </summary>
/// <typeparam name="TType">Provided type.</typeparam>
internal interface IStringConverter<TType> where TType : notnull
{
    static abstract Result<TType> Convert(ReadOnlySpan<char> @string);
}
