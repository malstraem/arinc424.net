namespace Arinc.Spec424.Converters;

/// <summary>
/// Converter that transforms character to the type representing an associated term according to the specification.
/// </summary>
internal interface ICharConverter
{
    static abstract object Convert(char @char);
}

/// <inheritdoc cref="ICharConverter"/>
/// <typeparam name="TSelf">Converter itself.</typeparam>
/// <typeparam name="TType">Provided type.</typeparam>
internal interface ICharConverter<TSelf, TType> : ICharConverter where TType : notnull
                                                                 where TSelf : ICharConverter<TSelf, TType>
{
    static abstract new TType Convert(char @char);

    static object ICharConverter.Convert(char @char) => TSelf.Convert(@char);
}
