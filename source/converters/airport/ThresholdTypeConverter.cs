using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Converters;

internal abstract class ThresholdTypeConverter : ICharConverter<ThresholdTypeConverter, ThresholdType>
{
    public static ThresholdType Convert(char @char) => @char switch
    {
        'I' => ThresholdType.ElectronicGlideSlope,
        'R' => ThresholdType.RnavProcedure,
        'D' => ThresholdType.Default,
        _ => ThresholdType.Unknown
    };
}
