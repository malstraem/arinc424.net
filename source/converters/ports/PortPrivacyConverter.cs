using Arinc424.Ports.Terms;

namespace Arinc424.Converters;

internal abstract class PortPrivacyConverter : ICharConverter<PortPrivacyConverter, PortPrivacy>
{
    public static PortPrivacy Convert(char @char) => @char switch
    {
        'C' => PortPrivacy.Civil,
        'M' => PortPrivacy.Military,
        'P' => PortPrivacy.Private,
        'J' => PortPrivacy.Civil | PortPrivacy.Military,
        _ => PortPrivacy.Unknown,
    };
}
