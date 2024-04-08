namespace Arinc424.Converters;

/// <summary>
/// Converter for <see cref="Turn"/>.
/// </summary>
internal class TurnConverter : ICharConverter<TurnConverter, Turn>
{
    public static Turn Convert(char @char) => @char switch
    {
        'L' => Turn.Left,
        'R' => Turn.Right,
        'E' => Turn.Either,
        _ => Turn.Unknown
    };
}
