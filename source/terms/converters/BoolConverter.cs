namespace Arinc.Spec424.Terms.Converters;

[Obsolete("whitespace check")]
internal class BoolConverter : ICharConverter
{
    public static object Convert(char @char) => @char switch
    {
        'Y' => true,
        'N' or ' ' => false, // check whitespace to avoid problems with some data
        _ => throw new ConvertException(@char.ToString(), $"Char {@char} is not valid boolean value")
    };
}
