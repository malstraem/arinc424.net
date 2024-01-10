namespace Arinc.Spec424.Terms.Converters;

internal class PortPrivacyConverter : ICharConverter
{
    public static object Convert(char @char) => @char switch
    {
        ' ' => PortPrivacy.Unknown,
        'C' => PortPrivacy.Civil,
        'M' => PortPrivacy.Military,
        'P' => PortPrivacy.Private,
        'J' => PortPrivacy.Civil | PortPrivacy.Military,
        _ => throw new ConvertException(@char.ToString(), $"Char {@char} is not valid for Public/Military Indicator")
    };
}
