namespace Arinc424.Converters;

/**<summary>
Converter that decodes string to <typeparamref name="T"/>
according to the specification.
</summary>*/
internal interface IStringConverter<T>
    where T : notnull
{
    static abstract Result<T> Convert(ReadOnlySpan<char> @string);
}
