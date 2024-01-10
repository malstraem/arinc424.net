namespace Arinc.Spec424.Terms.Converters;

internal class PortPrivacyConverter : ICharConverter
{
    public static object Convert(char @char) => @char switch
    {
        'C' => PortPrivacy.Civil,
        'M' => PortPrivacy.Military,
        'P' => PortPrivacy.Private,
        'J' => PortPrivacy.Civil | PortPrivacy.Military,
        _ => throw new NotImplementedException()
    };
}
