namespace Arinc424.Converters;

/// <summary>
/// Converter that transforms character to <typeparamref name="TType"/> according to the specification.
/// </summary>
/// <typeparam name="TType">Converted type.</typeparam>
internal interface ICharConverter<TType> where TType : Enum
{
    static abstract Result<TType> Convert(char @char);
}
