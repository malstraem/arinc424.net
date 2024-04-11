namespace Arinc424.Converters;

internal abstract class TurnConverter : ICharConverter<TurnConverter, Turn>
{
    public static Turn Convert(char @char) => @char switch
    {
        'L' => Turn.Left,
        'R' => Turn.Right,
        'E' => Turn.Either,
        _ => Turn.Unknown
    };
}
