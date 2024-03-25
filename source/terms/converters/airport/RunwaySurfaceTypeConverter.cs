namespace Arinc.Spec424.Terms.Converters;

[Obsolete("whitespace check")]
internal class RunwaySurfaceTypeConverter : ICharConverter
{
    public static object Convert(char @char) => @char switch
    {
        'H' => RunwaySurfaceType.Hard,
        'S' => RunwaySurfaceType.Soft,
        'W' => RunwaySurfaceType.Water,
        'U' or ' ' => RunwaySurfaceType.Unknown, // check whitespace to avoid problems with some data
        _ => throw new ConvertException(@char.ToString(), $"Char {@char} is not valid type of runway surface")
    };
}
