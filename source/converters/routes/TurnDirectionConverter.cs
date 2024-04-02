using Arinc424.Procedures.Terms;

namespace Arinc424.Converters;

/// <summary>
/// Converter for <see cref="TurnDirection"/>.
/// </summary>
internal class TurnDirectionConverter : ICharConverter<TurnDirectionConverter, TurnDirection>
{
    public static TurnDirection Convert(char @char) => @char switch
    {
        'L' => TurnDirection.Left,
        'R' => TurnDirection.Right,
        'E' => TurnDirection.Either,
        _ => TurnDirection.Unknown
    };
}
