namespace Arinc424.Converters;

internal abstract class LegDirectionConverter : ICharConverter<LegDirectionConverter, LegDirection>
{
    public static LegDirection Convert(char @char) => @char switch
    {
        'I' => LegDirection.Inbound,
        'O' => LegDirection.Outbound,
        _ => LegDirection.Unknown
    };
}
