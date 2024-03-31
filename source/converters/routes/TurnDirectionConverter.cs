using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Converters;

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
