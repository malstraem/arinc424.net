namespace Arinc424.Converters;

/**<summary>
Converter that transforms character to <typeparamref name="T"/>
according to the specification.
</summary>*/
internal interface ICharConverter<T>
    where T : Enum
{
    static abstract bool TryConvert(char @char, out T value);
}
