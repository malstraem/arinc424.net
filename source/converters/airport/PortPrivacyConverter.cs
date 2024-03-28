using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Converters;

internal class PortPrivacyConverter : ICharConverter
{
    public static object Convert(char @char) => @char switch
    {
        'C' => PortPrivacy.Civil,
        'M' => PortPrivacy.Military,
        'P' => PortPrivacy.Private,
        'J' => PortPrivacy.Civil | PortPrivacy.Military,
        _ => PortPrivacy.Unknown,
    };
}
