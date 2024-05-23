namespace Arinc424.Converters;

/// <summary>
/// Converter that decodes string to the type representing an associated term according to the specification.
/// </summary>
internal interface IStringConverter
{
    static abstract Result<object> Convert(ReadOnlySpan<char> @string);
}

/// <summary>
/// Converter that decodes string to <typeparamref name="TType"/> according to the specification.
/// </summary>
/// <typeparam name="TSelf">Converter itself.</typeparam>
/// <typeparam name="TType">Provided type.</typeparam>
internal interface IStringConverter<TSelf, TType> : IStringConverter where TType : notnull
                                                                     where TSelf : IStringConverter<TSelf, TType>
{
    static abstract new Result<TType> Convert(ReadOnlySpan<char> @string);

    static Result<object> IStringConverter.Convert(ReadOnlySpan<char> @string) => TSelf.Convert(@string);
}
