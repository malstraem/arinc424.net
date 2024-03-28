using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Converters;

internal class LevelConverter : ICharConverter
{
    public static object Convert(char @char) => @char switch
    {
        'B' => Level.All,
        'H' => Level.High,
        'L' => Level.Low,
        _ => Level.Unknown
    };
}
