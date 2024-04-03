namespace Arinc424.Converters;

/// <summary>
/// Converter that decodes string to the type representing an associated term according to the specification.
/// </summary>
internal interface IStringConverter
{
    static abstract object Convert(ReadOnlySpan<char> @string);
}

/// <inheritdoc cref="IStringConverter"/>
/// <typeparam name="TSelf">Converter itself.</typeparam>
/// <typeparam name="TType">Provided type.</typeparam>
internal interface IStringConverter<TSelf, TType> : IStringConverter where TType : notnull
                                                                     where TSelf : IStringConverter<TSelf, TType>
{
    static abstract new TType Convert(ReadOnlySpan<char> @string);

    static object IStringConverter.Convert(ReadOnlySpan<char> @string) => TSelf.Convert(@string);
}
