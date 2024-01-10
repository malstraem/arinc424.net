namespace Arinc.Spec424.Terms.Converters;

internal class BoolConverter : ICharConverter
{
    public static object Convert(char @char) => @char switch
    {
        'Y' => true,
        'N' => false,
        _ => throw new ConvertException(@char.ToString(), $"Char {@char} is not valid boolean value")
    };
}
