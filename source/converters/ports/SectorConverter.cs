using Arinc424.Ports.Terms;

namespace Arinc424.Converters;

internal abstract class SectorConverter : IStringConverter<SectorConverter, Sector>
{
    public static Sector Convert(ReadOnlySpan<char> @string)
        => new(SectorizationConverter.Convert(@string[..6]), int.Parse(@string[6..9]), int.Parse(@string[9..11]));
}
