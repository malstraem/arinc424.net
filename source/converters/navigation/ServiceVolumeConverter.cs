using Arinc424.Navigation.Terms;

namespace Arinc424.Converters;

internal abstract class ServiceVolumeConverter : ICharConverter<ServiceVolumeConverter, ServiceVolume>
{
    public static ServiceVolume Convert(char @char) => @char switch
    {
        'A' => ServiceVolume.Alpha,
        'B' => ServiceVolume.Bravo,
        'C' => ServiceVolume.Charlie,
        'D' => ServiceVolume.Delta,
        'U' => ServiceVolume.Unspecified,
        _ => ServiceVolume.Unknown
    };
}
