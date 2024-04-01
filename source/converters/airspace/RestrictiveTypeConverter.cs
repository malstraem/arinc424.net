using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Converters;

internal abstract class RestrictiveTypeConverter : ICharConverter<RestrictiveTypeConverter, RestrictiveType>
{
    public static RestrictiveType Convert(char @char) => @char switch
    {
        'A' => RestrictiveType.Alert,
        'C' => RestrictiveType.Caution,
        'D' => RestrictiveType.Danger,
        'M' => RestrictiveType.MilitaryOperations,
        'N' => RestrictiveType.NationalSecurity,
        'P' => RestrictiveType.Prohibited,
        'R' => RestrictiveType.Restricted,
        'T' => RestrictiveType.Training,
        'W' => RestrictiveType.Warning,
        _ => RestrictiveType.Unknown
    };
}
