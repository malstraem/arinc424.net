namespace Arinc.Spec424.Terms.Converters;

internal class ThresholdCrossingTypeConverter : ICharConverter
{
    public static object Convert(char @char) => @char switch
    {
        'I' => ThresholdCrossingType.ElectronicGlideSlope,
        'R' => ThresholdCrossingType.RnavProcedure,
        'D' => ThresholdCrossingType.Default,
        _ => ThresholdCrossingType.Unknown
    };
}
