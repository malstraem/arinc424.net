using Arinc424.Navigation.Terms;

namespace Arinc424.Converters;

internal abstract class NavaidCollocationConverter : ICharConverter<NavaidCollocationConverter, NavaidCollocation>
{
    public static NavaidCollocation Convert(char @char) => char.IsWhiteSpace(@char) ? NavaidCollocation.Collocated : @char switch
    {
        'N' => NavaidCollocation.NonCollocated,
        'A' => NavaidCollocation.Collocated,
        'B' => NavaidCollocation.BeatFrequencyOscillator,
        _ => NavaidCollocation.Unknown
    };
}
