using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Converters;

internal class RunwaySurfaceTypeConverter : ICharConverter
{
    public static object Convert(char @char) => @char switch
    {
        'H' => RunwaySurfaceType.Hard,
        'S' => RunwaySurfaceType.Soft,
        'W' => RunwaySurfaceType.Water,
        _ => RunwaySurfaceType.Unknown,
    };
}
