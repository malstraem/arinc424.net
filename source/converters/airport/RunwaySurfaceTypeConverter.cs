using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Converters;

internal abstract class RunwaySurfaceTypeConverter : ICharConverter<RunwaySurfaceTypeConverter, RunwaySurfaceType>
{
    public static RunwaySurfaceType Convert(char @char) => @char switch
    {
        'H' => RunwaySurfaceType.Hard,
        'S' => RunwaySurfaceType.Soft,
        'W' => RunwaySurfaceType.Water,
        _ => RunwaySurfaceType.Unknown,
    };
}
