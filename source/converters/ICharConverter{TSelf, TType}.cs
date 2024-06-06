namespace Arinc424.Converters;

/// <summary>
/// Converter that transforms character to <typeparamref name="TType"/> according to the specification.
/// </summary>
/// <typeparam name="TSelf">Converter itself.</typeparam>
/// <typeparam name="TType">Provided type.</typeparam>
internal interface ICharConverter<TSelf, TType> where TSelf : ICharConverter<TSelf, TType> where TType : Enum
{
    static abstract TType Convert(char @char);
}
