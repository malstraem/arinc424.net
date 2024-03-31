namespace Arinc.Spec424.Converters;

internal abstract class BoolConverter : ICharConverter<BoolConverter, bool>
{
    public static bool Convert(char @char) => @char is 'Y';
}
