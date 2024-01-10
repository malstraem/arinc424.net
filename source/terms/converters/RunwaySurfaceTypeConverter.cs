namespace Arinc.Spec424.Terms.Converters;

internal class RunwaySurfaceTypeConverter : ICharConverter
{
    public static object Convert(char @char) => @char switch
    {
        'H' => RunwaySurfaceType.Hard,
        'S' => RunwaySurfaceType.Soft,
        'W' => RunwaySurfaceType.Water,
        'U' => RunwaySurfaceType.Undefined,
        _ => throw new ConvertException(@char.ToString(), $"Char {@char} is not valid type of runway surface")
    };
}
